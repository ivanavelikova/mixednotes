using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MixedNotes.Controllers
{
    public class ListController
    {
        public mixednotesdbEntities MixedNotesDbEntities { get; }

        public ListController(mixednotesdbEntities mixedNotesDbEntities)
        {
            MixedNotesDbEntities = mixedNotesDbEntities;
        }

        /// <summary>
        /// Adds the list in the db
        /// </summary>
        /// <param name="list"></param>
        public void AddList(list list)
        {
            MixedNotesDbEntities.lists.Add(list);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Edits the list's content
        /// </summary>
        public void EditList(list changedList)
        {
            list list = MixedNotesDbEntities.lists.Find(changedList.list_id);

            MixedNotesDbEntities.Entry(list).CurrentValues.SetValues(changedList);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Removes the list from the db
        /// </summary>
        /// <param name="list"></param>
        public void RemoveList(list list)
        {
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
