namespace Ex03.GarageLogic
{
    public class StoredVehicleDetails
    {
        private Vehicle       m_StoredVehicle;
        private string        m_OwnerName;
        private string        m_OwnerPhone;
        private eVehicleState m_VehicleState;

        public enum eVehicleState
        {
            InRepair,
            Repaired,
            Paid,
        }

        public Vehicle StoredVehicle
        {
            get
            {
                return m_StoredVehicle;
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
