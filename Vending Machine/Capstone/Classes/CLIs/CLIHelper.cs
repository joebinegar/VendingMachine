using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    /// <summary>
    /// Has a series of methods that return specific data types from the user
    /// </summary>
    public class CLIHelper
    {
        /// <summary>
        /// Prompts the user and retrieves the date/time from the user input
        /// </summary>
        /// <param name="message">The message to prompt the user with</param>
        /// <returns>The data/time input from the user</returns>
        public static DateTime GetDateTime(string message)
        {
            string userInput = String.Empty;
            DateTime dateValue = DateTime.MinValue;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid date format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!DateTime.TryParse(userInput, out dateValue));

            return dateValue;
        }

        /// <summary>
        /// Prompts the user and retrieves an int from the user input
        /// </summary>
        /// <param name="message">The message to prompt the user with</param>
        /// <returns>The int input from the user</returns>
        public static int GetInteger(string message)
        {
            string userInput = String.Empty;
            int intValue = 0;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!int.TryParse(userInput, out intValue));

            return intValue;

        }

        /// <summary>
        /// Prompts the user and retrieves a double from the user input
        /// </summary>
        /// <param name="message">The message to prompt the user with</param>
        /// <returns>The double input from the user</returns>
        public static double GetDouble(string message)
        {
            string userInput = String.Empty;
            double doubleValue = 0.0;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!double.TryParse(userInput, out doubleValue));

            return doubleValue;

        }

        /// <summary>
        /// Prompts the user and retrieves a bool from the user input
        /// </summary>
        /// <param name="message">The message to prompt the user with</param>
        /// <returns>The bool input from the user</returns>
        public static bool GetBool(string message)
        {
            string userInput = String.Empty;
            bool boolValue = false;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!bool.TryParse(userInput, out boolValue));

            return boolValue;
        }

        /// <summary>
        /// Prompts the user and retrieves a string from the user input
        /// </summary>
        /// <param name="message">The message to prompt the user with</param>
        /// <returns>The string input from the user</returns>
        public static string GetString(string message)
        {
            string userInput = String.Empty;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }
                
                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (String.IsNullOrEmpty(userInput));

            return userInput;
        }
    }
}
