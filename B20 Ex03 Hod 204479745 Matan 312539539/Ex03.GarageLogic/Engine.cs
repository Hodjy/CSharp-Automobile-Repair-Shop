namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergy;
        protected readonly float r_MaxEnergy;

        public Engine(float i_CurrentEnergy, float i_MaxEnergy)
        {
            m_CurrentEnergy = i_CurrentEnergy;
            r_MaxEnergy = i_MaxEnergy;
        }

        protected void rechargeEnergy(float i_AmountToRecharge)
        {
            bool isAmountInRange = false;

            isAmountInRange = ((i_AmountToRecharge + m_CurrentEnergy) <= r_MaxEnergy);
            if (!isAmountInRange)
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergy - m_CurrentEnergy);
            }

            m_CurrentEnergy += i_AmountToRecharge;
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                m_CurrentEnergy = value;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }
    }
}