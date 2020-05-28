namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;
        
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base()
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
