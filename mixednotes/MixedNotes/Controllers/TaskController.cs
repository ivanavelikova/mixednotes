using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MixedNotes.Controllers
{
    public class TaskController
    {
        public mixednotesdbEntities MixedNotesDbEntities { get; }

        public TaskController(mixednotesdbEntities mixedNotesDbEntities)
        {
            MixedNotesDbEntities = mixedNotesDbEntities;
        }

        /// <summary>
        /// Adds the task in the db
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(task task)
        {
            MixedNotesDbEntities.tasks.Add(task);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Edits the task's content
        /// </summary>
        /// <param name="changedTask"></param>
        public void EditTask(task changedTask)
        {
            task task = MixedNotesDbEntities.tasks.Find(changedTask.task_id);
            
            MixedNotesDbEntities.Entry(task).CurrentValues.SetValues(changedTask);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Removes the task from the db
        /// </summary>
        /// <param name="task"></param>
        public void RemoveTask(task task)
        {
            MixedNotesDbEntities.tasks.Remove(task);
            MixedNotesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Marks the task as done
        /// </summary>
        /// <param name="task"></param>
        public void MarkTaskDone(task task)
        {
            task.is_done = true;
            MixedNotesDbEntities.SaveChanges();
        }
    }
}
