namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool  m_IsContainingDangerousProducts;
        private float m_CargoVolume;

        public Truck(string i_Id, string i_ModelName, Engine i_Engine, bool i_IsContainingDangerousProducts, float i_CargotVolume)
        {
            base(i_Id, i_ModelName, i_Engine, 16);
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
                m_CargoVolume = value;
            }
        }
    }
}