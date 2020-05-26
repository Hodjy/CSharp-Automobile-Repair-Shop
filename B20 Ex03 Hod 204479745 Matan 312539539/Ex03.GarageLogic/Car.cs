namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private int m_AmountOfDoors;
        private eColor m_CarColor;

        public Car(string i_Id, string i_ModelName, Engine i_Engine, int i_AmountOfDoors, eColor i_CarColor) :
            base(i_Id, i_ModelName, i_Engine, 4)
        {
            m_AmountOfDoors = i_AmountOfDoors;
            m_CarColor = i_CarColor;
        }

        public int AmountOfDoors
        {
            get
            {
                return m_AmountOfDoors;
            }
            set
            {
                m_AmountOfDoors = value;
            }
        }

        public eColor CarColor
        {
            get
            {
                return m_CarColor;
            }
        }

        public enum eColor
        {
            Red,
            White,
            Black,
            Silver,
        }
    }
}