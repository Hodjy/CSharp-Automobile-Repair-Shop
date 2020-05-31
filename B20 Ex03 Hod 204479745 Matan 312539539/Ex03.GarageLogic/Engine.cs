namespace Ex03.GarageLogic
{
    using System;

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
                throw new ValueOutOfRangeException(0, r_MaxEnergy - m_CurrentEnergy, "Amount to recharge");
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
                if (value < 0)
                {
                    throw new ArgumentException("Current energy cannot be lower than 0");
                }

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

        public override string ToString()
        {
            return string.Format(@"Engine type: {0}", this.GetType());
        }
    }
}