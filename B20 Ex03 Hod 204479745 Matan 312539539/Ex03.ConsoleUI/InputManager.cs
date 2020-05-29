namespace Ex03.ConsoleUI
{
    using System;
    using System.Text;

    internal class InputManager
    {
        public static StringBuilder GetMainMenuInput()
        {
            StringBuilder userInput = new StringBuilder(Console.ReadLine());
            int result;

            if (!(int.TryParse(userInput.ToString(), out result)))
            {
                throw new FormatException();
            }

            if (result > 6 || result < 1)
            {
                throw new ArgumentException();
            }

            return userInput;
        }
    }
}
