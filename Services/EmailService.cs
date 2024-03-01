using System.Net.Mail;

namespace StockJobsScheduler.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string consultant, string Expirydate)
        {
            //// Construct the full file path
            string solutionPath = GetSolutionPath();
            string htmlFile = string.Empty;

            if (subject == "Stock Expired")
                htmlFile = "ExpiredStockMail.html";
            else
                htmlFile = "NotifyConsultant.html";

            string filePath = Path.Combine(solutionPath, "Templates", htmlFile);

            string messageBody = string.Empty;

            using (SmtpClient client = new SmtpClient("za-smtp-outbound-1.mimecast.co.za", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("dvcwebsite@dreamvacs.com", "Dre@mwebsite123");

                client.EnableSsl = true;
                MailMessage email = new MailMessage("dvcwebsite@dreamvacs.com", toEmail);
                email.Subject = subject;

                //var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "templates", "ticketreply.html");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    messageBody = sr.ReadToEnd();
                }
                email.Body = messageBody.Replace("XXXXX", consultant).Replace("DDDDD", Expirydate);
                email.IsBodyHtml = true;
                await client.SendMailAsync(email);
            }
        }

        static string GetSolutionPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            while (currentDirectory != null)
            {
                string solutionFilePath = Path.Combine(currentDirectory, "*.sln");

                string[] solutionFiles = Directory.GetFiles(currentDirectory, "*.sln");

                if (solutionFiles.Length > 0)
                {
                    return currentDirectory;
                }

                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }

            return "";
        }
    }

}
