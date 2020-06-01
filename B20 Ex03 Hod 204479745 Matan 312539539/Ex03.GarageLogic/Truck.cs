namespace Ex03.GarageLogic
{
    using System;

    public class Truck : Vehicle
    {
        private bool  m_IsContainingDangerousProducts;
        private float m_CargoVolume;

        public Truck(string i_Id, string i_ModelName, Engine i_Engine, float i_MaxWheelsAirPressure, bool i_IsContainingDangerousProducts,
            float i_CargotVolume) : 
            base(i_Id, i_ModelName, i_Engine, i_MaxWheelsAirPressure, 16)
        {
            m_IsContainingDangerousProducts = i_IsContainingDangerousProducts;
            m_CargoVolume = i_CargotVolume;
        }

        public bool IsContainingDangerousProducts
        {
            get
            {
                return m_IsContainingDangerousProducts;
            }
            set
            {
                m_IsContainingDangerousProducts = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cargo volume cannot be lower than 0.");
                }

                m_CargoVolume = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0}
Cargo Volume: {1}
Containing Dangerous Products: {2}",
base.ToString(),
m_CargoVolume,
m_IsContainingDangerousProducts);
        }
    }
}