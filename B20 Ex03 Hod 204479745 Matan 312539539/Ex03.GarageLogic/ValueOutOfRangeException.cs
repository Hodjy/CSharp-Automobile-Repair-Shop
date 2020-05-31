namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_NameOfProblematicVar) : 
               base(string.Format("{0} must be between {1} to {2}.", i_NameOfProblematicVar, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }
    }
}
