using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03.MoreExercises
{
    public class Startup
    {
        static async Task Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection(Config.CONNECTION_STRING);

            await dbConnection.OpenAsync();

            await using (dbConnection)
            {
                //await MinionNamesExercise(dbConnection);
                //await AddMinionExercise(dbConnection);
                //await ChangeTownNamesExercise(dbConnection);
                await PrintAllMinionNamesInOrder(dbConnection);
            }

            //Double check connection
            if (dbConnection.State == System.Data.ConnectionState.Closed)
            {
                Console.WriteLine("Connection is closed!");
            }
            else
            {
                Console.WriteLine("Connection is open!");
            }
        }


        //Minion Names Exercise Methods
        private static async Task MinionNamesExercise(SqlConnection connection)
        {
            Console.WriteLine("Exercise One: Please enter villain Id!");
            int villainId = int.Parse(Console.ReadLine());

            await GetMinionNamesForVillain(connection, villainId);
        }

        private static async Task GetMinionNamesForVillain(SqlConnection connection, int villainId)
        {
            SqlCommand villainNameCmd = new SqlCommand(Querries.VILLAIN_NAME_QUERRY,connection);

            villainNameCmd.Parameters.AddWithValue("@Id", villainId);

            var result = await villainNameCmd.ExecuteScalarAsync();

            if (result != null)
            {
                Console.WriteLine($"Villain: {(string)result}");

                SqlCommand minionsInfoCmd = new SqlCommand(Querries.MINIONS_FOR_GIVEN_VILLAIN, connection);

                minionsInfoCmd.Parameters.AddWithValue("@Id", villainId);

                SqlDataReader dataReader = await minionsInfoCmd.ExecuteReaderAsync();

                await using (dataReader)
                {
                    while (await dataReader.ReadAsync())
                    {
                        long rowNumber = (long)dataReader["RowNum"];
                        string name = (string)dataReader["Name"];
                        int age = (int)dataReader["Age"];

                        Console.WriteLine($"{rowNumber}. {name} {age}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
        }

        //Add Minions Exercise Methods

        private static async Task AddMinionExercise(SqlConnection connection)
        {
            Console.WriteLine("Exercise Two: Enter Minion name, age and town!");
            string[] minionInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Console.WriteLine("Enter villain name!");
            string villainName = Console.ReadLine().Trim();

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string townName = minionInfo[2];

            await AddMinionToVillain(connection, villainName, minionName, minionAge, townName);
        }

        private static async Task AddMinionToVillain (SqlConnection connection, string villainName, string minionName, int minionAge, string townName)
        {
            await ManageTown(connection, townName);
            await ManageVillain(connection, villainName);
            await ManageMinion(connection, minionName, minionAge, townName, villainName);
        }

        private static async Task ManageVillain (SqlConnection connection,  string villainName)
        {
            SqlCommand cmd = new SqlCommand(Querries.GET_VILLAIN_ID_BY_NAME, connection);
            cmd.Parameters.AddWithValue("@name", villainName);

            var result = await cmd.ExecuteScalarAsync();

            if (result == null)
            {
                SqlCommand insertVillain = new SqlCommand(Querries.INSERT_VILLAIN_WITH_NAME_AND_EVIL_FACTOR, connection);

                insertVillain.Parameters.AddWithValue("@villainName", villainName);

                await insertVillain.ExecuteNonQueryAsync();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
        }

        private static async Task ManageTown (SqlConnection connection, string townName)
        {
            SqlCommand cmd = new SqlCommand(Querries.GET_TOWN_ID_BY_NAME, connection);
            cmd.Parameters.AddWithValue("@townName", townName);

            var result = await cmd.ExecuteScalarAsync();

            if (result == null)
            {
                SqlCommand insertTown = new SqlCommand(Querries.INSERT_TOWN_WITH_NAME, connection);

                insertTown.Parameters.AddWithValue("@townName", townName);

                await insertTown.ExecuteNonQueryAsync();
                Console.WriteLine($"Town {townName} was added to the database.");
            }
        }

        private static async Task ManageMinion (SqlConnection connection, string minionName, int minionAge, string townName, string villainName)
        {
            SqlCommand getTownCmd = new SqlCommand(Querries.GET_TOWN_ID_BY_NAME, connection);
            getTownCmd.Parameters.AddWithValue("@townName", townName);

            int townId = (int)await getTownCmd.ExecuteScalarAsync();

            SqlCommand insertMinionCmd = new SqlCommand(Querries.INSERT_MINION_WITH_NAME_AGE_TOWNID, connection);
            insertMinionCmd.Parameters.AddWithValue("@name", minionName);
            insertMinionCmd.Parameters.AddWithValue("@age", minionAge);
            insertMinionCmd.Parameters.AddWithValue("@townId", townId);

            await insertMinionCmd.ExecuteNonQueryAsync();

            SqlCommand getMinionId = new SqlCommand(Querries.GET_MINION_ID_BY_NAME, connection);
            getMinionId.Parameters.AddWithValue("@name", minionName);
            int minionId = (int)await getMinionId.ExecuteScalarAsync();

            SqlCommand getVillainId = new SqlCommand(Querries.GET_VILLAIN_ID_BY_NAME, connection);
            getVillainId.Parameters.AddWithValue("@name", villainName);
            int villainId = (int)await getVillainId.ExecuteScalarAsync();

            SqlCommand dependancyCmd = new SqlCommand(Querries.INSERT_DEPENDANCY_MINION_VILLAIN, connection);
            dependancyCmd.Parameters.AddWithValue("@minionId", minionId);
            dependancyCmd.Parameters.AddWithValue("@villainId", villainId);

            await dependancyCmd.ExecuteNonQueryAsync();

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        //Change Town Names Exercise
        private static async Task ChangeTownNamesExercise(SqlConnection connection)
        {
            Console.WriteLine("Exercise Three: Please enter country name!");
            string countryName = Console.ReadLine().Trim();

            await ManageTowns(connection, countryName);
        }

        private static async Task ManageTowns (SqlConnection connection, string countryName)
        {
            List<string> townsToChange = new List<string>();

            SqlCommand getTownsCommand = new SqlCommand(Querries.GET_TOWNS_FOR_COUNTRY_BY_NAME, connection);
            getTownsCommand.Parameters.AddWithValue("@countryName", countryName);

            SqlDataReader reader = await getTownsCommand.ExecuteReaderAsync();

            await using (reader)
            {
                if (await reader.ReadAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string townName = (string)reader["Name"];
                        townsToChange.Add(townName);
                    }
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }
            }

            SqlCommand updateTownCmd = new SqlCommand(Querries.UPDATE_TOWNS_NAMES, connection);
            updateTownCmd.Parameters.AddWithValue("@countryName",countryName);
            await updateTownCmd.ExecuteNonQueryAsync();

            townsToChange = townsToChange.ConvertAll(t => t.ToUpper());
            Console.WriteLine($"{townsToChange.Count} town names were affected.\r\n[{string.Join(',', townsToChange)}]");
        }

        //Print All Minion Names Exercise

        private static async Task PrintAllMinionNamesInOrder(SqlConnection connection)
        {

            List<string> namesList = new List<string>();

            SqlCommand getNames = new SqlCommand(Querries.GET_ALL_MINIONS_NAMES, connection);

            SqlDataReader reader = await getNames.ExecuteReaderAsync();

            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    string name = (string)reader["Name"];

                    namesList.Add(name);
                }
            }

            List<string> finalOrder = new List<string>();

            int index = 0;

            while (finalOrder.Count < namesList.Count)
            {
                string first = namesList[0 + index];
                string last = namesList[(namesList.Count - 1) - index];

                if (first == last)
                {
                    finalOrder.Add(first);
                    break;
                }

                finalOrder.Add(first);
                finalOrder.Add(last);
                index++;
            }

            Console.WriteLine(string.Join(",", finalOrder));
        }
    }
}
