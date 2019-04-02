using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MixedNotes.Views;

namespace MixedNotes.Controllers
{
    public class NoteController
    {
        private NoteView NoteView;

        public NoteController(mixednotesdbEntities MixedNotesDbEntities)
        {
            NoteView = new NoteView();

            int menuOption = NoteView.SelectNoteMenu();

            switch (menuOption)
            {
                case 1:
                    NoteView.PrintAllNotes(GetAllNotes());
                    break;
                case 2:
                    NoteView.GetNoteValues();
                    AddNote();
                    break;
                case 3:
                    break;
            }

        }

        /// <summary>
        /// Adds the note in the db
        /// </summary>
        /// <param name="note"></param>
        public void AddNote()
        {
            note note = new note();
            note.content = NoteView.Content;
            MixedNotesDbEntities.notes.Add(note);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Edits the note's content
        /// </summary>
        public void EditNote(note changedNote)
        {
            note note = MixedNotesDbEntities.notes.Find(changedNote.note_id);

            MixedNotesDbEntities.Entry(note).CurrentValues.SetValues(changedNote);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Removes the note from the db
        /// </summary>
        /// <param name="note"></param>
        public void RemoveNote(note note)
        {
            MixedNotesDbEntities.notes.Remove(note);
            MixedNotesDbEntities.SaveChanges();
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
