namespace Ex03.ConsoleUI
{
    using System;

    public class Program
    {
        public static void Main()
        {
            InitiateGarage();
        }

        public static void InitiateGarage()
        {
            ViewManager newGarage = new ViewManager();
            try
            {
                newGarage.Start();
            }
            catch(Exception ex)
            {
                OutputManager.ShowErrorMessage("Unexpected Error occured, Existing now");
                OutputManager.ShowErrorMessage(ex.StackTrace);
                newGarage.pressToContinue();
            }
        }
    }
}
