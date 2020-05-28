namespace Ex03.GarageLogic
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Garage
    {
        Dictionary<int, StoredVehicle> m_StoredVehiclesDictionary;
        
        public void StoreVehicle(Vehicle i_VehicleToStore, VehicleOwner i_OwnerToStore)
        {
            StoredVehicle newVehicle = new StoredVehicle(i_VehicleToStore, i_OwnerToStore);
            bool          isVehicleIdAlreadyRegistered = false;

            isVehicleIdAlreadyRegistered = m_StoredVehiclesDictionary.ContainsKey(i_VehicleToStore.GetHashCode());
            if (isVehicleIdAlreadyRegistered)
            {
                throw new ArgumentException(string.Format("Vehicle ID {0} already exists.", i_VehicleToStore.ID));
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
                throw new ArgumentException("Vehicle does not use a fuel engine.");
            }

            engineToRecharge = (vehicleToRecharge.Vehicle.Engine as FuelEngine);
            engineToRecharge.Recharge(i_AmountToRecharge, i_FuelType);
            
            engineToRecharge.Recharge(i_AmountToRecharge, i_FuelType); // if not fuel engine, if wrong fuel type, if amount too high.

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
                throw new ArgumentException("Vehicle does not use an electric engine.");
            }

            engineToRecharge = (vehicleToRecharge.Vehicle.Engine as ElectricEngine);
        }

        public void InflateVehicleWheelsToMaximumCapacity(string i_VehicleId)
        {
            StoredVehicle vehicleToInflate = null;

            vehicleToInflate = m_StoredVehiclesDictionary[i_VehicleId.GetHashCode()];
            vehicleToInflate.Vehicle.InflateAllWheelsToMax();
        }

        public StringBuilder GetAllVehiclesIdByFilter(StoredVehicle.eVehicleState? i_StateFilter = null) // not done, needs to be changed.
        {
            StringBuilder vehiclesIdList = new StringBuilder();
            int           i = 0;

            foreach(KeyValuePair<int,StoredVehicle> entry in m_StoredVehiclesDictionary)
            {
                if (i_StateFilter != null)
                {
                    vehiclesIdList.AppendFormat(@"{0}.{1},
",i, i_StateFilter);
                    i++;
                }
                else
                {
                    vehiclesIdList.AppendFormat(@"{0}.{1},
", i, i_StateFilter);
                    i++;
                }
            }
        }

        public StoredVehicle GetStoredVehicle(string i_VehicleId) // maybe make copy constructor instead of returning a ref.
        {
            StoredVehicle vehicleToSend;

            vehicleToSend = m_StoredVehiclesDictionary[i_VehicleId.GetHashCode()];
            return vehicleToSend;
        }
    }
}
