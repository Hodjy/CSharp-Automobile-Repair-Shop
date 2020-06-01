namespace Ex03.GarageLogic
{
    using System;

    public class Motorbike : Vehicle
    {
        private eLicenseType m_License;
        private int m_EngineVolume;

        public Motorbike(string i_Id, string i_ModelName, Engine i_Engine, float i_MaxWheelsAirPressure,
                         eLicenseType i_License, int i_EngineVolume) :
                         base(i_Id, i_ModelName, i_Engine, i_MaxWheelsAirPressure, 2)
        { 
            m_License = i_License;
            m_EngineVolume = i_EngineVolume;
        }

        public eLicenseType License
        {
            get
            {
                return m_License;
            }
            set
            {
                m_License = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Engine Volume cannot lower than 0.");   
                }

                m_EngineVolume = value;
            }
        }

        public enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B,
        }

        public override string ToString()
        {
            return string.Format(@"{0}
License Type: {1}
Engine Volume: {2}",
base.ToString(),
m_License,
m_EngineVolume);
        }
    }
}