using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _02.VillainNames
{
    public class Startup
    {
        static async Task Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection(Config.CONNECTION_STRING);

            await dbConnection.OpenAsync();

            await using (dbConnection)
            {
                SqlCommand command = new SqlCommand(Querries.GET_VILLAIN_NAMES_QUERRY, dbConnection);

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                await using (dataReader)
                {
                    while (await dataReader.ReadAsync())
                    {
                        string name = (string)dataReader["Name"];
                        int minionsCount = (int)dataReader["MinionsCount"];

                        Console.WriteLine($"{name} - {minionsCount}");
                    }
                }
            }
        }
    }
}
