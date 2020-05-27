namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelType m_EngineFuelType;

        public FuelEngine(float i_CurrentEnergy, float i_MaxEnergy, eFuelType i_FuelType) : base(i_CurrentEnergy,i_MaxEnergy)
        {
            m_EngineFuelType = i_FuelType;
        }

        public void Recharge(float i_AmountToRecharge, eFuelType i_FuelType)
        {
            if(i_FuelType == m_EngineFuelType)
            {
                rechargeEnergy(i_AmountToRecharge);
            }
        }

        public eFuelType EngineFuelType
        {
            get
            {
                return m_EngineFuelType;
            }
        }

        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler,
        }
    }
}