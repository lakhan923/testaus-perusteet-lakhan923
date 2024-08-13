using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public record TodoTask //find out about the function of the record
    {
        public int Id { get; init; } // Immutable after initialization
        public string TaskDescription { get; init; }
        public DateTime DueDate { get; init; }
        public bool IsCompleted { get; init; }

        // Constructor to initialize all properties
        public TodoTask(string taskDescription, DateTime dueDate, bool isCompleted = false)
        {
            TaskDescription = taskDescription;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }

        // Override ToString for a readable representation
        public override string ToString()
        {
            return $"Id: {Id}, Task Description: {TaskDescription}, Is Completed: {IsCompleted}, Due Date: {DueDate}";
        }
    }
}
