using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp
{
    public class TodoList
    {
        private readonly List<TodoTask> _tasks;
        private int _taskCounter = 0;

        /// <summary>
        /// Each time a new TodoList is created, a new list of tasks is created.
        /// </summary>
        public TodoList()
        {
            _tasks = new List<TodoTask>();
        }

        // Encapsulate the list, expose read-only access through a public method
        public IEnumerable<TodoTask> GetAllTasks()
        {
            return _tasks.AsReadOnly();
        }

        public void AddItemToList(TodoTask item)
        {
            if (string.IsNullOrWhiteSpace(item.TaskDescription))
                throw new ArgumentException("Task description cannot be empty.");

            _taskCounter++;
            var newItem = item with { Id = _taskCounter };
            _tasks.Add(newItem);
        }

        public void RemoveItemFromList(TodoTask item)
        { 
            var existingItem = _tasks.FirstOrDefault(x => x.Id == item.Id);
            if (existingItem != null)
            {
                _tasks.Remove(existingItem);
            }
        }

        public void CompleteItem(int id)
        {
            var item = _tasks.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item = item with { IsCompleted = true };
                RemoveItemFromList(item);
            }
        }
    }
}
