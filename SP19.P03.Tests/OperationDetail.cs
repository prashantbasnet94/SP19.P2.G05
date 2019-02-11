using System.Collections.Generic;

namespace SP19.P03.Tests
{
    public class OperationDetail
    {
        public List<ParameterDetail> Parameters { get; set; }
        public string OperationId { get; set; }
        public Dictionary<string, ResponseDetail> Responses { get; set; }
    }
}