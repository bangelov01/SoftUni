using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.BakedFoods.Foods;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Drinks.Drinks;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Tables.TableModels;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            totalIncome = 0;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink newDrink = null;

            if (DrinkType.Tea.ToString() == type)
            {
                newDrink = new Tea(name, portion, brand);
            }
            else if (DrinkType.Water.ToString() == type)
            {
                newDrink = new Water(name, portion, brand);
            }

            drinks.Add(newDrink);

            return string.Format(OutputMessages.DrinkAdded, newDrink.Name, newDrink.Brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood newFood = null;

            if (BakedFoodType.Bread.ToString() == type)
            {
                newFood = new Bread(name, price);
            }
            else if (BakedFoodType.Cake.ToString() == type)
            {
                newFood = new Cake(name, price);
            }

            bakedFoods.Add(newFood);

            return string.Format(OutputMessages.FoodAdded, newFood.Name, newFood.GetType().Name);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable newTable = null;

            if (TableType.InsideTable.ToString() == type)
            {
                newTable = new InsideTable(tableNumber, capacity);
            }
            else if (TableType.OutsideTable.ToString() == type)
            {
                newTable = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(newTable);

            return string.Format(OutputMessages.TableAdded, newTable.TableNumber);

        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(t => t.IsReserved == false);

            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.Find(t => t.TableNumber == tableNumber);

            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();

            string result = $"Table: {table.TableNumber}"
                + Environment.NewLine
                + $"Bill: {bill:f2}";

            return result;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink,drinkName,drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName); ;
            }

            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, food.Name);

        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible,numberOfPeople);
            }

            freeTable.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
        }
    }
}
