using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes.Views
{
    public class NoteView
    {
        public static void OpenNotes()
        {
            Console.Clear();

            Console.WriteLine("Notes");
            Console.WriteLine("1. View all notes");
            Console.WriteLine("2. Create new note");
            Console.WriteLine("3. Go back");

            int inputCommand = int.Parse(Console.ReadLine());


        }
    }
}
