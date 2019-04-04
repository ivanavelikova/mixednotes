using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MixedNotes.Views;

namespace MixedNotes.Controllers
{
    public class ListController
    {
        private ListView listView;
        private MetaView metaView;
        private mixednotesdbEntities MixedNotesDbEntities;

        public ListController(mixednotesdbEntities context)
        {
            listView = new ListView();
            metaView = new MetaView();
            MixedNotesDbEntities = context;
        }

        public void ListsOptions()
        {
            try
            {
                int listsMenuOptions = listView.SelectListMenu();

                switch (listsMenuOptions)
                {
                    case 1:
                        listView.PrintAllLists(GetAllLists());
                        break;

                    case 2:
                        AddList();
                        break;

                    case 3:
                        EditList();
                        break;

                    case 4:
                        RemoveList();
                        break;

                    case 5:
                        metaView.SelectMetaMenu();
                        break;

                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                ListsOptions();
            }
        }

        /// <summary>
        /// Adds the list in the db
        /// </summary>
        public void AddList()
        {
            list list = new list();
            list.title = listView.Title;
            list.tasks = listView.Tasks;

            MixedNotesDbEntities.lists.Add(list);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Edits the list's content
        /// </summary>
        public void EditList()
        {
            list list = MixedNotesDbEntities.lists.Find();

            //MixedNotesDbEntities.Entry(list).CurrentValues.SetValues();
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Removes the list from the db
        /// </summary>
        public void RemoveList()
        {
            int id = listView.GetListById();

            list list = MixedNotesDbEntities.lists.First(l => l.list_id == id);

            MixedNotesDbEntities.lists.Remove(list);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Lists all lists from the db
        /// </summary>
        /// <returns></returns>
        public List<list> GetAllLists()
        {
            return MixedNotesDbEntities.lists.ToList();
        }
    }
}
