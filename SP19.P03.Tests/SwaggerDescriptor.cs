using System.Collections.Generic;

namespace SP19.P03.Tests
{
    public class SwaggerDescriptor
    {
        public string Swagger { get; set; }
        public IDictionary<string, Operation> Paths { get; set; }
    }
}