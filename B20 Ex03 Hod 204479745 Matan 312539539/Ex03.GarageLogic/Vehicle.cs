﻿namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public class Vehicle
    {
        private List<Wheel> m_Wheels;
        private Engine      m_Engine;
        private float       m_CurrentEnergyPercent;
        private string      m_ModelName;
        private string      m_Id;

        public Vehicle(string i_Id, string i_ModelName, Engine i_Engine, int i_AmountOfWheels)
        {
            m_Id = i_Id;
            m_ModelName = i_ModelName;
            m_Engine = i_Engine;
            m_CurrentEnergyPercent = (m_Engine.CurrentEnergy * 100) / m_Engine.MaxEnergy; 
            m_Wheels = new List<Wheel>(i_AmountOfWheels);

        }

        public string ID
        {
            get
            {
                return m_Id;
            }
            set
            {
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

        public int AmountOfWheels
        {
            get
            {
                return m_Wheels.Count;
            }
        }
    }
}