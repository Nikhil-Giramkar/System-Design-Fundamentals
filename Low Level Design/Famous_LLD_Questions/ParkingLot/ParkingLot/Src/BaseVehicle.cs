namespace Src;

public abstract class BaseVehicle
{
    public string LicensePlate { get; set; }
    public VehicleType VehicleType { get; set; }

    protected BaseVehicle(string licensePlate, VehicleType vehicleType)
    {
        LicensePlate = licensePlate;
        VehicleType = vehicleType;
    }
}