namespace Ex03.GarageLogic
{
    public class Motorbike : Vehicle
    {
        eLicenseType m_License;
        private int m_EngineVolume;

        public Motorbike(string i_Id, string i_ModelName, Engine i_Engine, eLicenseType i_License, int i_EngineVolume) :
                        base(i_Id, i_ModelName, i_Engine, 2)
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
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }

        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B,
        }
    }
}