using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes.Views
{
    public class MetaView
    {
        public MetaView()
        {

        }

        public int SelectMetaMenu()
        {
            Console.WriteLine("Hello, what would you like to do today?");
            Console.WriteLine("1. Open all notes");
            Console.WriteLine("2. Open all TODO lists");
            Console.WriteLine("3. Exit");

            int menuOption = int.Parse(Console.ReadLine());

            return menuOption;
        }
    }
}
