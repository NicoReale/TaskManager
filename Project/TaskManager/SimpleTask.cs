using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Task
{
    public enum TaskPriority
    {
        LOW = 0,
        MEDIUM = 1,
        HIGH = 2
    }
    public struct SimpleTask
    {
        public string name;
        public string description;
        public TaskPriority priority;
        public DateTime expirationTime;
        private long id;
        public long _id { get; }

        public SimpleTask(string name, string description, TaskPriority priority, DateTime expiration, long id)
        {
            this.name = name;
            this.description = description;
            this.priority = priority;
            this.expirationTime = expiration;
            this.id = id;
        }
    }
}
