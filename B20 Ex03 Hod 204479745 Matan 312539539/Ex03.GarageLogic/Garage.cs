namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    public class Garage
    {
        Dictionary<int, StoredVehicle> m_StoredVehicle;
        
        public void StoreVehicle(Vehicle i_VehicleToStore, string i_OwnerName, string i_OwnerPhone)
        {
            StoredVehicle newVehicle = new StoredVehicle(i_VehicleToStore, i_OwnerName, i_OwnerPhone);

            m_StoredVehicle.Add(i_VehicleToStore.ID.GetHashCode(), newVehicle);
        }

        public void ChangeVehicleState(string i_CarId,StoredVehicle.eVehicleState i_NewState)
        {

        }

        public void RechargeFuel(string i_CarId, FuelEngine.eFuelType i_FuelType, float i_AmountToRecharge)
        {

        }

        public void RechargeElectric(string i_CarId, float i_AmountToRecharge)
        {

        }

        public void InflateVehicleWheelsToMaximumCapacity(string i_CarId)
        {

        }
    }
}
