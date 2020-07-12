namespace Ex03.ConsoleUI
{
    using System;
    using System.Text;

    internal class InputManager
    {
        public static int GetInputAndConvertToInt()
        {
            StringBuilder userInput = GetUserInput();
            int           result = 0;

            if (!(int.TryParse(userInput.ToString(), out result)))
            {
                throw new FormatException("Input must contain only numbers.");
            }

            return result;
        }

        public static float GetInputAndConvertToFloat()
        {
            StringBuilder userInput = GetUserInput();
            float         result = 0;

            if (!(float.TryParse(userInput.ToString(), out result)))
            {
                throw new FormatException("Input must contain only numbers.");
            }

            return result;
        }

        public static StringBuilder GetUserInput()
        {
            StringBuilder userInput = new StringBuilder();

            userInput.Append(Console.ReadLine());

            return userInput;
        }
    }
}
