using _08.MilitaryElite.Contracts;
using _08.MilitaryElite.Models;
using _08.MilitaryElite.Models.Enums;
using _08.MilitaryElite.Models.SoldierModels;
using System;
using System.Collections.Generic;

namespace _08.MilitaryElite
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = commandArr[0];
                string id = commandArr[1];
                string firstName = commandArr[2];
                string lastName = commandArr[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(commandArr[4]);
                    soldiersById[id] = new Private(id, firstName, lastName, salary);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(commandArr[4]);
                    ILieutenantGeneral ltGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < commandArr.Length; i++)
                    {
                        string privateId = commandArr[i];

                        if (!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }

                        ltGeneral.AddPrivate((Private)soldiersById[privateId]);
                    }

                    soldiersById[id] = ltGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(commandArr[4]);

                    bool isCorpsValid = Enum.TryParse(commandArr[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < commandArr.Length; i += 2)
                    {
                        string partName = commandArr[i];
                        int hoursWorked = int.Parse(commandArr[i + 1]);

                        IRepair repair = new Repair(partName, hoursWorked);
                        engineer.AddRepair(repair);
                    }

                    soldiersById[id] = engineer;
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(commandArr[4]);

                    bool isCorpsValid = Enum.TryParse(commandArr[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < commandArr.Length; i += 2)
                    {
                        string codeName = commandArr[i];
                        string state = commandArr[i + 1];

                        bool isStateValid = Enum.TryParse(state, out State missionSatate);

                        if (!isStateValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, missionSatate);

                        commando.AddMission(mission);
                    }

                    soldiersById[id] = commando;

                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(commandArr[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = spy;
                }
            }

            foreach (var soldier in soldiersById)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
