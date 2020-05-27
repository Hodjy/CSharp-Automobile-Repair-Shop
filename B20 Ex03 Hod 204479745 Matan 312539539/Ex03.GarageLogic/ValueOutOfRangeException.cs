namespace Ex03.GarageLogic
{
    using System;
    public class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;
    }
}
