namespace Ex03.ConsoleUI
{
    using System;
    using System.Text;

    internal class InputManager
    {
        public static int GetInputAndConvertToInt()
        {
            StringBuilder userInput = new StringBuilder(Console.ReadLine());
            int result;

            if (!(int.TryParse(userInput.ToString(), out result)))
            {
                throw new FormatException();
            }

            return result;
        }

        public static float GetInputAndConvertToFloat()
        {
            StringBuilder userInput = new StringBuilder(Console.ReadLine());
            float result;

            if (!(float.TryParse(userInput.ToString(), out result)))
            {
                throw new FormatException();
            }

            return result;
        }
    }
}
