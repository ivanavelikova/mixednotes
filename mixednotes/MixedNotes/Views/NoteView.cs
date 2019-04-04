using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixedNotes.Views
{
    public class NoteView
    {
        public string Content { get; set; }

        public NoteView()
        {

        }

        public int SelectNotesMenu()
        {
            Console.WriteLine("Notes");
            Console.WriteLine("1. View all notes");
            Console.WriteLine("2. Create new note");
            Console.WriteLine("3. Edit note");
            Console.WriteLine("4. Delete note");
            Console.WriteLine("5. Go back");

            int menuOption = int.Parse(Console.ReadLine());

            return menuOption;
        }

        public void GetNoteValues()
        {
            Console.WriteLine("Add note content:");
            Content = Console.ReadLine();
        }

        public int GetNoteById()
        {
            Console.WriteLine("Enter note id:");

            int id = int.Parse(Console.ReadLine());

            return id;
        }

        public string GetNoteChangedContent(string content)
        {
            Console.WriteLine("Edit note's content:");
            SendKeys.SendWait(content);

            string changedContent = Console.ReadLine();

            return changedContent;
        }

        public void PrintAllNotes(List<note> notes)
        {
            foreach (var note in notes)
            {
                Console.WriteLine(new string('-', 20));
                Console.WriteLine($"#{note.note_id}");
                Console.WriteLine($"{note.content}");
            }
        }
    }
}
