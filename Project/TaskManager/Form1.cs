using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TaskManager.Task;

namespace TaskManager
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.taskFactory.UpdateTask(Tasks);
        }

        Form2 f2;
        private void button1_Click_1(object sender, EventArgs e)
        {
            f2 = new Form2();

            f2.FormClosed += F2_FormClosed;

            f2.Show();
        }

        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(f2.performedAction) 
            {
                Program.taskFactory.UpdateTask(Tasks);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Select Destination";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.Filter = "Saved Task (*.svtsk) | *.svtsk";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                Program.taskFactory.SaveFile(sfd.FileName);
            }
            else
            {
                MessageBox.Show("No file found");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "Saved Task (*.svtsk) | *.svtsk";
            ofd.FilterIndex = 1;
            ofd.ShowDialog();
            if(ofd.FileName != "")
            {
                Program.taskFactory.LoadFile(ofd.FileName);
                Program.taskFactory.UpdateTask(Tasks);
            }
            else
            {
                MessageBox.Show("No file found");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: Add window to show completed tasks");
        }
    }
}
