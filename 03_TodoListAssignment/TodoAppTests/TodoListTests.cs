using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TodoApp;

namespace TodoAppTests
{
    [TestClass]
    public class TodoListTests
    {
        [TestMethod]
        public void AddItemToList_SingleTask_TaskAddedSuccessfully()
        {
            // Arrange
            var todoList = new TodoList();
            var task = new TodoTask("Do the dishes", DateTime.Now);

            // Act
            todoList.AddItemToList(task);

            // Assert
            var tasks = todoList.GetAllTasks().ToList();
            Assert.AreEqual(1, tasks.Count, "Task was not added to the list.");
            Assert.AreEqual("Do the dishes", tasks[0].TaskDescription, "Task description does not match.");
        }

        [TestMethod]
        public void AddItemToList_MultipleTasks_CounterIncrementingCorrectly()
        {
            // Arrange
            var todoList = new TodoList();
            var task1 = new TodoTask("Task 1", DateTime.Now);
            var task2 = new TodoTask("Task 2", DateTime.Now);

            // Act
            todoList.AddItemToList(task1);
            todoList.AddItemToList(task2);

            // Assert
            var tasks = todoList.GetAllTasks().ToList();
            Assert.AreEqual(2, tasks.Count, "Tasks were not added to the list.");
            Assert.AreEqual(1, tasks[0].Id, "Task 1 Id is incorrect.");
            Assert.AreEqual(2, tasks[1].Id, "Task 2 Id is incorrect.");
        }

        [TestMethod]
        public void AddItemToList_TaskWithSpecialCharacters_Success()
        {
            // Arrange
            var todoList = new TodoList();
            var task = new TodoTask("Buy groceries @ K-market!", DateTime.Now);

            // Act
            todoList.AddItemToList(task);

            // Assert
            var tasks = todoList.GetAllTasks().ToList();
            Assert.AreEqual(1, tasks.Count, "Task was not added to the list.");
            Assert.AreEqual("Buy groceries @ K-market!", tasks[0].TaskDescription, "Task description with special characters is incorrect.");
        }


        //Remove item from list

        [TestMethod]
        public void RemoveItemFromList_ItemRemovedSuccessfully()
        {
            // Arrange
            var todoList = new TodoList();
            var task = new TodoTask("Do the dishes", DateTime.Now);
            todoList.AddItemToList(task);

            // Act
            var taskToRemove = todoList.GetAllTasks().First(); // Get the task with the assigned Id
            todoList.RemoveItemFromList(taskToRemove);

            // Assert
            var tasks = todoList.GetAllTasks().ToList();
            Assert.AreEqual(0, tasks.Count, "Item was not removed from the list.");
        }


        [TestMethod]
        public void RemoveItemFromList_RemoveFromEmptyList_NoError()
        {
            // Arrange
            var todoList = new TodoList();
            var task = new TodoTask("Do the dishes", DateTime.Now);

            // Act
            todoList.RemoveItemFromList(task);

            // Assert
            var tasks = todoList.GetAllTasks().ToList();
            Assert.AreEqual(0, tasks.Count, "Removing from an empty list should not cause errors.");
        }

        [TestMethod]
        public void RemoveItemFromList_RemoveLastTask_ListIsEmpty()
        {
            // Arrange
            var todoList = new TodoList();
            var task = new TodoTask("Do the dishes", DateTime.Now);
            todoList.AddItemToList(task); // Adding one task to the list

            // Act
            var taskToRemove = todoList.GetAllTasks().First(); // Get the task with the assigned Id
            todoList.RemoveItemFromList(taskToRemove); // Removing the only task in the list

            // Assert
            var tasks = todoList.GetAllTasks().ToList(); // Get all tasks from the list
            Assert.AreEqual(0, tasks.Count, "The list should be empty after removing the last task.");
        }


        // tests for complete item function

        [TestMethod]
        public void CompleteItem_MarkAsDone_ItemCompleted()
        {
            // Arrange
            var todoList = new TodoList();
            var task = new TodoTask("Do the dishes", DateTime.Now);
            todoList.AddItemToList(task);

            // Act
            todoList.CompleteItem(1);

            // Assert
            var tasks = todoList.GetAllTasks().ToList();
            Assert.AreEqual(0, tasks.Count, "Completed item was not removed from the list.");
        }

        [TestMethod]
        public void CompleteItem_MarkLastTaskAsDone()
        {
            // Arrange
            var todoList = new TodoList();
            var task = new TodoTask("Do the dishes", DateTime.Now);
            todoList.AddItemToList(task);

            // Act
            todoList.CompleteItem(1);

            // Assert
            var tasks = todoList.GetAllTasks().ToList();
            Assert.AreEqual(0, tasks.Count, "Last task should be removed after being completed.");
        }

        [TestMethod]
        public void CompleteItem_MarkNonExistentTaskAsDone()
        {
            // Arrange
            var todoList = new TodoList();

            // Act
            todoList.CompleteItem(999); // Non-existent task Id

            // Assert
            var tasks = todoList.GetAllTasks().ToList();
            Assert.AreEqual(0, tasks.Count, "Completing a non-existent task should not affect the list.");
        }

    }
}