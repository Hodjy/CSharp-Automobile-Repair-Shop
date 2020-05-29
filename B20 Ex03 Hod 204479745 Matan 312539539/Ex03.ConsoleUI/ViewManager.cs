namespace Ex03.ConsoleUI
{
    using Ex03.GarageLogic;
    using System;
    using System.Text;

    internal class ViewManager
    {
        private Garage m_CurrentGarage;

        public ViewManager()
        {
            m_CurrentGarage = new Garage();
        }

        public void Start()
        {
            OutputManager.ShowWelcomeMessage();
            runGarageOperation();
        }

        private void runGarageOperation()
        {
            StringBuilder validUserInput = new StringBuilder();
            bool          isRunning = true;

            while (isRunning)
            {
                OutputManager.ShowOperationMenu();
                validUserInput = GetMainMenuValidInput();
                
            }
        }

        private StringBuilder GetMainMenuValidInput()
        {
            bool isInputValid = false;
            StringBuilder userInput = new StringBuilder();

            while(!isInputValid)
            {
                try
                {
                    userInput = InputManager.GetMainMenuInput();
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowInvalidInputMsg();
                }
            }

            return userInput;
        }
    }
}