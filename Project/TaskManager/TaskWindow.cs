using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Task;

namespace TaskManager
{
    public partial class TaskWindow : UserControl
    {
        SimpleTask myTask;

        public TaskWindow(SimpleTask myTask)
        {
            InitializeComponent();
            this.myTask = myTask;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        public void SetName(string name)
        {
            label11.Text = name;
        }

        public void SetPriority(TaskPriority priority)
        {
            label8.Text = priority.ToString();
        }

        public void SetDescription(string description)
        {
            label10.Text = description;
        }

        private void TaskWindow_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.taskFactory.RemoveTask(myTask);
            Hide();
        }
    }
}
