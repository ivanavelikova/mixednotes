using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MixedNotes.Views;

namespace MixedNotes.Controllers
{
    public class NoteController
    {
        private NoteView noteView;
        private MetaView metaView;
        private mixednotesdbEntities MixedNotesDbEntities;

        public NoteController(mixednotesdbEntities context)
        {
            noteView = new NoteView();
            metaView = new MetaView();
            MixedNotesDbEntities = context;
        }

        public void NotesOptions()
        {
            try
            {
                int notesMenuOption = noteView.SelectNotesMenu();

                switch (notesMenuOption)
                {
                    case 1:
                        noteView.PrintAllNotes(GetAllNotes());
                        break;

                    case 2:
                        AddNote();
                        break;

                    case 3:
                        EditNote();
                        break;

                    case 4:
                        RemoveNote();
                        break;

                    case 5:
                        metaView.SelectMetaMenu();
                        break;

                    default:
                        throw new InvalidOperationException("Invalid command!");
                }

                if (notesMenuOption != 5)
                {
                    NotesOptions();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                NotesOptions();
            }
        }

        /// <summary>
        /// Adds the note in the db
        /// </summary>
        public void AddNote()
        {
            try
            {
                note note = new note();

                noteView.GetNoteValues();

                note.content = noteView.Content;

                if (note.content.ToString() == string.Empty)
                {
                    throw new InvalidOperationException("Note's content shouldn't be empty!");
                }
                else
                {
                    MixedNotesDbEntities.notes.Add(note);
                    MixedNotesDbEntities.SaveChanges();

                    Console.WriteLine("Note added successfully!");
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Note's content shouldn't be empty!");
            }
        }

        /// <summary>
        /// Edits the note's content
        /// </summary>
        public void EditNote()
        {
            try
            {
                note note = MixedNotesDbEntities.notes.Find(noteView.GetNoteById());

                note newNote = new note();

                newNote.content = noteView.GetNoteChangedContent(note.content);

                note.content = newNote.content;

                MixedNotesDbEntities.SaveChanges();

                Console.WriteLine("Note's content changed successfully!");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Note's content couldn't be edited!");
            }
        }

        /// <summary>
        /// Removes the note from the db
        /// </summary>
        public void RemoveNote()
        {
            int id = 0;

            try
            {
                id = noteView.GetNoteById();

                note note = MixedNotesDbEntities.notes.First(n => n.note_id == id);

                MixedNotesDbEntities.notes.Remove(note);
                MixedNotesDbEntities.SaveChanges();

                Console.WriteLine($"Note removed successfully!");
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Note with Id {id} doesn't exist!");
            }
        }
        
        public note GetNote()
        {
            int id = 0;

            try
            {
                id = noteView.GetNoteById();

                return MixedNotesDbEntities.notes.First(n => n.note_id == id);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Note with Id {id} doesn't exist!");
            }
        }

        /// <summary>
        /// Lists all notes from the db
        /// </summary>
        /// <returns></returns>
        public List<note> GetAllNotes()
        {
            return MixedNotesDbEntities.notes.ToList();
        }
    }
}
