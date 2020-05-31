namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private int m_AmountOfDoors;
        private eColor m_CarColor;

        public Car(string i_Id, string i_ModelName, Engine i_Engine, float i_MaxWheelsAirPressure, int i_AmountOfDoors, eColor i_CarColor) :
            base(i_Id, i_ModelName, i_Engine, i_MaxWheelsAirPressure, 4)
        {
            AmountOfDoors = i_AmountOfDoors;
            CarColor = i_CarColor;
        }

        public int AmountOfDoors
        {
            get
            {
                return m_AmountOfDoors;
            }
            set
            {
                int minValue = 2, maxValue = 5;

                if(value >= minValue && value <= maxValue)
                {
                    m_AmountOfDoors = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(minValue, maxValue,"Amount of doors");
                }
                
            }
        }

        public eColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public enum eColor
        {
            Red,
            White,
            Black,
            Silver,
        }

        public override string ToString()
        {
            return string.Format(@"{0},
Color: {1},
Amount of Doors: {2}",
base.ToString(),
m_CarColor,
m_AmountOfDoors);
        }
    }
}