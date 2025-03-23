namespace Src;

public class Floor
{
    private readonly int _floorNumber;
    private readonly IList<Spot> _spots;

    public Floor(int floorNumber, int numberOfSpots, int carPercent, int bikePercent)
    {
        _floorNumber = floorNumber;
        _spots = new  List<Spot>(numberOfSpots);
        
        var carSpots = (int) (numberOfSpots * ((double)carPercent / 100));
        var bikeSpots = (int) (numberOfSpots * ((double)bikePercent / 100));
        var truckSpots = numberOfSpots - (carSpots + bikeSpots);

        for (int i = 1; i <= carSpots; i++)
        {
            _spots.Add(new Spot(i, VehicleType.CAR));
        }
        
        for (int i = carSpots + 1; i <= carSpots+bikeSpots; i++)
        {
            _spots.Add(new Spot(i, VehicleType.BIKE));
        }
        
        for (int i = carSpots + bikeSpots + 1; i <= numberOfSpots; i++)
        {
            _spots.Add(new Spot(i, VehicleType.TRUCK));
        }
    }

    public bool ParkVehicle(BaseVehicle vehicle)
    {
        lock (_spots)
        {
            foreach (var spot in _spots)
            {
                if (spot.IsVacant() && spot.GetVehicleType().Equals(vehicle.VehicleType))
                {
                    spot.ParkVehicle(vehicle);
                    return true;
                }
            }
        }
        return false;
    }
    
    public bool UnParkVehicle(BaseVehicle vehicle)
    {
        lock (_spots)
        {
            foreach (var spot in _spots)
            {
                if (!spot.IsVacant() && spot.GetVehicleLicensePlate().Equals(vehicle.LicensePlate))
                {
                    spot.UnparkVehicle();
                    return true;
                }
            }
        }
        return false;
    }
    
    public void DisplayAvailability()
    {
        Console.WriteLine($"Level {_floorNumber} Availability:");
        foreach (var spot in _spots)
        {
            Console.WriteLine($"Spot {spot.GetSpotNumber()}: {(spot.IsVacant() ? $"Vacant For {spot.GetVehicleType()}" : $"Occupied By {spot.GetVehicleType()} - {spot.GetVehicleLicensePlate()}")}");
        }
    }
    
}