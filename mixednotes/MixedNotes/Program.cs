using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new mixednotesdbEntities())
            {
                var notes = db.notes.ToList();

                note test = new note();

                test.content = "TestNoteyadayada";

                db.notes.Add(test);

                db.SaveChanges();
            }
        }
    }
}
