using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StockJobsScheduler.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string consultant, string Expirydate);
    }
}
