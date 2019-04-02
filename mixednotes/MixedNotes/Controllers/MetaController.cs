using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedNotes.Controllers
{
    public class MetaController
    {
        public MetaController()
        {

        }

        public int LogicLoop()
        {
            using (mixednotesdbEntities context = new mixednotesdbEntities())
            {
                NoteController noteController = new NoteController(context);
                ListController listController = new ListController(context);
                TaskController taskController = new TaskController(context);

                while (true)
                {

                }
            }

            return 1;
        }
    }
}
