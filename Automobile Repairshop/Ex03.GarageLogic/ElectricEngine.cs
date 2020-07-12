namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentEnergy, float i_MaxEnergy) : base(i_CurrentEnergy, i_MaxEnergy)
        {
        }

        public void Recharge(float i_AmountToRecharge)
        {
            if (i_AmountToRecharge > r_MaxEnergy * 60)
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergy * 60, "Engine energy");
            }

            float amountToRechargeInHours = i_AmountToRecharge / 60f;
            rechargeEnergy(amountToRechargeInHours);
        }

        public override float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                if (value > r_MaxEnergy * 60)
                {
                    throw new ValueOutOfRangeException(0, r_MaxEnergy * 60, "Engine energy");
                }

                base.CurrentEnergy = value / 60f;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}