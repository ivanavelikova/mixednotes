﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes.Controllers
{
    class MainController
    {
        private View view;
        private mixednotesdbEntities context;
        private ListsController listsController;
        private NotesController notesController;

        static string mainMenuTitle = " Main menu";
        static List<string> mainMenuOptions = new List<string>() { " 1. Open TODO lists.", " 2. Open notes.", " 3. Exit." };

        /// <summary>
        /// Defines main controller.
        /// </summary>
        public MainController()
        {
            view = new View();
            context = new mixednotesdbEntities();
            listsController = new ListsController(view, context);
            notesController = new NotesController(view, context);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int LogicLoop()
        {
            try
            {
                char inputKey;

                while (true)
                {
                    view.UpdateMenu(mainMenuTitle, mainMenuOptions, "Select option ");
                    inputKey = view.ReadKey();

                    switch (inputKey)
                    {
                        case '1':
                            listsController.LogicLoop();
                            break;
                        case '2':
                            notesController.LogicLoop();
                            break;
                        case '3':
                            return 0;
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
    }
}