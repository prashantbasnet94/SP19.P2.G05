using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SP19.P03.Tests
{
    public class PathAssertion
    {
        public PathAssertion(string method, bool isArray, string ofType, bool hasUrlParameter, bool hasBodyParameter)
        {
            Method = method;
            IsArray = isArray;
            OfType = ofType;
            HasUrlParameter = hasUrlParameter;
            HasBodyParameter = hasBodyParameter;
        }

        protected PathAssertion()
        {
            
        }

        private string Method { get; }
        private bool IsArray { get; }
        private string OfType { get; }
        private bool HasUrlParameter { get; }
        private bool HasBodyParameter { get; }

        public virtual bool IsMatchingPath(Operation pathInfo)
        {
            foreach (var item in pathInfo)
            {
                var details = item.Value;
                if (!IsCorrectMethod(item))
                {
                    continue;
                }

                if (HasUrlParameter && details.Parameters.All(x => x.In != "path"))
                {
                    continue;
                }
                if (HasBodyParameter && details.Parameters.All(x => x.In != "body"))
                {
                    continue;
                }

                if (!string.Equals(Method, "delete", StringComparison.InvariantCultureIgnoreCase) && !IsCorrectReturnType(details))
                {
                    continue;
                }

                if (string.Equals(Method, "get", StringComparison.InvariantCultureIgnoreCase) && !HasUrlParameter && details.Parameters.Any(x => x.In == "path"))
                {
                    continue;
                }
                return true;
            }

            return false;
        }

        protected virtual bool IsCorrectMethod(KeyValuePair<string, OperationDetail> item)
        {
            return string.Equals(Method, item.Key, StringComparison.InvariantCultureIgnoreCase);
        }
        
        protected virtual bool IsCorrectReturnType(OperationDetail operationDetail)
        {
            foreach (var response in operationDetail.Responses)
            {
                var details = response.Value;
                if (!string.Equals(details.Description, "success", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                if (IsArray && details.Schema?.Type != "array")
                {
                    continue;
                }

                if (IsArray && details.Schema.Items?.Ref.ToLowerInvariant().Contains($"/{OfType.ToLowerInvariant()}") != true)
                {
                    continue;
                }
                if (!IsArray && details.Schema.Ref?.ToLowerInvariant().Contains($"/{OfType.ToLowerInvariant()}") != true)
                {
                    continue;
                }
                return true;
            }
            return false;
        }

        public virtual string GetReturnTypeDescriptor()
        {
            if (IsArray)
            {
                return $"an array of {OfType}";
            }
            return $"an object of type {OfType}";
        }

        public virtual string GetParameterDescriptor()
        {
            if (HasUrlParameter)
            {
                return "has a URL parameter";
            }
            if (HasBodyParameter)
            {
                return "has a body parameter";
            }
            return "takes no parameters";
        }

        public virtual void AssertPass(string endpointName, Operation[] path)
        {
            var matching = path.Where(IsMatchingPath).FirstOrDefault();
            if (matching == null)
            {
                Assert.Fail($"Expected {endpointName} related controller to have a {Method} method that {GetParameterDescriptor()} which returns a {GetReturnTypeDescriptor()} dtos");
            }

            var response = matching
                .SelectMany(x => x.Value.Responses.Where(y => y.Value.Description == "Success").Select(y => y.Value))
                .ToArray();
            foreach (var responseDetail in response)
            {
                AssertIsDto(endpointName, responseDetail);
            }
        }

        protected virtual void AssertIsDto(string endpointName, ResponseDetail responseDetail)
        {
            if (responseDetail.Schema?.Ref?.ToLowerInvariant().EndsWith(endpointName.ToLowerInvariant()) == true)
            {
                Assert.Fail($"It looks like you are returning the entity and not a dto / view model on the {endpointName} related controller, {Method} method that {GetParameterDescriptor()}");
            }
            if (responseDetail.Schema?.Items?.Ref?.ToLowerInvariant().EndsWith(endpointName.ToLowerInvariant()) == true)
            {
                Assert.Fail($"It looks like you are returning the entity and not a dto / view model on the {endpointName} related controller, {Method} method that {GetParameterDescriptor()}");
            }
        }
    }
}