namespace Ex03.GarageLogic
{
    public class StoredVehicle
    {
        private Vehicle       m_Vehicle;
        private VehicleOwner  m_Owner;
        private eVehicleState m_VehicleState;

        public StoredVehicle(Vehicle i_VehicleToStore, VehicleOwner i_OwnerToStore)
        {
            m_Vehicle = i_VehicleToStore;
            m_Owner = i_OwnerToStore;
            m_VehicleState = eVehicleState.InRepair;
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
                return m_Owner.Name;
            }

            set
            {
                m_Owner.Name = value;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_Owner.PhoneNumber;
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

        public override int GetHashCode()
        {
            return m_Vehicle.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(@"Vehicle Owner: {0}
Vehicle: {1},
State: {2}",
m_Owner,
Vehicle,
VehicleState);
        }
    }
}
