using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes.Controllers
{
    class ListsController
    {
        private View view;
        private mixednotesdbEntities context;

        static string listsMenuTitle = " TODO lists menu";
        static List<string> mainMenuOptions = new List<string>() {" 1. Create a new TODO list.", " 2. Add a task to a list.", " 3. Complete a task in a list.", " 4. Rename a list.", " 5. Delete a list.", " 6. Go back." };
        static string listsContentTitle = string.Format("{0,-6} {1,-14} {2,-11} {3,-13} {4,0}" + Environment.NewLine, "ID", "Title", "Task ID", "Completed", "Tasks");

        public ListsController(View view, mixednotesdbEntities context)
        {
            this.view = view;
            this.context = context;
        }

        public void LogicLoop()
        {
            try
            {
                char inputKey;

                while (true)
                {
                    view.UpdateMenu(listsMenuTitle, mainMenuOptions);
                    view.PrintContentTitle(listsContentTitle);
                    view.PrintLists(context.lists.ToList(), context.tasks.ToList());
                    inputKey = view.ReadKey();

                    switch (inputKey)
                    {
                        case '1':
                            AddList();
                            break;
                        case '2':
                            AddTask();
                            break;
                        case '3':
                            CompleteTask();
                            break;
                        case '4':
                            RenameList();
                            break;
                        case '5':
                            DeleteList();
                            break;
                        case '6':
                            return;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void AddList()
        {
            view.PrintContentTitle("Adding list...");
            view.ClearContent();

            list list = new list();

            string inputTitle = view.ReadLine();

            if (inputTitle != string.Empty)
            {
                list.title = inputTitle;

                context.lists.Add(list);
                context.SaveChanges();
            }
        }

        public void AddTask()
        {
            view.PrintContentTitle(listsContentTitle);
            view.ClearContent();
            view.PrintLists(context.lists.ToList(), context.tasks.ToList());
            view.PrintContent(new List<string>(), "Add task to list with ID ");

            int listID;

            if (int.TryParse(view.ReadLine(), out listID))
            {
                view.PrintContentTitle("Adding task...");
                view.ClearContent();

                list selectedList = context.lists.SingleOrDefault(x => x.list_id == listID);

                if (selectedList != null)
                {
                    view.ClearContent();
                    view.PrintLists(new List<list>() { selectedList }, context.tasks.Where(task => task.list_id == selectedList.list_id).ToList());
                    view.PrintContent(new List<string>());
                    string newTaskContent = view.ReadLine();

                    if (newTaskContent != "")
                    {
                        task newTask = new task();
                        newTask.content = newTaskContent;
                        newTask.list_id = selectedList.list_id;
                        context.tasks.Add(newTask);
                        context.SaveChanges();
                    }
                }
            }
        }

        //TODO: finish
        public void CompleteTask()
        {
            view.PrintContentTitle(listsContentTitle);
            view.ClearContent();
            view.PrintLists(context.lists.ToList(), context.tasks.ToList());
            view.PrintContent(new List<string>(), "Complete task from list with ID ");

            int listID;

            if (int.TryParse(view.ReadLine(), out listID))
            {
                view.PrintContentTitle("Completeing task...");
                view.ClearContent();

                list selectedList = context.lists.SingleOrDefault(x => x.list_id == listID);

                if (selectedList != null)
                {
                    
                }
            }
        }

        public void RenameList()
        {
            view.PrintContentTitle(listsContentTitle);
            view.ClearContent();
            view.PrintLists(context.lists.ToList(), context.tasks.ToList());
            view.PrintContent(new List<string>(), "Rename list with ID ");

            int listID;

            if (int.TryParse(view.ReadLine(), out listID))
            {
                view.PrintContentTitle("Renaming list...");
                view.ClearContent();

                list selectedList = context.lists.SingleOrDefault(x => x.list_id == listID);

                if (selectedList != null)
                {
                    view.PrintEditableContent(selectedList.title);

                    string inputTitle = view.ReadLine();

                    if (inputTitle != string.Empty)
                    {
                        selectedList.title = inputTitle;

                        context.SaveChanges();
                    }
                }
            }
        }

        public void DeleteList()
        {
            view.PrintContentTitle(listsContentTitle);
            view.ClearContent();
            view.PrintLists(context.lists.ToList(), context.tasks.ToList());
            view.PrintContent(new List<string>(), "Delete list with ID ");

            int listID;

            if (int.TryParse(view.ReadLine(), out listID))
            {
                view.PrintContentTitle("Deleting list...");
                view.ClearContent();

                list selectedList = context.lists.SingleOrDefault(x => x.list_id == listID);

                if (selectedList != null)
                {
                    context.lists.Remove(selectedList);
                    context.SaveChanges();
                }
            }
        }
    }
}