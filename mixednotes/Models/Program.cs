using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("We are live");

                    db.Notes.Add(new Note());

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
