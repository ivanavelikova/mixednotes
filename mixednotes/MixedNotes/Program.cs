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
        static void Main(string[] args)
        {
            //Initializes the color settings.
            ColorSettings();
            //Creates main controller.
            MainController mainController = new MainController();
            //Exits the application.
            Environment.Exit(mainController.LogicLoop());
        }

        /// <summary>
        /// Initializes the color settings.
        /// </summary>
        private static void ColorSettings()
        {
            //Changes the console colors.
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            //Clears the console window.
            Console.Clear();

            //Changes the console title.
            Console.Title = "MixedNotes";
        }
    }
}