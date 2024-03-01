using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockJobsScheduler.Model
{
    public partial class Stock
    {
        public int Id { get; set; }
        public DateTime? Dt { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public string? Idresort { get; set; }
        public int? IdstockType { get; set; }
        public string? UnitNumber { get; set; }
        public string? ResortWeek { get; set; }
        public string? WeekSize { get; set; }
        public int? Shares { get; set; }
        public string? ShareBlockReference { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public bool? Active { get; set; }
        public DateTime? CancelDate { get; set; }
        public string? IdcalendarType { get; set; }
        public int? Iduser { get; set; }
    }
}
