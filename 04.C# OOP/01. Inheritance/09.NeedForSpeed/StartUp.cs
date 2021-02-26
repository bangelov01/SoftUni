namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Motorcycle motor = new Motorcycle(100, 300);

            motor.Drive(20);

            FamilyCar car = new FamilyCar(200, 200);

            car.Drive(20);
            
        }
    }
}
