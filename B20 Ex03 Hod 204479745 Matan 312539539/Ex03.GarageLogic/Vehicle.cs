namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Text;
    using System;

    public abstract class Vehicle
    {
        private List<Wheel> m_Wheels;
        private Engine      m_Engine;
        private float       m_CurrentEnergyPercent;
        private string      m_ModelName;
        private string      m_Id;

        public Vehicle(string i_Id, string i_ModelName, Engine i_Engine, float i_MaxWheelsAirPressure, int i_AmountOfWheels)
        {
            m_Id = i_Id;
            m_ModelName = i_ModelName;
            m_Engine = i_Engine;
            calculateCurrentEnergyPercent(); 
            m_Wheels = new List<Wheel>(i_AmountOfWheels);
            InitializeWheels(i_MaxWheelsAirPressure);
        }

        public string ID
        {
            get
            {
                return m_Id;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ID cannot be null or empty.");
                }

                m_Id = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model name cannot be null or empty.");
                }

                m_ModelName = value;
            }
        }

        public float CurrentEnergyPercent
        {
            get
            {
                return m_CurrentEnergyPercent;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public void calculateCurrentEnergyPercent()
        {
            m_CurrentEnergyPercent = (m_Engine.CurrentEnergy / m_Engine.MaxEnergy) * 100f;
        }

        public void InitializeWheels(float i_MaxAirPressure)
        {
            for (int i = 0 ; i < m_Wheels.Capacity ; i++)
            {
                m_Wheels.Add(new Wheel(string.Empty, 0, i_MaxAirPressure));
            }
        }

        public void InflateAllWheelsToMax()
        {
            float amountToInflate;

            foreach (Wheel wheel in m_Wheels)
            {
                amountToInflate = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.Inflate(amountToInflate);
            }
        }

        public void SetWheelsAirPressure(float i_CurrentAirPressure)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = i_CurrentAirPressure;
            }
        }

        public void SetWheelsManufacturerName(string i_ManufacturerName)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        public int AmountOfWheels
        {
            get
            {
                return m_Wheels.Count;
            }
        }

        public override int GetHashCode()
        {
            return m_Id.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder VehicleDetails = new StringBuilder(string.Format(@"ID: {0}
Model Name: {1}
Engine: 
{2}
Current % Energy: {3}
Wheels:
",
m_Id,
m_ModelName,
m_Engine,
m_CurrentEnergyPercent));

            foreach (Wheel currentWheel in m_Wheels)
            {
                VehicleDetails.AppendLine(string.Format("{0}", currentWheel.ToString()));
            }

            return VehicleDetails.ToString();
        }
    }
}