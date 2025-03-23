namespace Src;

public class Spot
{
    private readonly int _spotNumber;
    private readonly VehicleType _vehicleType;
    private BaseVehicle _vehicle;

    public Spot(int spotNumber, VehicleType vehicleType)
    {
        _spotNumber = spotNumber;
        _vehicleType = vehicleType;
    }

    public bool IsVacant()
    {
        return _vehicle == null;
    }

    public void ParkVehicle(BaseVehicle vehicle)
    {
        if (vehicle.VehicleType != _vehicleType)
        {
            throw new Exception("Vehicle type doesn't match");
        }
        if (!IsVacant())
        {
            throw new Exception("Spot is not Vacant");
        }
        _vehicle = vehicle;
    }

    public void UnparkVehicle()
    {
        _vehicle = null;
    }
    
    public VehicleType GetVehicleType()
    {
        return _vehicleType;
    }
    
    public string GetVehicleLicensePlate()
    {
        return _vehicle.LicensePlate;
    }

    public int GetSpotNumber()
    {
        return _spotNumber;
    }
    
}