using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Task;

namespace TaskManager
{
    internal static class Program
    {
        public static TaskFactory taskFactory;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            taskFactory = new TaskFactory();
            Application.Run(new Form1());
        }
    }
}
