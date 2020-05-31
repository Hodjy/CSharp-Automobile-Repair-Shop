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
                    OutputManager.ShowErrorMessage(string.Format("Invalid input. {0}", ex.Message));
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("Invalid input. {0}", ex.Message));
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
            int           userChoice,enumLength;
            StringBuilder stringOfIdToPrint;
            bool          isInputValid = false;

            enumLength = Enum.GetNames(typeof(StoredVehicle.eVehicleState)).Length;
            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowFilterByVehicleStateScreen();
                    userChoice = InputManager.GetInputAndConvertToInt();
                    isInRange(userChoice, 1, (enumLength + 1));
                    stringOfIdToPrint = getFilteredVehicleId(userChoice);
                    OutputManager.ShowMessage(stringOfIdToPrint.ToString());
                    pressToContinue();
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("Invalid input. {0}", ex.Message));
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("Invalid input. {0}", ex.Message));
                }
            }
        }

        private StringBuilder getFilteredVehicleId(int i_UserChoice)
        {
            int maxEnumLength = Enum.GetNames(typeof(StoredVehicle.eVehicleState)).Length;
            StringBuilder stringToReturn = new StringBuilder();

            if (i_UserChoice == (maxEnumLength + 1))
            {
                m_CurrentGarage.GetAllVehiclesIdByFilter();
            }
            else
            {
                m_CurrentGarage.GetAllVehiclesIdByFilter((StoredVehicle.eVehicleState)i_UserChoice);
            }

            return stringToReturn;
        }

        private void changeVehicleState()
        {
            int           stateChoiceInput = 0;
            bool          isInputValid = false;
            StringBuilder vehicleIdInput = null;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter desired vehicle's id:");
                    vehicleIdInput = InputManager.GetUserInput();
                    OutputManager.ShowScreen<StoredVehicle.eVehicleState>("Please enter the number of the desired vehicle's new state:");
                    stateChoiceInput = InputManager.GetInputAndConvertToInt();
                    isInRange(stateChoiceInput, 1, Enum.GetNames(typeof(StoredVehicle.eVehicleState)).Length);
                    m_CurrentGarage.ChangeVehicleState(vehicleIdInput.ToString(), (StoredVehicle.eVehicleState)stateChoiceInput);
                    OutputManager.ShowMessage("Successfuly changed the vehicle state.");
                    pressToContinue();
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("Invalid input. {0}", ex.Message));
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("Input out of range. {0}", ex.Message));
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("{0}", ex.Message));
                }
            }
        }

        private void inflateAirInAllWheels()
        {
            bool isInputValid = false;
            StringBuilder vehicleIdInput = null;

            while(!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the desired vehicle id");
                    vehicleIdInput = InputManager.GetUserInput();
                    m_CurrentGarage.InflateVehicleWheelsToMaximumCapacity(vehicleIdInput.ToString());
                    OutputManager.ShowMessage("Successully inflated all the wheels.");
                    pressToContinue();
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("{0}", ex.Message));
                }
            }
        }

        private void rechargeVehicle()
        {
            bool          isInputValid = false;
            int           fuelTypeInput = 0, enumLength = 0;
            StringBuilder vehicleIdInput = null;
            float         fuelAmountInput = 0;

            enumLength = Enum.GetNames(typeof(VehicleFactory.eEngineType)).Length;
            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter desired vehicle id:");
                    vehicleIdInput = InputManager.GetUserInput();
                    OutputManager.ShowScreen<VehicleFactory.eEngineType>("Enter the type of engine your vehicle has:");
                    fuelTypeInput = InputManager.GetInputAndConvertToInt();
                    isInRange(fuelTypeInput, 1, enumLength);
                    OutputManager.ShowMessage("Please enter the amount you wish to charge your vehicle:");
                    fuelAmountInput = InputManager.GetInputAndConvertToFloat();
                    if ((VehicleFactory.eEngineType)fuelTypeInput == VehicleFactory.eEngineType.Fuel)
                    {
                        rechargeFuel(vehicleIdInput.ToString(), fuelAmountInput);
                    }
                    else
                    {
                        rechargeElectric(vehicleIdInput.ToString(), fuelAmountInput);
                    }

                    OutputManager.ShowMessage("Successfully recharged.");
                    pressToContinue();
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("Invalid input. {0}", ex.Message));
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("Input out of range. {0}", ex.Message));
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("{0}", ex.Message));
                }
            }
        }

        private void rechargeFuel(string i_VehicleId, float i_FuelAmountToRecharge)
        {
            int   fuelTypeInput = 0, enumLength = 0;

            enumLength = Enum.GetNames(typeof(FuelEngine.eFuelType)).Length;
            OutputManager.ShowScreen<FuelEngine.eFuelType>("Please enter the number for your desired fuel type:");
            fuelTypeInput = InputManager.GetInputAndConvertToInt();
            isInRange(fuelTypeInput, 0, enumLength);
            m_CurrentGarage.RechargeFuel(i_VehicleId, (FuelEngine.eFuelType)fuelTypeInput, i_FuelAmountToRecharge);
        }

        private void rechargeElectric (string i_VehicleId, float i_AmountToRecharge)
        {
            m_CurrentGarage.RechargeElectric(i_VehicleId, i_AmountToRecharge);
        }

        private void showVehicleDetails()
        {
            bool isInputValid = false;
            StringBuilder vehicleIdInput = null;

            while(isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the desired vehicle id.");
                    vehicleIdInput = InputManager.GetUserInput();
                    OutputManager.ShowMessage(m_CurrentGarage.GetStoredVehicleDetailsString(vehicleIdInput.ToString()));
                }
                catch
                {

                }
            }
        }

        private void quitProgram()
        {
            System.Environment.Exit(1);
        }

        private VehicleOwner createNewVehicleOwner()
        {
            VehicleOwner newVehicleOwner = new VehicleOwner();
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the owner name:");
                    newVehicleOwner.Name = InputManager.GetUserInput().ToString();
                    OutputManager.ShowMessage("Please enter the owners phone number:");
                    newVehicleOwner.PhoneNumber = InputManager.GetUserInput().ToString();
                    isInputValid = true;
                }
                catch(ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(ex.Message);
                }
            }

            return newVehicleOwner;
        }

        private Vehicle createNewVehicle()
        {
            bool isInputValid = false;
            int userVehicleInput = 0;
            int userEngineInput = 0;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowScreen<VehicleFactory.eVehicleType>("Please enter the number of the desired vehicle:");
                    userVehicleInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userVehicleInput, 1, Enum.GetValues(typeof(VehicleFactory.eVehicleType)).Length);
                    OutputManager.ShowScreen<VehicleFactory.eEngineType>("Please enter the number of the desired engine type:");
                    userEngineInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userEngineInput, 1, Enum.GetValues(typeof(VehicleFactory.eEngineType)).Length);
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"");
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(@"");
                }
            }

            return VehicleFactory.CreateVehicle((VehicleFactory.eVehicleType)userVehicleInput,
                (VehicleFactory.eEngineType)userEngineInput);
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
            bool isInputValid = false;

            OutputManager.ShowMessage("Please enter the vehicle license number");
            io_NewVehicleToUpdate.ID = InputManager.GetUserInput().ToString();
            OutputManager.ShowMessage("Please enter the vehicle model name");
            io_NewVehicleToUpdate.ModelName = InputManager.GetUserInput().ToString();
            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter current engine energy.");
                    io_NewVehicleToUpdate.Engine.CurrentEnergy = InputManager.GetInputAndConvertToFloat();
                    OutputManager.ShowMessage("Please enter the wheels manufacturer.");
                    io_NewVehicleToUpdate.SetWheelsManufacturerName(InputManager.GetUserInput().ToString());
                    OutputManager.ShowMessage("Please enter the current wheels' air pressure.");
                    io_NewVehicleToUpdate.SetWheelsAirPressure(InputManager.GetInputAndConvertToFloat());
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(@"");
                }
                catch (ArgumentException ex)
                {
                    OutputManager.ShowErrorMessage(@"");
                }
            }
        }

        private void getCarProperties(ref Car io_CarToUpdate)
        {
            bool isInputValid = false;
            int userInput = 0;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the amount of doors in the car.");
                    io_CarToUpdate.AmountOfDoors = InputManager.GetInputAndConvertToInt();
                    OutputManager.ShowScreen<Car.eColor>("Please enter the number of the car color:");
                    userInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userInput, 1, Enum.GetValues(typeof(Car.eColor)).Length);
                    io_CarToUpdate.CarColor = (Car.eColor)userInput;
                    isInputValid = true;
                }
                catch (FormatException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format("Invalid Input. {0}", ex.Message));
                }
                catch (ValueOutOfRangeException ex)
                {
                    OutputManager.ShowErrorMessage(string.Format(@"Invalid number.
Please enter a number between {0} to {1}.", ex.MinValue, ex.MaxValue));
                }
            }
        }

        private void getMotorbikeProperties(ref Motorbike io_MotorbikeToUpdate)
        {
            bool isInputValid = false;
            int userInput = 0;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowScreen<Motorbike.eLicenseType>("Please enter the number of the desired licence type:");
                    userInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userInput, 1, Enum.GetValues(typeof(Motorbike.eLicenseType)).Length);
                    io_MotorbikeToUpdate.License = (Motorbike.eLicenseType)InputManager.GetInputAndConvertToInt();
                    OutputManager.ShowMessage("Please enter the motorbike engine volume.");
                    io_MotorbikeToUpdate.EngineVolume = InputManager.GetInputAndConvertToInt();
                    isInputValid = true;
                }
                catch (FormatException ex)
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
        }

        private void getTruckProperties(ref Truck io_TruckToUpdate)
        {
            bool isInputValid = false;
            int userInput = 0;

            while (!isInputValid)
            {
                try
                {
                    OutputManager.ShowMessage("Please enter the truck cargo volume.");
                    io_TruckToUpdate.CargoVolume = InputManager.GetInputAndConvertToInt();
                    OutputManager.ShowMessage(@"Is the truck containing dangerous products?
1. Yes
2. No");
                    userInput = InputManager.GetInputAndConvertToInt();
                    isInRange(userInput, 1, 2);
                    io_TruckToUpdate.IsContainingDangerousProducts = userInput == 1;
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
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue, "Number");
            }
        }

        private void pressToContinue()
        {
            OutputManager.ShowMessage("Press any key to continue");
            InputManager.GetUserInput();
        }
    }
}