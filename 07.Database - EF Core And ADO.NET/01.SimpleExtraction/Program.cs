using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _01.SimpleExtractions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Server=.;Database=SoftUni;User Id=sa;Password=1Qazwsxedc;");

            await con.OpenAsync();

            using (con)
            {
                Console.WriteLine(await GetTopEmployee(con));
                Console.WriteLine(string.Join("\r\n", await GetEmployeesInfo(con)));
            }

            //if (con.State == System.Data.ConnectionState.Closed )
            //{
            //    Console.WriteLine("Connection is closed!");
            //} else
            //{
            //    Console.WriteLine("Connection is open!");
            //}

            static async Task<string> GetTopEmployee(SqlConnection con)
            {
                string result = string.Empty;

                SqlCommand command = new SqlCommand("SELECT TOP(1) FirstName FROM Employees ORDER BY Salary DESC", con);
                result = (string)await command.ExecuteScalarAsync();

                return result;
            }

            static async Task<List<string>> GetEmployeesInfo(SqlConnection con)
            {
                var result = new List<string>();

                SqlCommand command = new SqlCommand("SELECT * FROM Employees", con);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                using (reader)
                {
                    while (await reader.ReadAsync())
                    {
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        decimal salary = (decimal)reader["Salary"];

                        string concat = $"{firstName} -- {lastName} -- {salary}";
                        result.Add(concat);
                    }
                }
                return result;
            }
        }
    }
}

