using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockJobsScheduler.Model
{
    public class SendingMailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string TriggeredEvent { get; set; }
        public long? CreatedBy { get; set; }
    }
}
