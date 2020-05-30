namespace Ex03.GarageLogic
{
    using System;

    public struct VehicleOwner
    {
        private string m_Name;
        private string m_PhoneNumber;

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                if (value.Length > 0 && checkIfStringIsOnlyLetters(value))
                {
                    m_Name = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }

            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException();
                }

                m_PhoneNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"Name: {0},
Phone Number: {1}",
m_Name,
m_PhoneNumber);
        }

        private bool checkIfStringIsOnlyLetters(string i_StringToCheck)
        {
            bool isOnlyLetters = true;

            foreach (char c in i_StringToCheck)
            {
                if (!char.IsLetter(c))
                {
                    isOnlyLetters = false;
                    break;
                }
            }

            return isOnlyLetters;
        }
    }
}
