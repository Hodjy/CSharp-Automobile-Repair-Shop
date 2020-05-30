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
                throw new ArgumentException();
            }

            m_StoredVehiclesDictionary.Add(i_VehicleToStore.GetHashCode(), newVehicle);
        }

        public void ChangeVehicleState(string i_VehicleId, StoredVehicle.eVehicleState i_NewState)
        {
            StoredVehicle vehicleToChangeState = null;

            vehicleToChangeState = m_StoredVehiclesDictionary[i_VehicleId.GetHashCode()];
            vehicleToChangeState.VehicleState = i_NewState;
        }

        public void RechargeFuel(string i_VehicleId, FuelEngine.eFuelType i_FuelType, float i_AmountToRecharge)
        {
            StoredVehicle     vehicleToRecharge = null;
            FuelEngine        engineToRecharge = null;
            bool              isEngineFuel = false;

            vehicleToRecharge = m_StoredVehiclesDictionary[i_VehicleId.GetHashCode()];
            isEngineFuel = vehicleToRecharge.Vehicle.Engine is FuelEngine;
            if (!isEngineFuel)
            {
                throw new ArgumentException();
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

            vehicleToRecharge = m_StoredVehiclesDictionary[i_VehicleId.GetHashCode()];
            isEngineElectric = vehicleToRecharge.Vehicle.Engine is ElectricEngine;
            if(!isEngineElectric)
            {
                throw new ArgumentException();
            }

            engineToRecharge = (vehicleToRecharge.Vehicle.Engine as ElectricEngine);
            engineToRecharge.Recharge(i_AmountToRecharge);
            vehicleToRecharge.Vehicle.calculateCurrentEnergyPercent();
        }

        public void InflateVehicleWheelsToMaximumCapacity(string i_VehicleId)
        {
            StoredVehicle vehicleToInflate = null;

            vehicleToInflate = m_StoredVehiclesDictionary[i_VehicleId.GetHashCode()];
            vehicleToInflate.Vehicle.InflateAllWheelsToMax();
        }

        public StringBuilder GetAllVehiclesIdByFilter(StoredVehicle.eVehicleState? i_StateFilter = null) // not done, needs to be changed.
        {
            StringBuilder vehiclesIdStringList = new StringBuilder(string.Empty);
            int           i = 1;

            foreach(KeyValuePair<int, StoredVehicle> entry in m_StoredVehiclesDictionary)
            {
                if (i_StateFilter == null)
                {
                    vehiclesIdStringList.AppendFormat(string.Format(@"{0,-3}. {1,13} {2,6}
", i, entry.Value.Vehicle.ID, entry.Value.VehicleState));
                    i++;
                }
                else if (i_StateFilter == entry.Value.VehicleState)
                {
                    vehiclesIdStringList.AppendFormat(string.Format(@"{0,-3}. {1,13} {2,6}
", i, entry.Value.Vehicle.ID, entry.Value.VehicleState));
                    i++;
                }
            }

            return vehiclesIdStringList;
        }

        public string GetStoredVehicleDetailsString(string i_VehicleId)
        {
            StoredVehicle vehicleToShowDetails = m_StoredVehiclesDictionary[i_VehicleId.GetHashCode()];

            return vehicleToShowDetails.ToString();
        }
    }
}
