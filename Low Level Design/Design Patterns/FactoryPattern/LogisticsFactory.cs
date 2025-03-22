namespace FactoryPattern;

//creator abstract class
public abstract class ILogisticsFactory
{
    //key part - factory method that will be enforced on concrete factories, will not be exposed to client
    protected abstract ILogistics CreateLogistics(string vehicleType);

    //default implementation for all factories, that will be exposed to client
    public void PlanDelivery(string vehicleType) 
    {
        var vehicle = CreateLogistics(vehicleType);
        vehicle.DoDelivery();
    }
}

public class RoadLogisticsFactory : ILogisticsFactory
{
    protected override ILogistics CreateLogistics(string vehicleType)
    {
        return vehicleType switch
        {
            "Car" => new CarLogistics(),
            "Truck" => new TruckLogistics(),
            _ => new TempoLogistics(),
        };
    }
}

public class SeaLogigsticsFactory : ILogisticsFactory
{
    protected override ILogistics CreateLogistics(string vehicleType)
    {
        if(vehicleType == "Ship"){
            return new ShipLogistics();
        }

        return new SubmarineLogistics();
    }
}
