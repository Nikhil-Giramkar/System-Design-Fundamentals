namespace Src;

public sealed class ParkingLot
{
    private readonly List<Floor> _floors;
    private ParkingLot()
    {
        _floors = new List<Floor>();
    }
    
    private static ParkingLot _instance;
    private static readonly object _lockObject = new object();
    
    public static ParkingLot GetInstance()
    {
        if (_instance == null)
        {
            lock (_lockObject)
            {
                if (_instance == null)
                {
                    _instance = new ParkingLot();
                }
            } 
        }
        return _instance;
    }

    public void AddFloor(Floor floor)
    {
        _floors.Add(floor);
    }
    
    public bool ParkVehicle(BaseVehicle vehicle)
    {
        foreach (var level in _floors)
        {
            if (level.ParkVehicle(vehicle))
            {
                Console.WriteLine($"{vehicle.VehicleType} parked successfully.");
                return true;
            }
        }
        Console.WriteLine("Could not park vehicle.");
        return false;
    }
    
    public bool UnParkVehicle(BaseVehicle vehicle)
    {
        foreach (var level in _floors)
        {
            if (level.UnParkVehicle(vehicle))
            {
                Console.WriteLine($"{vehicle.VehicleType} removed from parking spot");
                return true;
            }
        }
        return false;
    }

    public void DisplayAvailability()
    {
        Console.WriteLine("-----------------------------------------");
        foreach (var level in _floors)
        {
            level.DisplayAvailability();
        }
    }
}