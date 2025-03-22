namespace FactoryPattern;
/*
-----------------------------------------------------
            FACTORY PATTERN
-----------------------------------------------------
The Factory pattern (both Factory Method and Abstract Factory) 
is a powerful creational design pattern with several practical applications.

1. It allows you to write code that depends on abstract interfaces or base classes rather than concrete classes. 
This makes your code more flexible, maintainable, and testable.
Example: A UI framework that creates platform-specific UI elements (buttons, text boxes) 
without the client code knowing the exact implementation.

2. The Factory pattern encapsulates the object creation logic in a single place. 
This makes it easier to manage and modify the object creation process.
Example: A logging system that creates different types of loggers 
(file loggers, database loggers) based on configuration settings.

3. The Factory pattern makes it easy to add new object types without modifying existing client code. 
This adheres to the Open/Closed Principle.
Example: A payment processing system that adds new payment methods (credit card, PayPal, etc.) 
without changing the core payment logic.

4. By decoupling client code from concrete implementations, the Factory pattern makes it easier to write unit tests. 
You can easily mock or stub the factory to create test objects.

*/
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