namespace Ex03.GarageLogic
{
    class VehicleFactory 
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, eEngineType i_EngineType)
        {
            Vehicle createdVehicle = null;
            switch(i_VehicleType)
            {
                case eVehicleType.Car:
                    createdVehicle = createCar(i_EngineType);
                    break;
                case eVehicleType.Motorbike:
                    createdVehicle = createMotorbike(i_EngineType);
                    break;
                case eVehicleType.Truck:
                    createdVehicle = createTruck(i_EngineType);
                    break;
            }

            return createdVehicle;
        }

        private Vehicle createCar(eEngineType i_EngineType)
        {
            Car createdVehicle = new Car(i_EngineType);
            return createdVehicle;
        }

        private Vehicle createMotorbike(eEngineType i_EngineType)
        {
            Vehicle createdVehicle = new Motorbike(i_EngineType);
            return createdVehicle;
        }

        private Vehicle createTruck(eEngineType i_EngineType)
        {
            Vehicle createdVehicle = new Truck(i_EngineType);
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
