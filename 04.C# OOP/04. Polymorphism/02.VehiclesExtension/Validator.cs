using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public static class Validator
    {
        public static void ThrowIfFuelIsTooMuch(double amount, double tankCapacity)
        {
            if (amount > tankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }
        }

        public static void ThrowIfAmountLessOrEqualToZero(double quantity, string message)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
