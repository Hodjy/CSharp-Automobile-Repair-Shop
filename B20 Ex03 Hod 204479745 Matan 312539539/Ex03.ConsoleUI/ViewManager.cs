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
                callAppropriateOperation(validUserInput);
            }
        }

        private StringBuilder GetMainMenuValidInput()
        {
            bool          isInputValid = false;
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
                    OutputManager.ShowInvalidFormatInputMsg();
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowInvalidArgumentInputMsg();
                }
            }

            return userInput;
        }

        private void callAppropriateOperation(StringBuilder i_ValidUserInput)
        {
            int operationNumber = int.Parse(i_ValidUserInput.ToString());

            switch (operationNumber)
            {
                case 1:
                    storeNewVehicleInGarage();
                    break;
                case 2:
                    showFilteredId();
                    break;
                case 3:
                    changeVehicleState();
                    break;
                case 4:
                    inflateAirInAllWheels();
                    break;
                case 5:
                    rechargeVehicle();
                    break;
                case 6:
                    showVehicleDetails();
                    break;
            }
        }

        private void storeNewVehicleInGarage()
        {
            VehicleOwner newOwnerToStore = new VehicleOwner();
            Vehicle newVehicleToStore = null;

            newOwnerToStore = createNewVehicleOwner();
            newVehicleToStore = createNewVehicle();
            m_CurrentGarage.StoreVehicle(newVehicleToStore, newOwnerToStore);
        }

        private VehicleOwner createNewVehicleOwner()
        {
            VehicleOwner newVehicleOwner = new VehicleOwner();

            getVehicleOwnerName(out newVehicleOwner);
            getVehicleOwnerPhone(out newVehicleOwner);            

            return newVehicleOwner;
        }

        private void getVehicleOwnerName(out VehicleOwner o_VehicleOwner)
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the owner name:");
                    o_VehicleOwner.Name = InputManager.GetUserInput();
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid name. 
Owner name must contain only letters without spaces.");
                }
            }
        }

        private void getVehicleOwnerPhone(out VehicleOwner o_VehicleOwner)
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the owners phone number:");
                    o_VehicleOwner.PhoneNumber = InputManager.GetUserInput();
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid phone number.
Phone number must contain only numbers.");
                }
            }
        }

        private Vehicle createNewVehicle()
        {
            Vehicle newVehicle = null;
            VehicleFactory.eVehicleType newVehicleType = getValidUserVehicleType();
            VehicleFactory.eEngineType newEngineType = getValidUserEngineType();

            return VehicleFactory.CreateVehicle(newVehicleType, newEngineType);
        }

        private StringBuilder getValidVehicleOwnerName()
        {
            bool isValidInput = false;
            StringBuilder userInput = new StringBuilder();

            while(!isValidInput)
            {
                try
                {
                    userInput = InputManager.GetVehicleOwnerName();
                    isValidInput = true;
                }
                catch
                {
                    OutputManager.ShowInvalidInputMsg();
                }
            }

            return userInput;
        }

        private StringBuilder getValidVehicleOwnerPhone()
        {
            bool isValidInput = false;
            StringBuilder userInput = new StringBuilder();

            while (!isValidInput)
            {
                try
                {
                    userInput = InputManager.GetVehicleOwnerName();
                    isValidInput = true;
                }
                catch
                {
                    OutputManager.ShowInvalidInputMsg();
                }
            }

            return userInput;
        }

        private VehicleFactory.eVehicleType getValidUserVehicleType()
        {
            VehicleFactory.eVehicleType userVehicleType;
            StringBuilder userInput = new StringBuilder();

            userInput = getUserVehicleTypeString();
            userVehicleType = (VehicleFactory.eVehicleType)int.Parse(userInput.ToString());

            return 
        }

        public enum eInputType
        {

        }

    }
}