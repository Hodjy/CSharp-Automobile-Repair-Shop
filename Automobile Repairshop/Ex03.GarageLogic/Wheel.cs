﻿namespace Ex03.GarageLogic
{
    using System;

    public class Wheel
    {
        string         m_ManufacturerName;
        float          m_CurrentAirPressure;
        readonly float r_MaxAirPressure;

        public Wheel(string i_ManufaturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufaturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Wheel manufacturer cannot be null or empty.");
                }

                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (value >= 0 && value <= r_MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else if (value < 0)
                {
                    throw new ArgumentException("Current air pressure cannot be lower than 0");
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxAirPressure, "Air Pressure");
                }

               
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public void Inflate(float i_AmountToInflate)
        {
            if(i_AmountToInflate + m_CurrentAirPressure <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AmountToInflate;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure - m_CurrentAirPressure, "Air Pressure");
            }
        }

        public override string ToString()
        {
            return string.Format(@"Manufacturer name: {0}
Current Air Pressure: {1}
Max Air Pressure: {2}", 
m_ManufacturerName,
m_CurrentAirPressure,
r_MaxAirPressure);
        }
    }
}