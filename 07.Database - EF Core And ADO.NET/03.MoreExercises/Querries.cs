using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MoreExercises
{
    public static class Querries
    {
        public static string VILLAIN_NAME_QUERRY = @"
            SELECT [Name] 
            FROM Villains 
            WHERE Id = @Id";

        public static string MINIONS_FOR_GIVEN_VILLAIN = @"
            SELECT ROW_NUMBER() OVER (ORDER BY m.[Name]) as RowNum
                   ,m.[Name]
                   ,m.Age
            FROM MinionsVillains AS mv
                JOIN Minions As m ON mv.MinionId = m.Id
            WHERE mv.VillainId = @Id
            ORDER BY m.[Name]";

        public static string GET_VILLAIN_ID_BY_NAME = @"SELECT Id FROM Villains WHERE [Name] = @Name";

        public static string GET_MINION_ID_BY_NAME = @"SELECT Id FROM Minions WHERE [Name] = @Name";

        public static string GET_TOWN_ID_BY_NAME = @"SELECT Id FROM Towns WHERE [Name] = @townName";

        public static string INSERT_TOWN_WITH_NAME = @"INSERT INTO Towns ([Name]) VALUES (@townName)";

        public static string INSERT_VILLAIN_WITH_NAME_AND_EVIL_FACTOR = @"INSERT INTO Villains ([Name], EvilnessFactorId)  VALUES (@villainName, 4)";

        public static string INSERT_MINION_WITH_NAME_AGE_TOWNID = @"INSERT INTO Minions ([Name], Age, TownId) VALUES (@name, @age, @townId)";

        public static string INSERT_DEPENDANCY_MINION_VILLAIN = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
    }
}
