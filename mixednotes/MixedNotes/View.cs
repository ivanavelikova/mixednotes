using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixedNotes
{
    class View
    {
        int safeY = 0, safeX = 0;

        public void UpdateMenu(string menuTitle, List<string> menuLines, string messageLine = "")
        {
            Console.Clear();

            Console.WriteLine(menuTitle + Environment.NewLine);

            foreach (var line in menuLines)
            {
                Console.WriteLine(line);
            }

            int longestMenuLineLenght = menuLines.Select(x => x.Length).Max();
            safeX = longestMenuLineLenght + 3;
            safeY = 2;

            Separator(longestMenuLineLenght + 1);
            Console.SetCursorPosition(safeX, safeY);
            Console.Write(messageLine);
        }

        private void Separator(int offset)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(offset, i);
                Console.Write("│");
            }

            Console.SetCursorPosition(0, 1);
            Console.Write(new string('─', Console.WindowWidth));

            Console.SetCursorPosition(offset, 1);
            Console.Write("┼");
        }

        public void ClearContent()
        {
            string clear = new string(' ', Console.WindowWidth - safeX);
            for (int i = safeY; i < Console.WindowHeight - safeY; i++)
            { 
                Console.SetCursorPosition(safeX, i);
                Console.WriteLine(clear);
            }

            Console.SetCursorPosition(safeX, safeY);
        }

        public void PrintContentTitle(string title)
        {
            Console.SetCursorPosition(safeX, 0);
            Console.Write(new string(' ', Console.WindowWidth - safeX));
            Console.SetCursorPosition(safeX, 0);
            Console.Write(title);
        }

        public void PrintContent(List<string> contentLines, string messageLine = "")
        {
            for (int i = 0; i < contentLines.Count; i++)
            {
                Console.SetCursorPosition(safeX, i + safeY);
                Console.Write(contentLines[i]);
            }

            Console.Write(messageLine);
        }

        //TODO: Finish
        public void PrintLists(List<list> lists, List<task> tasks)
        {
            for (int i = 0; i < lists.Count + tasks.Count + 1; i++)
            {
                Console.SetCursorPosition(safeX, i + safeY);
                Console.Write(string.Format("{0,-6} {1,-14}" + Environment.NewLine, lists[i].list_id, lists[i].title));

                if (tasks.Where(task => task.list_id == lists[i].list_id).Count() != 0)
                {
                    foreach (var currentTask in tasks.Where(task => task.list_id == lists[i].list_id))
                    {
                        i++;
                        Console.SetCursorPosition(safeX, i + safeY);
                        Console.Write(string.Format("{0,-6} {1,-14} {2,-11} {3,-13} {4,0}" + Environment.NewLine, "", "", currentTask.task_id, currentTask.is_done, currentTask.content));
                    }
                }
            }

            Console.SetCursorPosition(safeX, safeY + lists.Count);
        }

        public void PrintNotes(List<note> notes)
        {
            List<string> lines = SplitNoteLines(GenerateNoteString(notes), Console.WindowWidth - safeX - 1);
            PrintContent(lines);
        }

        private string GenerateNoteString(List<note> notes)
        {
            string noteString = "";

            for (int i = 0; i < notes.Count; i++)
            {
                noteString = noteString + (string.Format("{0,-4} {1,0}" + Environment.NewLine, notes[i].note_id, notes[i].content));
            }

            return noteString;
        }

        private List<string> SplitNoteLines(string text, int maxLength)
        {
            List<string> lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            int count = lines.Count;

            for (int i = 0; i < count; i++)
            {
                if (lines[i].Length > maxLength)
                {
                    string newLine = string.Format("{0,-4} {1,0}" + Environment.NewLine, "", lines[i].Substring(maxLength));
                    lines.Insert(i + 1, newLine);
                    lines[i] = lines[i].Substring(0, maxLength);
                    count++;
                }
            }

            return lines;
        }

        public void PrintEditableContent(string content)
        {
            SendKeys.SendWait(content);
        }

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}