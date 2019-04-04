using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixedNotes.Views;

namespace MixedNotes.Controllers
{
    public class MetaController
    {
        private MetaView metaView;

        public MetaController()
        {
            metaView = new MetaView();
        }

        public int LogicLoop()
        {
            using (mixednotesdbEntities context = new mixednotesdbEntities())
            {
                try
                {
                    int metaViewMenuOption = metaView.SelectMetaMenu();

                    switch (metaViewMenuOption)
                    {
                        case 1:
                            NoteController noteController = new NoteController(context);
                            noteController.NotesOptions();
                            break;
                        case 2:
                            ListController listController = new ListController(context);
                            listController.ListsOptions();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    LogicLoop();
                    return 1;
                }

                return 1;
            }
        }
    }
}
