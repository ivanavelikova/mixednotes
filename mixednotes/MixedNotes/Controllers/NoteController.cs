using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MixedNotes.Controllers
{
    public class NoteController
    {
        public mixednotesdbEntities MixedNotesDbEntities { get; }

        public NoteController(mixednotesdbEntities mixedNotesDbEntities)
        {
            MixedNotesDbEntities = mixedNotesDbEntities;
        }

        /// <summary>
        /// Adds the note in the db
        /// </summary>
        /// <param name="note"></param>
        public void AddNote(note note)
        {
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
