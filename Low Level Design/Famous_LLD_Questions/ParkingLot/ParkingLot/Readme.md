# Designing a Parking Lot System
## Requirements
The parking lot should have multiple levels, each level with a certain number of parking spots.<br>
The parking lot should support different types of vehicles, such as cars, motorcycles, and trucks.<br>
Each parking spot should be able to accommodate a specific type of vehicle.<br>
The system should assign a parking spot to a vehicle upon entry and release it when the vehicle exits.<br>
The system should track the availability of parking spots and provide real-time information to customers.<br>
The system should handle multiple entry and exit points and support concurrent access.<br>

## Classes, Interfaces and Enumerations
The ParkingLot class follows the Singleton pattern to ensure only one instance of the parking lot exists. It maintains a list of levels and provides methods to park and unpark vehicles.<br>
The Level class represents a level in the parking lot and contains a list of parking spots. It handles parking and unparking of vehicles within the level.<br>
The ParkingSpot class represents an individual parking spot and tracks the availability and the parked vehicle.<br>
The Vehicle class is an abstract base class for different types of vehicles. It is extended by Car, Motorcycle, and Truck classes.<br>
The VehicleType enum defines the different types of vehicles supported by the parking lot.<br>
Multi-threading is achieved through the use of synchronized keyword on critical sections to ensure thread safety.<br>
The Main class demonstrates the usage of the parking lot system.<br>

## Design Patterns Used:
Singleton Pattern: Ensures only one instance of the ParkingLot class.<br>
Factory Pattern (optional extension): Could be used for creating vehicles based on input.<br>
Observer Pattern (optional extension): Could notify customers about available spots.<br>
