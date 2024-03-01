using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockJobsScheduler.DAL;
using StockJobsScheduler.Services;

namespace StockJobsScheduler
{
    public class Program
    {
        private static IConfiguration? _iconfiguration;
        private readonly IEmailService _emailService;

        public Program(IEmailService emailService, IConfiguration configuration)
        {
            _emailService = emailService;
            _iconfiguration = configuration;
        }

        static void Main(string[] args)
        {
            // Set up configuration

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddScoped<IEmailService, EmailService>()
                .AddSingleton(configuration)
                .AddTransient<Program>()
                .BuildServiceProvider();

            var program = serviceProvider.GetRequiredService<Program>();

            //program._emailService.SendEmailAsync("tseko.saule@dreamresorts.co.za", "12 Months stock");

            var stockDAL = new StockDAL(configuration, program._emailService);
            //stockDAL.SendMail();
            Console.WriteLine("Fetching 12 Months expiry stock...");
            Console.WriteLine("");
            stockDAL.Execute12MonthsList();
            Console.WriteLine("Fetching 6 Months expiry stock...");
            Console.WriteLine("");
            stockDAL.Execute6MonthsList();
            Console.WriteLine("Fetching 1 Months expiry stock...");
            Console.WriteLine("");
            stockDAL.Execute1MonthsList();
            Console.WriteLine("Fetching expired stock...");
            Console.WriteLine("");
            stockDAL.ExecuteCurrentXpiredList();
            Console.WriteLine("Done");
        }
    }
}