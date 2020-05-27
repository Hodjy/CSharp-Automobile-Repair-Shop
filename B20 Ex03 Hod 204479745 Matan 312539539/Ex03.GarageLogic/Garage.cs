namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class Garage
    {
        Dictionary<int, StoredVehicle> m_StoredVehicle;
        
        public void StoreVehicle(Vehicle i_VehicleToStore, VehicleOwner i_OwnerToStore)
        {
            StoredVehicle newVehicle = new StoredVehicle(i_VehicleToStore, i_OwnerToStore);

            m_StoredVehicle.Add(i_VehicleToStore.GetHashCode(), newVehicle);
        }

        public void ChangeVehicleState(string i_VehicleId,StoredVehicle.eVehicleState i_NewState)
        {
            StoredVehicle vehicleToChangeState = null;
            vehicleToChangeState = getStoredVehicleByID(i_VehicleId);
            vehicleToChangeState.VehicleState = i_NewState;
        }

        public void RechargeFuel(string i_VehicleId, FuelEngine.eFuelType i_FuelType, float i_AmountToRecharge)
        {
            StoredVehicle vehicleToRecharge = null;
            FuelEngine        engineToRecharge = null;
            vehicleToRecharge = getStoredVehicleByID(i_VehicleId);
            engineToRecharge = (vehicleToRecharge.Vehicle.Engine as FuelEngine);
            if(engineToRecharge != null)
            {
                engineToRecharge.Recharge(i_AmountToRecharge, i_FuelType); // if not fuel engine, if wrong fuel type, if amount too high.
            }
            else
            {
                throw new ArgumentException();
            }
            
        }

        public void RechargeElectric(string i_VehicleId, float i_AmountToRecharge)
        {

        }

        public void InflateVehicleWheelsToMaximumCapacity(string i_VehicleId)
        {
            StoredVehicle vehicleToInflate = null;

            vehicleToInflate = getStoredVehicleByID(i_VehicleId);

        }

        private StoredVehicle getStoredVehicleByID(string i_VehicleId)
        {
            StoredVehicle vehicleToSend = null;
            bool          isVehicleStored = false;

            isVehicleStored = m_StoredVehicle.TryGetValue(i_VehicleId.GetHashCode(), out vehicleToSend);
            if (!isVehicleStored)
            {
                throw new ArgumentException();
            }

            return vehicleToSend;
        }
    }
}
