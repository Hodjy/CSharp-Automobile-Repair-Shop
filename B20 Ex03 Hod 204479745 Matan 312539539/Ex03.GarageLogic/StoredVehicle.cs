namespace Ex03.GarageLogic
{
    public class StoredVehicle
    {
        private Vehicle       m_Vehicle;
        private string        m_OwnerName;
        private string        m_OwnerPhone;
        private eVehicleState m_VehicleState;

        public StoredVehicle(Vehicle i_VehicleToStore, string i_OwnerName, string i_OwnerPhone)
        {
            m_Vehicle = i_VehicleToStore;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
        }

        public enum eVehicleState
        {
            InRepair,
            Repaired,
            Paid,
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }
        }

        public eVehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }
            set
            {
                m_VehicleState = value;
            }
        }
    }
}
