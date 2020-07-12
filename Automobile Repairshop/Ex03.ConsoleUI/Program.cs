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
                OutputManager.ShowErrorMessage(string.Format(@"Unexpected Error occured, Existing now.
Error message: {0}", ex.Message));
                newGarage.pressToContinue();
            }
        }
    }
}