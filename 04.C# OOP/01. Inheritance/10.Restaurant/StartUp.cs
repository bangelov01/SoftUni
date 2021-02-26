namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("ChocoWorld");

            System.Console.WriteLine(cake.Calories);
            System.Console.WriteLine(cake.Price);
            System.Console.WriteLine(cake.Grams);
            System.Console.WriteLine(cake.Name);
        }
    }
}