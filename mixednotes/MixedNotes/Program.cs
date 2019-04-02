using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixedNotes.Controllers;
using MixedNotes.Views;

namespace MixedNotes
{
    static class Program
    {
        static void Main(string[] args)
        {
            MetaController metaController = new MetaController();
            Environment.Exit(metaController.LogicLoop());
        }
    }
}