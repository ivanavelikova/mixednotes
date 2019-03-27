using System;

namespace Models
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MixedNotesDbContext())
            {
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    db.Database.Connection.Open();

                    var note = new Note();
                    note.Content = "asdad";

                    db.Notes.Add(note);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                db.Database.Connection.Close();
                Console.WriteLine("Done.");
            }
        }
    }
}
