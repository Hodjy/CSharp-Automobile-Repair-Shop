namespace Ex03.GarageLogic
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Garage
    {
        Dictionary<int, StoredVehicle> m_StoredVehiclesDictionary;

        public Garage()
        {
            m_StoredVehiclesDictionary = new Dictionary<int, StoredVehicle>();
        }
        
        public void StoreVehicle(Vehicle i_VehicleToStore, VehicleOwner i_OwnerToStore)
        {
            StoredVehicle newVehicle = new StoredVehicle(i_VehicleToStore, i_OwnerToStore);
            bool          isVehicleIdAlreadyRegistered = false;

            isVehicleIdAlreadyRegistered = m_StoredVehiclesDictionary.ContainsKey(i_VehicleToStore.GetHashCode());
            if (isVehicleIdAlreadyRegistered)
            {
                throw new ArgumentException(string.Format("ID: {0} is already registered.", i_VehicleToStore.ID));
            }

            m_StoredVehiclesDictionary.Add(i_VehicleToStore.GetHashCode(), newVehicle);
        }

        public void ChangeVehicleState(string i_VehicleId, StoredVehicle.eVehicleState i_NewState)
        {
            StoredVehicle vehicleToChangeState;

            vehicleToChangeState = getStoredVehicle(i_VehicleId);
            vehicleToChangeState.VehicleState = i_NewState;
        }

        public void RechargeFuel(string i_VehicleId, FuelEngine.eFuelType i_FuelType, float i_AmountToRecharge)
        {
            StoredVehicle     vehicleToRecharge = null;
            FuelEngine        engineToRecharge = null;
            bool              isEngineFuel = false;

            vehicleToRecharge = getStoredVehicle(i_VehicleId);
            isEngineFuel = vehicleToRecharge.Vehicle.Engine is FuelEngine;
            if (!isEngineFuel)
            {
                throw new ArgumentException("Engine is not FuelEngine.");
            }

            engineToRecharge = (vehicleToRecharge.Vehicle.Engine as FuelEngine);            
            engineToRecharge.Recharge(i_AmountToRecharge, i_FuelType); // if not fuel engine, if wrong fuel type, if amount too high.
            vehicleToRecharge.Vehicle.calculateCurrentEnergyPercent();
        }

        public void RechargeElectric(string i_VehicleId, float i_AmountToRecharge)
        {
            StoredVehicle  vehicleToRecharge = null;
            ElectricEngine engineToRecharge = null;
            bool           isEngineElectric = false;

            vehicleToRecharge = getStoredVehicle(i_VehicleId);
            isEngineElectric = vehicleToRecharge.Vehicle.Engine is ElectricEngine;
            if(!isEngineElectric)
            {
                throw new ArgumentException("Engine is not ElectricEngine.");
            }

            engineToRecharge = (vehicleToRecharge.Vehicle.Engine as ElectricEngine);
            engineToRecharge.Recharge(i_AmountToRecharge);
            vehicleToRecharge.Vehicle.calculateCurrentEnergyPercent();
        }

        public void InflateVehicleWheelsToMaximumCapacity(string i_VehicleId)
        {
            StoredVehicle vehicleToInflate;

            vehicleToInflate = getStoredVehicle(i_VehicleId);
            vehicleToInflate.Vehicle.InflateAllWheelsToMax();
        }

        public StringBuilder GetAllVehiclesIdByFilter(StoredVehicle.eVehicleState? i_StateFilter = null) 
        {
            StringBuilder vehiclesIdStringList = new StringBuilder(string.Empty);
            int           i = 1;

            foreach(KeyValuePair<int, StoredVehicle> entry in m_StoredVehiclesDictionary)
            {
                if (i_StateFilter == null)
                {
                    vehiclesIdStringList.AppendFormat(string.Format(@"{0,3}. {1,13} {2,-6}
", i, entry.Value.Vehicle.ID, entry.Value.VehicleState));
                    i++;
                }
                else if (i_StateFilter == entry.Value.VehicleState)
                {
                    vehiclesIdStringList.AppendFormat(string.Format(@"{0,3}. {1,13} {2,-6}
", i, entry.Value.Vehicle.ID, entry.Value.VehicleState));
                    i++;
                }
            }

            return vehiclesIdStringList;
        }

        public string GetStoredVehicleDetailsString(string i_VehicleId)
        {
            StoredVehicle vehicleToShowDetails;

            vehicleToShowDetails = getStoredVehicle(i_VehicleId);
            return vehicleToShowDetails.ToString();
        }

        private StoredVehicle getStoredVehicle(string i_VehicleId)
        {
            StoredVehicle storedVehicleToSend;
            bool          isKeyInDictionary = false;

            isKeyInDictionary = m_StoredVehiclesDictionary.TryGetValue(i_VehicleId.GetHashCode(), out storedVehicleToSend);
            if (!isKeyInDictionary)
            {
                throw new ArgumentException(string.Format("There isnt a vehicle with ID: {0} at the garage", i_VehicleId));
            }

            return storedVehicleToSend;
        }
    }
}
