using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes.Views
{
    public class NoteView
    {
        public string Content { get; set; }

        public NoteView()
        {
        }

        public int SelectNoteMenu()
        {
            Console.WriteLine("Notes");
            Console.WriteLine("1. View all notes");
            Console.WriteLine("2. Create new note");
            Console.WriteLine("3. Go back");

            return int.Parse(Console.ReadLine());
        }

        public void PrintAllNotes(List<note> notes)
        {
            foreach (var note in notes)
            {
                Console.WriteLine(new string('-', 20));
                Console.WriteLine($"Note id: {note.note_id}");
                Console.WriteLine($"{note.content}");
            }
        }

        public void GetNoteValues()
        {
            Console.WriteLine("Add note content");
            Content = Console.ReadLine();
        }
    }
}
