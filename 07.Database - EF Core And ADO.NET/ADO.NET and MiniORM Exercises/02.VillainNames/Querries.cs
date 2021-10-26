using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VillainNames
{
    public static class Querries
    {
        public static string GET_VILLAIN_NAMES_QUERRY = @"
        SELECT v.[Name]
               ,COUNT(mv.VillainId) AS MinionsCount
        FROM Villains AS v
            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
        GROUP BY v.Id, v.[Name]
        HAVING COUNT(mv.VillainId) > 3
        ORDER BY COUNT(mv.VillainId)";
    }
}
