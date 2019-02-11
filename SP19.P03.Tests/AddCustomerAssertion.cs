using System;
using System.Collections.Generic;

namespace SP19.P03.Tests
{
    public class AddCustomerAssertion : PathAssertion
    {
        public AddCustomerAssertion() : base("post or put", false, "", true, false)
        {
            
        }

        public override string GetReturnTypeDescriptor()
        {
            return "information about the customer added to the table bill as";
        }

        protected override bool IsCorrectReturnType(OperationDetail operationDetail)
        {
            foreach (var response in operationDetail.Responses)
            {
                var details = response.Value;
                if (!string.Equals(details.Description, "success", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                if (details.Schema?.Type == "array")
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(details.Schema?.Ref))
                {
                    continue;
                }

                return true;
            }
            return false;
        }

        protected override bool IsCorrectMethod(KeyValuePair<string, OperationDetail> item)
        {
            return string.Equals("put", item.Key, StringComparison.InvariantCultureIgnoreCase) || string.Equals("post", item.Key, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}