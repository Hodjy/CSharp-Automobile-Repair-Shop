﻿namespace Ex03.GarageLogic
{
    public struct VehicleOwner
    {
        private string m_Name;
        private string m_PhoneNumber;

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }

            set
            {
                m_PhoneNumber = value;
            }
        }
    }
}
