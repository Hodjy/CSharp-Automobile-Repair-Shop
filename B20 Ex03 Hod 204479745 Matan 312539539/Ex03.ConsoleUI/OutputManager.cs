namespace Ex03.ConsoleUI
{
    using System;
    using System.Text;

    static class OutputManager
    {
        public static void ShowMainMenuScreen()
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append(@"Please enter the number of which option you wish to perform:
1. Enter a new vehicle to the garage.
2. Showcase the stored vehicles ID with a filter option.
3. Change a vehicle state.
4. Inflate all vehicle's wheels to maximum capacity.
5. Refuel a vehicle by engine type.
6. Display a vehicle's full detail.
7. Exit.");
            clearScreenAndPrint(stringToPrint);
        }

        public static void ShowEnterNewVehicleScreen()
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append("");
        }

        public static void ShowAskVehicleIdMessage()
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append("Please enter the desired vehicle's ID:");
            clearScreenAndPrint(stringToPrint);
        }

        public static void ShowChangeVehicleStateScreen()
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append(@"Please enter the number of the desired vehicle's new state:
1. InRepair
2. Repaired
3. Paid");
            clearScreenAndPrint(stringToPrint);
        }

        public static void ShowInflateWheelsScreen()
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append("Wheels successfully Inflated.");
            clearScreenAndPrint(stringToPrint);
        }

        public static void ShowRechargeVehicleScreen()
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append(@"Please enter the number of the fuel type:
1. Octan98.
2. Octan96.
3. Octan95.
4. Soler.");
            clearScreenAndPrint(stringToPrint);
        }

        public static void ShowDisplayVehicleDetailsScreen()
        {

        }

        private static void clearScreenAndPrint(StringBuilder i_StringToPrint)
        {
            Console.Clear();
            Console.WriteLine(i_StringToPrint);
        }

        public static void ShowMessage(string i_StringToShow)
        {
            Console.WriteLine(i_StringToShow);
        }


        public static void ShowErrorMessage(string i_StringToShow)
        {
            Console.WriteLine(i_StringToShow);
        }
    }
}
