using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TaskManager.Task;

namespace TaskManager
{
    internal class TaskFactory
    { 
        Serializer serializer;

        public TaskFactory()
        {
            serializer = new Serializer();
        }
        public void CreateTask(SimpleTask task) 
        {
            TaskData.Instance.tasks.Add(task);
        }
        public void UpdateTask(FlowLayoutPanel Tasks)
        {
            Tasks.Controls.Clear();
            for (int i = 0; i < TaskData.Instance.tasks.Count; i++)
            {
                var task = TaskData.Instance.tasks.ElementAt(i);
                var newTask = new TaskWindow(task);
                Tasks.Controls.Add(newTask);
                newTask.Name = $"taskWindow{i}";
                var taskWindowToModify = Tasks.Controls[$"taskWindow{i}"] as TaskWindow;
                if (taskWindowToModify != null)
                {
                    taskWindowToModify.SetName(task.name);
                    taskWindowToModify.SetPriority(task.priority);
                    taskWindowToModify.SetDescription(task.description);
                }
            }
        }

        public void RemoveTask(SimpleTask task)
        {
            TaskData.Instance.tasks.Remove(task);
        }

        public async void SaveFile(string path)
        {
            await serializer.SaveFileAsync(TaskData.Instance, path);
        }

        public void LoadFile(string path)
        {
            serializer.LoadFile(path);
        }
    }

    internal class TaskData : SingletonBase<TaskData>
    {
        public HashSet<SimpleTask> tasks;
        //Add separate HashSet<SimpleTask> for completed tasks

        internal TaskData()
        {
            tasks = new HashSet<SimpleTask>();
        }

        public void SetTasks(HashSet<SimpleTask> tasks)
        {
            this.tasks = tasks;
        }
    }

    internal class Serializer
    {
        //string path = Directory.GetCurrentDirectory();
        public async System.Threading.Tasks.Task SaveFileAsync(TaskData tasks, string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    var data = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                    await writer.WriteAsync(data);
                }
                var msg = MessageBox.Show($"Save completed at {path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save error: " + ex.ToString());
            }
        }

        public void LoadFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    string json = File.ReadAllText(path);
                    var data = JsonConvert.DeserializeObject<TaskData>(json);

                    TaskData.Instance.SetTasks(data.tasks);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading file: " + ex.Message);
                }
            }
        }
    }


}
