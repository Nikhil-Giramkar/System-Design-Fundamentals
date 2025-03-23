// See https://aka.ms/new-console-template for more information

using Src;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("Parking Lot LLD");

        var parkingLot = ParkingLot.GetInstance();
        
        parkingLot.AddFloor(new Floor(1, 5, 60, 40));
        parkingLot.AddFloor(new Floor(2, 5, 70, 20));
        
        parkingLot.DisplayAvailability();
        
        var truck = new  Truck("MH-12-AR-1234");
        parkingLot.ParkVehicle(truck);

        var bike = new Bike("DL-03-PS-5432");
        parkingLot.ParkVehicle(bike);
        
        parkingLot.DisplayAvailability();
        
        var bike2 = new Bike("KL-03-RT-9832");
        parkingLot.ParkVehicle(bike2);
        parkingLot.DisplayAvailability();
        
        var bike3 = new Bike("JK-04-PS-4567");
        parkingLot.ParkVehicle(bike3);
        parkingLot.DisplayAvailability();

        parkingLot.UnParkVehicle(bike2);
        parkingLot.DisplayAvailability();
    }
}