using Microsoft.Extensions.Configuration;
using StockJobsScheduler.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockJobsScheduler.DAL
{
    public class StockDAL
    {
        private string? _connectionString;

        private readonly IEmailService _emailService;

        /// <summary>
        /// StockDAL
        /// </summary>
        /// <param name="iconfiguration"></param>
        /// <param name="emailService"></param>
        public StockDAL(IConfiguration iconfiguration, IEmailService emailService)
        {
            //_connectionString = iconfiguration.GetConnectionString("DefaultConnection");
            _connectionString = @"Server=BLACKPEARL;Database=SynergyDB;User Id=sa;Password=Dr#@mdream;TrustServerCertificate=True";
            _emailService = emailService;
        }

        /// <summary>
        /// GET 12 MONTHS LIST, THEN SEND MAIL/SMS
        /// </summary>
        /// <returns></returns>
        public async Task Execute12MonthsList()
        {
            List<Dictionary<string, string>> stock = new List<Dictionary<string, string>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand myCommand =
                        new SqlCommand("SELECT St.ID, Sy.FirstName, Sy.LastName, St.ExpiryDate, St.IDResort, St.IDStockType, St.UnitNumber, St.CancelDate, Sy.UserId, Sy.Email " +
                                        "FROM[SynergyDB].[dbo].[Stock] St INNER JOIN[SynergyDB].[dbo].[SynergyUsers] Sy " +
                                        "ON Sy.UserId = St.IDUser " +
                                        "WHERE DATEADD(MONTH, 12, CONVERT(date,GETDATE())) = ExpiryDate;", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = myCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, string> record = new Dictionary<string, string>();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string columnName = reader.GetName(i);
                                    string columnValue = reader[i].ToString();

                                    record.Add(columnName, columnValue);
                                }

                                stock.Add(record);

                            }
                            reader.Close();
                        }
                    }
                }

                foreach (var record in stock)
                {
                    Console.WriteLine("Record:");

                    foreach (var kvp in record)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                    //TODO : Remomber to change the email to record["Email"] on GO LIVE Day
                    await _emailService.SendEmailAsync("tseko.saule@dreamresorts.co.za", "12 Months to Expiry Date", record["FirstName"], record["ExpiryDate"]);
                    Console.WriteLine(); // Add a blank line between records for better readability
                }
            }
            catch
            {
                throw;
            }

            //return Task.CompletedTask;
        }

        /// <summary>
        /// GET 6 MONTHS LIST, THEN SEND MAIL/SMS
        /// </summary>
        /// <returns></returns>

        public async Task Execute6MonthsList()
        {
            List<Dictionary<string, string>> stock = new List<Dictionary<string, string>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand myCommand =
                            new SqlCommand("SELECT St.ID,  Sy.FirstName, Sy.LastName, St.ExpiryDate, St.IDResort, St.IDStockType, St.UnitNumber, St.CancelDate, Sy.UserId, Sy.Email " +
                                            "FROM[SynergyDB].[dbo].[Stock] St INNER JOIN[SynergyDB].[dbo].[SynergyUsers] Sy " +
                                            "ON Sy.UserId = St.IDUser " +
                                            "WHERE DATEADD(MONTH, 6, CONVERT(date,GETDATE())) = ExpiryDate;", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = myCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, string> record = new Dictionary<string, string>();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string columnName = reader.GetName(i);
                                    string columnValue = reader[i].ToString();

                                    record.Add(columnName, columnValue);
                                }

                                stock.Add(record);

                            }
                            reader.Close();
                        }
                    }
                }

                foreach (var record in stock)
                {
                    Console.WriteLine("Record:");

                    foreach (var kvp in record)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }

                    //TODO : Remomber to change the email to record["Email"] on GO LIVE Day
                    await _emailService.SendEmailAsync("tseko.saule@dreamresorts.co.za", "6 Months to Expiry Date", record["FirstName"], record["ExpiryDate"]);
                    Console.WriteLine(); // Add a blank line between records for better readability
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GET 1 MONTHS LIST, THEN SEND MAIL/SMS
        /// </summary>
        /// <returns></returns>
        public async Task Execute1MonthsList()
        {
            List<Dictionary<string, string>> stock = new List<Dictionary<string, string>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand myCommand =
                            new SqlCommand("SELECT St.ID, Sy.FirstName, Sy.LastName, St.ExpiryDate, St.IDResort, St.IDStockType, St.UnitNumber, St.CancelDate, Sy.UserId, Sy.Email " +
                                            "FROM[SynergyDB].[dbo].[Stock] St INNER JOIN [SynergyDB].[dbo].[SynergyUsers] Sy " +
                                            "ON Sy.UserId = St.IDUser " +
                                            "WHERE DATEADD(MONTH, 1, CONVERT(date,GETDATE())) = ExpiryDate;", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = myCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, string> record = new Dictionary<string, string>();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string columnName = reader.GetName(i);
                                    string columnValue = reader[i].ToString();

                                    record.Add(columnName, columnValue);
                                }

                                stock.Add(record);
                            }
                            reader.Close();
                        }
                    }
                }

                foreach (var record in stock)
                {
                    Console.WriteLine("Record:");

                    foreach (var kvp in record)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }

                    //TODO : Remomber to change the email to record["Email"] on GO LIVE Day
                    await _emailService.SendEmailAsync("tseko.saule@dreamresorts.co.za", "1 Month to Expiry Date", record["FirstName"], record["ExpiryDate"]);
                    Console.WriteLine();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GET CURRENT EXPIRED MONTHS LIST, THEN SEND MAIL/SMS AND UPDATE
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteCurrentXpiredList()
        {
            List<Dictionary<string, string>> stock = new List<Dictionary<string, string>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand myCommand =
                        new SqlCommand("SELECT St.ID, Sy.FirstName, Sy.LastName, St.ExpiryDate, St.IDResort, St.IDStockType, St.UnitNumber, St.CancelDate, Sy.UserId, Sy.Email " +
                                        "FROM[SynergyDB].[dbo].[Stock] St INNER JOIN[SynergyDB].[dbo].[SynergyUsers] Sy " +
                                        "ON Sy.UserId = St.IDUser " +
                                        "WHERE CONVERT(date,GETDATE()) = ExpiryDate;", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = myCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, string> record = new Dictionary<string, string>();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string columnName = reader.GetName(i);
                                    string columnValue = reader[i].ToString();

                                    record.Add(columnName, columnValue);
                                    //Update the CancelDate field to current date
                                    UpdateStock(reader.GetInt32(0));
                                }

                                stock.Add(record);

                            }
                            reader.Close();
                        }
                    }
                }

                foreach (var record in stock)
                {
                    Console.WriteLine("Record:");

                    foreach (var kvp in record)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }

                    //TODO : Remomber to change the email to record["Email"] on GO LIVE Day
                    await _emailService.SendEmailAsync("tseko.saule@dreamresorts.co.za", "Stock Expired", record["FirstName"], record["ExpiryDate"]);
                    Console.WriteLine();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update the stock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Task UpdateStock(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand ErrCmd = new SqlCommand($"UPDATE [Stock] SET CancelDate = CONVERT(DATE, GETDATE()) WHERE id = {id}" + ';', con))
                    {
                        con.Open();
                        ErrCmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch
            {
                throw;
            }

            return Task.CompletedTask;
        }
    }

}
