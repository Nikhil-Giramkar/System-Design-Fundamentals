namespace FactoryPattern;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello Factory Guys...");
        char choice = 'y';
       do
       {
        Console.WriteLine("\nSend Package by Road or Sea ?");
        var way = Console.ReadLine();

        if(way.Equals("road", StringComparison.InvariantCultureIgnoreCase))
        {
           Console.WriteLine("Send Package by Car, Truck or Tempo ?");
           var vehicle = Console.ReadLine();
           var roadFactory = new RoadLogisticsFactory();
           roadFactory.PlanDelivery(vehicle);
        }
        else 
        {
            Console.WriteLine("Send Package by Ship or Submarine ?");
           var vehicle = Console.ReadLine();
           var seaFactory = new SeaLogigsticsFactory();
           seaFactory.PlanDelivery(vehicle);
        }

        Console.WriteLine("Do you want to continue y/n ? ");
        choice = Console.ReadKey().KeyChar; // to read single character
       } while(choice == 'y');
    }
}