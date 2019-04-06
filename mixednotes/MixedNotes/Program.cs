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
        static void Main(string[] args)
        {
            MainController mainController = new MainController();
            Environment.Exit(mainController.LogicLoop());
        }
    }
}