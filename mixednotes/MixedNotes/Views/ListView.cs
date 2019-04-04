using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes.Views
{
    public class ListView
    {
        public string Title { get; set; }
        public List<task> Tasks { get; set; }

        public ListView()
        {

        }

        public int SelectListMenu()
        {
            Console.WriteLine("Lists");
            Console.WriteLine("1. View all lists");
            Console.WriteLine("2. Create new list");
            Console.WriteLine("3. Edit list");
            Console.WriteLine("4. Delete list");
            Console.WriteLine("5. Go back");

            return int.Parse(Console.ReadLine());
        }

        public void GetListValues()
        {
            Console.WriteLine("Add list title:");
            Title = Console.ReadLine();

            bool confirmed = false;

            string Key = string.Empty;

            do
            {
                ConsoleKey response;

                do
                {
                    Console.Write("Would you like to add a task? [y/n] ");

                    response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show

                    if (response != ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                    }

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                confirmed = response == ConsoleKey.Y;

            } while (!confirmed);

            Console.WriteLine("You chose {0}!", Key);
            Console.ReadLine();
        }

        public int GetListById()
        {
            Console.WriteLine("Enter list's id:");

            int id = int.Parse(Console.ReadLine());

            return id;
        }

        public void PrintAllLists(List<list> lists)
        {
            foreach (var list in lists)
            {
                Console.WriteLine(new string('-', 20));
                Console.WriteLine($"List id: {list.list_id}");
                Console.WriteLine($"{list.title}");
            }
        }
    }
}
