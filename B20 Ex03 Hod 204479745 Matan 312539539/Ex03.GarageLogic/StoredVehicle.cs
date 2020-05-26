namespace Ex03.GarageLogic
{
    public class StoredVehicle
    {
        private Vehicle       m_Vehicle;
        private string        m_OwnerName;
        private string        m_OwnerPhone;
        private eVehicleState m_VehicleState;

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
