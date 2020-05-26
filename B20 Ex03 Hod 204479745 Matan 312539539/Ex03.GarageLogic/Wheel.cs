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

        public void Inflate(float i_AmountToInflate)
        {
            if(i_AmountToInflate + m_CurrentAirPressure <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AmountToInflate;
            }
        }
    }
}