using System;

namespace SP19.P05.Web.Features.Tables
{
    public class TableBillDto
    {
        public int Id { get; set; }
        public DateTimeOffset StartDateUtc { get; set; }
        public DateTimeOffset? EndDateUtc { get; set; }
        public int TableId { get; set; }
    }
}