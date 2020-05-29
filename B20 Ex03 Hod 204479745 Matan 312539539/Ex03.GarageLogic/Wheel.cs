namespace Ex03.GarageLogic
{
    public class Wheel
    {
        string         m_ManufacturerName;
        float          m_CurrentAirPressure;
        readonly float r_MaxAirPressure;

        public Wheel(string i_ManufaturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufaturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public void Inflate(float i_AmountToInflate)
        {
            if(i_AmountToInflate + m_CurrentAirPressure <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AmountToInflate;
            }
        }

        public override string ToString()
        {
            return string.Format(@"Manufacturer name: {0}, 
Current Air Pressure: {1},
Max Air Pressure: {2}", 
m_ManufacturerName,
m_CurrentAirPressure,
r_MaxAirPressure);
        }
    }
}