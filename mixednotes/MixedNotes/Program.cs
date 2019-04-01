using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixedNotes.Controllers;
using MixedNotes.Views;

namespace MixedNotes
{
    public static class Program
    {
        public static NoteController noteController = new NoteController(new mixednotesdbEntities());
        public static ListController listController = new ListController(new mixednotesdbEntities());
        public static TaskController taskController = new TaskController(new mixednotesdbEntities());

        static void Main(string[] args)
        {
            WindowSettings();
            StartMenu();
        }

        /// <summary>
        /// Changes window's colors
        /// </summary>
        private static void WindowSettings()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.Title = "MixedNotes.exe";
        }

        public static void StartMenu()
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1. Open notes");
            Console.WriteLine("2. Open TODO lists");
            Console.WriteLine("3. Exit");

            int inputCommand = int.Parse(Console.ReadLine());

            switch (inputCommand)
            {
                case 1:
                    OpenNotes();
                    break;

                case 2:
                    OpenTODOLists();
                    break;

                case 3:
                    Exit();
                    break;
            }
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Have a good day!");
            Environment.Exit(0);
        }
    }
}