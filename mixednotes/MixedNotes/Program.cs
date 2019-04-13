using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixedNotes.Controllers;

namespace MixedNotes
{
    static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            // Initializes the color settings.
            InitializeWindow();
            // Creates main controller.
            MainController mainController = new MainController();
            // Exits the application.
            Environment.Exit(mainController.LogicLoop());
        }

        /// <summary>
        /// Initializes the color settings for the console.
        /// </summary>
        private static void InitializeWindow()
        {
            // Changes the console colors.
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            // Clears the console window.
            Console.Clear();

            // Changes the console title.
            Console.Title = "MixedNotes";
        }
    }
}