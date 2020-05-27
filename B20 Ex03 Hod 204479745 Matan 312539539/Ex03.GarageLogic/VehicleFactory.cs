namespace Ex03.GarageLogic
{
    public static class VehicleFactory 
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, eEngineType i_EngineType)
        {
            Vehicle createdVehicle = null;

            switch(i_EngineType)
            {
                case eEngineType.Fuel:
                    createdVehicle = createFuelVehicle(i_VehicleType);
                    break;
                case eEngineType.Electric:
                    createdVehicle = createElectricVehicle(i_VehicleType);
                    break;
            }

            return createdVehicle;
        }

        private static Vehicle createFuelVehicle(eVehicleType i_VehicleType)
        {
            Vehicle    createdVehicle = null;
            FuelEngine createdFuelEngine = null;

            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    createdFuelEngine = new FuelEngine(0, 60, FuelEngine.eFuelType.Octan96);
                    createdVehicle = createCar(createdFuelEngine);
                    break;
                case eVehicleType.Motorbike:
                    createdFuelEngine = new FuelEngine(0, 7, FuelEngine.eFuelType.Octan95);
                    createdVehicle = createMotorbike(createdFuelEngine);
                    break;
                case eVehicleType.Truck:
                    createdFuelEngine = new FuelEngine(0, 120, FuelEngine.eFuelType.Soler);
                    createdVehicle = createTruck(createdFuelEngine);
                    break;
            }

            return createdVehicle;
        }

        private static Vehicle createElectricVehicle(eVehicleType i_VehicleType)
        {
            Vehicle createdVehicle = null;
            ElectricEngine createdElectricEngine = null;

            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    createdElectricEngine = new ElectricEngine(0, 2.1f);
                    createdVehicle = createCar(createdElectricEngine);
                    break;
                case eVehicleType.Motorbike:
                    createdElectricEngine = new ElectricEngine(0, 1.2f);
                    createdVehicle = createMotorbike(createdElectricEngine);
                    break;
            }

            return createdVehicle;
        }

        // NOT DONE, REMEMBER TO CHANGE EMPTY STRINGS!
        private static Car createCar(Engine i_CreatedEngine)
        { 
            Car createdVehicle = new Car(string.Empty, string.Empty, i_CreatedEngine, 2, Car.eColor.Black);

            return createdVehicle;
        }

        

        private static Motorbike createMotorbike(Engine i_CreatedEngine)
        {
            Motorbike createdVehicle = new Motorbike(string.Empty, string.Empty, i_CreatedEngine, 
                                                     Motorbike.eLicenseType.A, 0);

            return createdVehicle;
        }

        private static Truck createTruck(Engine i_CreatedEngine)
        {
            Truck createdVehicle = new Truck(string.Empty, string.Empty, i_CreatedEngine, false, 0);
            return createdVehicle;
        }

        public enum eVehicleType
        {
            Car,
            Motorbike,
            Truck,
        }

        public enum eEngineType
        {
            Fuel,
            Electric,
        }
    }
}