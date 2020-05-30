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
            int validUserInput = 0;
            bool isRunning = true;

            while (isRunning)
            {
                OutputManager.ShowMainMenuScreen();
                validUserInput = GetMainMenuValidInput();
                callAppropriateOperation(validUserInput);
            }
        }

        private int GetMainMenuValidInput()
        {
            bool isInputValid = false;
            int userInput = 0;

            while (!isInputValid)
            {
                try
                {
                    userInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userInput, 1, 7);
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid input.
Please enter a number");
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format(@"Invalid number.
Pleaes pick a number between {0} to {1}.", ex.MinValue, ex.MaxValue));
                }
            }

            return userInput;
        }

        private void callAppropriateOperation(int i_ValidUserInput)
        {
            switch (i_ValidUserInput)
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
                case 7:
                    quitProgram();
                    break;
            }
        }

        private void storeNewVehicleInGarage()
        {
            VehicleOwner newOwnerToStore = new VehicleOwner();
            Vehicle newVehicleToStore = null;

            newOwnerToStore = createNewVehicleOwner();
            newVehicleToStore = createNewVehicle();
            changeVehicleDetails(ref newVehicleToStore);
            m_CurrentGarage.StoreVehicle(newVehicleToStore, newOwnerToStore);
        }

        private void showFilteredId()
        {

        }

        private void changeVehicleState()
        {

        }

        private void inflateAirInAllWheels()
        {

        }

        private void rechargeVehicle()
        {

        }

        private void showVehicleDetails()
        {

        }

        private void quitProgram()
        {
            System.Environment.Exit(1);
        }

        private VehicleOwner createNewVehicleOwner()
        {
            VehicleOwner newVehicleOwner = new VehicleOwner();

            getValidVehicleOwnerName(out newVehicleOwner);
            getVehicleOwnerPhone(out newVehicleOwner);

            return newVehicleOwner;
        }

        private Vehicle createNewVehicle()
        {
            VehicleFactory.eVehicleType newVehicleType = getValidUserVehicleType();
            VehicleFactory.eEngineType newEngineType = getValidUserEngineType();

            return VehicleFactory.CreateVehicle(newVehicleType, newEngineType);
        }

        private void getValidVehicleOwnerName(out VehicleOwner o_VehicleOwnerToUpdate)
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the owner name:");
                    o_VehicleOwnerToUpdate.Name = InputManager.GetUserInput();
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid name. 
Owner name must contain only letters.");
                }
            }
        }

        private void getVehicleOwnerPhone(out VehicleOwner o_VehicleOwnerToUpdate)
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the owners phone number:");
                    o_VehicleOwnerToUpdate.PhoneNumber = InputManager.GetUserInput();
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid phone number.
Phone number must contain only numbers.");
                }
            }
        }

        private VehicleFactory.eVehicleType getValidUserVehicleType()
        {

            VehicleFactory.eVehicleType userVehicleType;
            bool isInputValid = false;
            int userInput = 0;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowEnterNewVehicleScreen();
                    userInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userInput, 1, Enum.GetValues(typeof(VehicleFactory.eVehicleType)).Length);
                    isInputValid = true;
                }
                catch(FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid input.
Please enter a number");
                }
                catch(ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format(@"Invalid number.
Please pick a number between {0} to {1}.", ex.MinValue, ex.MaxValue));
                }
            }

            userVehicleType = (VehicleFactory.eVehicleType)userInput;

            return userVehicleType;
        }

        private VehicleFactory.eEngineType getValidUserEngineType()
        {

            VehicleFactory.eEngineType userEngineType;
            bool isInputValid = false;
            int userInput = 0;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowEnterNewEngineScreen();
                    userInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userInput, 1, Enum.GetValues(typeof(VehicleFactory.eEngineType)).Length);
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid input.
Please enter a number");
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format(@"Invalid number.
Please pick a number between {0} to {1}.", ex.MinValue, ex.MaxValue));
                }
            }

            userEngineType = (VehicleFactory.eEngineType)userInput;

            return userEngineType;
        }

        private void changeVehicleDetails(ref Vehicle io_NewVehicleToUpdate)
        {
            getVehicleProperties(ref io_NewVehicleToUpdate);

            if (io_NewVehicleToUpdate is Car)
            {
                Car newCar = io_NewVehicleToUpdate as Car;
                getCarProperties(ref newCar);
            }
            else if (io_NewVehicleToUpdate is Motorbike)
            {
                Motorbike newMotorbike = io_NewVehicleToUpdate as Motorbike;
                getMotorbikeProperties(ref newMotorbike);
            }
            else if (io_NewVehicleToUpdate is Truck)
            {
                Truck newTruck = io_NewVehicleToUpdate as Truck;
                getTruckProperties(ref newTruck);
            }
        }

        private void getVehicleProperties(ref Vehicle io_NewVehicleToUpdate)
        {
            OutputManager.ShowMessage("Please enter the vehicle license number");
            io_NewVehicleToUpdate.ID = InputManager.GetUserInput();
            OutputManager.ShowMessage("Please enter the vehicle model name");
            io_NewVehicleToUpdate.ModelName = InputManager.GetUserInput();

            getEngineCurrentEnergy(ref io_NewVehicleToUpdate);
            getWheelsCurrentAirPressure(ref io_NewVehicleToUpdate);
        }

        private void getEngineCurrentEnergy(ref Vehicle io_NewVehicleYoUpdate)
        {
            bool isInputValid = false;

            while(!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter current engine energy.");
                    io_NewVehicleYoUpdate.Engine.CurrentEnergy = InputManager.GetInputAndConvertToFloat();
                    isInputValid = true;
                }
                catch(FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid format.
Please enter a number.");
                }
                catch(ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid number.
Please enter a positive number only.");
                }
            }
        }

        private void getWheelsCurrentAirPressure(ref Vehicle io_NewVehicleYoUpdate)
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the current wheels' air pressure.");
                    io_NewVehicleYoUpdate.SetWheelsAirPressure(InputManager.GetInputAndConvertToFloat());
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid format.
Please enter a number.");
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid number.
Please enter a positive number only.");
                }
            }
        }

        private void getCarProperties(ref Car io_CarToUpdate)
        {
            getCarAmountOfDoors(ref io_CarToUpdate);
            getCarColor(ref io_CarToUpdate);
        }

        private void getCarAmountOfDoors(ref Car io_CarToUpdate)
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the amount of doors in the car.");
                    io_CarToUpdate.AmountOfDoors = InputManager.GetInputAndConvertToInt();
                    isInputValid = true;
                }
                catch(FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid input.
Please enter a number.");
                }
                catch(ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format(@"Invalid number.
Please enter a number between {0} to {1}.", ex.MinValue, ex.MaxValue));
                }
            }
        }

        private void getCarColor(ref Car io_CarToUpdate)
        {
            bool isInputValid = false;
            int userInput = 0;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowCarColorScreen();
                    userInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userInput, 1, Enum.GetValues(typeof(Car.eColor)).Length);
                    isInputValid = true;
                }
                catch(FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid input.
Please enter a number.");
                }
                catch(ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format(@"Invalid number.
Please enter a number between {0} to {1}.", ex.MinValue, ex.MaxValue));
                }
            }

            io_CarToUpdate.CarColor = (Car.eColor)userInput;
        }

        private void getMotorbikeProperties(ref Motorbike io_MotorbikeToUpdate)
        {
            getMotorbikeLicenseType(ref io_MotorbikeToUpdate);
            getMotorbikeEngineVolume(ref io_MotorbikeToUpdate);
        }

        private void getMotorbikeLicenseType(ref Motorbike io_MotorbikeToUpdate)
        {
            bool isInputValid = false;
            int userInput = 0;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMotorbikeLicenseScreen();
                    userInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userInput, 1, Enum.GetValues(typeof(Motorbike.eLicenseType)).Length);
                    isInputValid = true;
                }
                catch(FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid input.
Please enter a number.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format(@"Invalid number.
Please enter a number between {0} to {1}.", ex.MinValue, ex.MaxValue));
                }
            }

            io_MotorbikeToUpdate.License = (Motorbike.eLicenseType)userInput;
        }

        private void getMotorbikeEngineVolume(ref Motorbike io_MotorbiketoUpdate)
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the motorbike engine volume.");
                    io_MotorbiketoUpdate.EngineVolume = InputManager.GetInputAndConvertToInt();
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid input.
Please enter a number.");
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid number.
Please enter a positive number only.");
                }

            }
        }

        private void getTruckProperties(ref Truck io_TruckToUpdate)
        {
            getTruckCargoVolume(ref io_TruckToUpdate);
            getTruckIsContainingDangerousProducts(ref io_TruckToUpdate);
        }

        public void getTruckCargoVolume(ref Truck io_TruckToUpdate)
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the truck cargo volume.");
                    io_TruckToUpdate.CargoVolume = InputManager.GetInputAndConvertToInt();
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid input.
Please enter a number.");
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"Invalid number.
Please enter a positive number only.");
                }

            }
        }

        private void isInRange(float i_ToCheck, float i_MinValue, float i_MaxValue)
        {
            if (!(i_ToCheck <= i_MaxValue && i_ToCheck >= i_MinValue))
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue);
            }
        }
    }
}