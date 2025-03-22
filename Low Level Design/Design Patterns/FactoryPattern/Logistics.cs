namespace FactoryPattern;

public interface ILogistics
{
    void DoDelivery();
}

public class TruckLogistics : ILogistics
{
    public void DoDelivery()
    {
        Console.WriteLine("Truck going out on delivery");
    }
}

public class CarLogistics : ILogistics
{
    public void DoDelivery()
    {
        Console.WriteLine("Car going out on delivery");
    }
}

public class TempoLogistics : ILogistics
{
    public void DoDelivery()
    {
        Console.WriteLine("Tempo going out on delivery");
    }
}

public class ShipLogistics : ILogistics
{
    public void DoDelivery()
    {
        Console.WriteLine("Ship going out on delivery");
    }
}

public class SubmarineLogistics : ILogistics
{
    public void DoDelivery()
    {
        Console.WriteLine("Sumbmarine going out on delivery");
    }
}
