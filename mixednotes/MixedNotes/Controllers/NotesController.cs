using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes.Controllers
{
    class NotesController
    {
        private View view;
        private mixednotesdbEntities context;

        static string notesMenuTitle = " Notes menu";
        static List<string> mainMenuOptions = new List<string>() { " 1. Create a new note.", " 2. Edit a note.", " 3. Delete a note.", " 4. Go back." };
        static string notesContentTitle = string.Format("{0,-4} {1,0}" + Environment.NewLine, "ID", "Content");

        public NotesController(View view, mixednotesdbEntities context)
        {
            this.view = view;
            this.context = context;
        }

        public void LogicLoop()
        {
            try
            {
                char inputKey;

                while (true)
                {
                    view.UpdateMenu(notesMenuTitle, mainMenuOptions);
                    view.PrintContentTitle(notesContentTitle);
                    view.PrintNotes(context.notes.ToList());
                    inputKey = view.ReadKey();

                    switch (inputKey)
                    {
                        case '1':
                            AddNote();
                            break;
                        case '2':
                            EditNote();
                            break;
                        case '3':
                            DeleteNote();
                            break;
                        case '4':
                            return;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void AddNote()
        {
            view.PrintContentTitle("Adding note...");
            view.ClearContent();

            note note = new note();

            string inputContent = view.ReadLine();

            if (inputContent != string.Empty)
            {
                note.content = inputContent;

                context.notes.Add(note);
                context.SaveChanges();
            }
        }

        public void EditNote()
        {
            view.PrintContentTitle(notesContentTitle);
            view.ClearContent();
            view.PrintNotes(context.notes.ToList(), 1);
            view.PrintContent(new List<string>() { "Edit note with ID " });

            int noteID;

            if (int.TryParse(view.ReadLine(), out noteID))
            {
                view.PrintContentTitle("Editing note...");
                view.ClearContent();

                note selectedNote = context.notes.SingleOrDefault(x => x.note_id == noteID);

                if (selectedNote != null)
                {
                    view.PrintEditableContent(selectedNote.content);

                    string inputContent = view.ReadLine();

                    if (inputContent != string.Empty)
                    {
                        selectedNote.content = inputContent;

                        context.SaveChanges();
                    }
                }
            }
        }

        public void DeleteNote()
        {
            view.PrintContentTitle(notesContentTitle);
            view.ClearContent();
            view.PrintNotes(context.notes.ToList(), 1);
            view.PrintContent(new List<string>() { "Delete note with ID " });

            int noteID;

            if (int.TryParse(view.ReadLine(), out noteID))
            {
                view.PrintContentTitle("Deleting note...");
                view.ClearContent();

                note selectedNote = context.notes.SingleOrDefault(x => x.note_id == noteID);

                if (selectedNote != null)
                {
                    context.notes.Remove(selectedNote);
                    context.SaveChanges();
                }
            }
        }
    }
}