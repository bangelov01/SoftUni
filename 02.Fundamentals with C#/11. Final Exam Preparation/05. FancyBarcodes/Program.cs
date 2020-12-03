using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            string barcodePattern = @"^([@]{1}[#]+)([A-Z][A-Za-z0-9]{4,}[A-Z])([@]{1}[#]+)$";
            string numPattern = @"[\d]";

            while (numOfLines > 0)
            {
                string barcode = Console.ReadLine();
                Match barcodeMatch = Regex.Match(barcode, barcodePattern);

                if (barcodeMatch.Success)
                {
                    string group = string.Empty;
                    MatchCollection numbers = Regex.Matches(barcode, numPattern);
                    if (numbers.Count > 0)
                    {
                        foreach (Match item in numbers)
                        {
                            group += item.Value;
                        }
                        Console.WriteLine($"Product group: {group}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }

                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }

                numOfLines--;
            }

        }
    }
}
