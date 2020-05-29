namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            InitiateGarage();
        }

        public static void InitiateGarage()
        {
            ViewManager newGarage = new ViewManager();
            newGarage.Start();
        }
    }
}
