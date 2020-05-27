namespace Ex03.GarageLogic
{
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
            vehicleToRecharge = getStoredVehicleByID(i_VehicleId);

        }

        public void RechargeElectric(string i_VehicleId, float i_AmountToRecharge)
        {

        }

        public void InflateVehicleWheelsToMaximumCapacity(string i_VehicleId)
        {

        }

        private StoredVehicle getStoredVehicleByID(string i_VehicleId)
        {
            StoredVehicle vehicleToSend = null;
            vehicleToSend = m_StoredVehicle[i_VehicleId.GetHashCode()];
            return vehicleToSend;
        }
    }
}
