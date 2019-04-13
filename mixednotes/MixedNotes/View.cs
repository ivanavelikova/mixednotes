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

        /// <summary>
        /// Displays content tab.
        /// </summary>
        /// <param name="menuTitle">A string variable that holds the value of the main menu title.</param>
        /// <param name="menuLines">A list that holds the values of the main menu options.</param>
        /// <param name="messageLine">A string variable that holds the value of a guide message that hints at awaited input from user.</param>
        public void UpdateMenu(string menuTitle, List<string> menuLines, string messageLine = "")
        {
            // Clears the console window.
            Console.Clear();

            // Displays menu title.
            Console.WriteLine(menuTitle + Environment.NewLine);

            // Displays menu options.
            foreach (var line in menuLines)
            {
                Console.WriteLine(line);
            }

            int longestMenuLineLenght = menuLines.Select(x => x.Length).Max();
            safeX = longestMenuLineLenght + 3;
            safeY = 2;

            // Displays separation lines.
            Separator(longestMenuLineLenght + 1);
            // Sets cursor position right after the vertical and horizontal separation lines.
            Console.SetCursorPosition(safeX, safeY);
            // Displays message.
            Console.Write(messageLine);
        }

        /// <summary>
        /// Displays sepatation lines between the menu and the content tab.
        /// </summary>
        /// <param name="offset">A variable that determines where a separation line should begin.</param>
        private void Separator(int offset)
        {
            // For loop that displays a vertical line the length of the current window height.
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                // Sets cursor position to where the beginning of the separation line should be.
                Console.SetCursorPosition(offset, i);
                // Displays a vertical line.
                Console.Write("│");
            }

            // Sets cursor position to where the beginning of the separation line should be.
            Console.SetCursorPosition(0, 1);
            // Displays a horizontal line the length of the current window width.
            Console.Write(new string('─', Console.WindowWidth));

            // Sets cursor position to where the vertical and horizontal line intersect.
            Console.SetCursorPosition(offset, 1);
            // Displays a cross.
            Console.Write("┼");
        }

        /// <summary>
        /// Clears the content tab.
        /// </summary>
        public void ClearContent()
        {
            // String variable that clears a line of the content tab, but not the menu tab and the content title field.
            string clear = new string(' ', Console.WindowWidth - safeX);
            // For loop that clears every line of the content tab.
            for (int i = safeY; i < Console.WindowHeight - safeY; i++)
            { 
                // Sets cursor position right after the vertical separation line.
                Console.SetCursorPosition(safeX, i);
                // Displays a clear line that covers a line of the content tab.
                Console.WriteLine(clear);
            }

            // Sets cursor position right after the vertical and horizontal lines.
            Console.SetCursorPosition(safeX, safeY);
        }

        /// <summary>
        /// Displays content tab title.
        /// </summary>
        /// <param name="title">A string variable that holds the value of a content title.</param>
        public void PrintContentTitle(string title)
        {
            // Sets cursor position to first row, right after the vertical separation line.
            Console.SetCursorPosition(safeX, 0);
            // Displays a clear line that covers a line of the content title.
            Console.Write(new string(' ', Console.WindowWidth - safeX));
            // Sets cursor position to first row, right after the vertical separation line.
            Console.SetCursorPosition(safeX, 0);
            // Displays content title.
            Console.Write(title);
        }

        /// <summary>
        /// Displays content.
        /// </summary>
        /// <param name="contentLines">A list that holds the values of the content tab.</param>
        /// <param name="messageLine">A string variable that holds the value of a guide message that hints at awaited input from user.</param>
        public void PrintContent(List<string> contentLines, string messageLine = "")
        {
            // For loop that displays the content tab, without title.
            for (int i = 0; i < contentLines.Count; i++)
            {
                // Sets cursor position right after the vertical and horizontal separation lines.
                Console.SetCursorPosition(safeX, i + safeY);
                // Displays a line of the content tab.
                Console.Write(contentLines[i]);
            }

            // Displays message.
            Console.Write(messageLine);
        }

        /// <summary>
        /// Displays lists content.
        /// </summary>
        /// <param name="lists">A list that holds the values of the TODO lists.</param>
        /// <param name="tasks">A list that holds the values of the tasks from the TODO lists.</param>
        public void PrintLists(List<list> lists, List<task> tasks)
        {
            int currentY = 0;

            foreach (var currentList in lists)
            {
                
                Console.SetCursorPosition(safeX, currentY + safeY);
                Console.Write(string.Format("{0,-6} {1,-14}" + Environment.NewLine, currentList.list_id, currentList.title));
                currentY++;
                if (tasks.Where(task => task.list_id == currentList.list_id).Count() > 0)
                {
                    foreach (var currentTask in tasks.Where(task => task.list_id == currentList.list_id))
                    {
                        Console.SetCursorPosition(safeX, currentY + safeY);
                        Console.Write(string.Format("{0,-6} {1,-14} {2,-11} {3,-13} {4,0}" + Environment.NewLine, "", "", currentTask.task_id, ReturnTrueOrFalse(currentTask.is_done), currentTask.content));
                        currentY++;
                    }
                }
            }

            Console.SetCursorPosition(safeX, safeY + lists.Count + tasks.Count);
        }

        /// <summary>
        /// Displays notes content.
        /// </summary>
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

        /// <summary>
        /// Fits notes content.
        /// </summary>
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

        private string ReturnTrueOrFalse(bool? is_done)
        {
            if (is_done == true)
            {
                return "Yes";
            }

            else
            {
                return "No";
            }
        }

        /// <summary>
        /// Displays editable content.
        /// </summary>
        public void PrintEditableContent(string content)
        {
            SendKeys.SendWait(content);
        }

        /// <summary>
        /// Reads input key.
        /// </summary>
        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Reads input string.
        /// </summary>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}