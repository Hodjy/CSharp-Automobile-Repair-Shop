namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentEnergy, float i_MaxEnergy) : base(i_CurrentEnergy, i_MaxEnergy)
        {
        }

        public void Recharge(float i_AmountToRecharge)
        {
            float amountToRechargeInHours = i_AmountToRecharge / 60f;
            rechargeEnergy(amountToRechargeInHours);
        }
    }
}