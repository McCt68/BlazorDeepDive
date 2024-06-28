namespace TodoApp.Models
{

    // This is like an in memory repository
    public static class ToDoItemsRepository
    {
        private static List<TodoItem> todoItems = new List<TodoItem>
        {
            new TodoItem{Id = 1, Name ="Støvsuge", DateCompleted = DateTime.Now},
            new TodoItem{Id = 2, Name ="Vaske Tøj", DateCompleted = DateTime.Now},
            new TodoItem{Id = 3, Name ="Rengøre Bil", DateCompleted = DateTime.Now},
            new TodoItem{Id = 4, Name ="Bakke Tur"},
            new TodoItem{Id = 5, Name ="Læse Docs"},
        };        

        // Get using LINQ to order how the list is displayed
        public static List<TodoItem> GetTodoItems() 
        {
            var sortedItems = todoItems.
                OrderBy(item => item.IsCompleted) // Could also for example sort by date
                .ThenByDescending(item => item.Id)
                .ToList();
            return sortedItems;
        }

        public static void AddTodoItem(TodoItem itemToAdd)
        {
            if(todoItems.Count > 0)
            {
                var maxId = todoItems.Max(s => s.Id);
                itemToAdd.Id = maxId + 1;
                todoItems.Add(itemToAdd);
            }
            else
            {
                itemToAdd.Id = 1;
                todoItems.Add(itemToAdd);
            }
        }

        public static TodoItem? GetTodoItemById(int id)
        {
            // returns the first todoItem that match the id
            var todoItem = todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem != null)
            {
                return new TodoItem
                {
                    Id = todoItem.Id,
                    Name = todoItem.Name,
                    IsCompleted = todoItem.IsCompleted,
                    DateCompleted = DateTime.Now
                };
            }
            return null;
        }

        // Update
        public static void UpdateTodoItem(int todoItemId, TodoItem todoItem)
        {
            if (todoItemId != todoItem.Id) return;

            var todoItemToUpdate = todoItems.FirstOrDefault(x => x.Id == todoItemId);
            if (todoItemToUpdate != null)
            {
                todoItemToUpdate.Name = todoItem.Name;
            }
        }

        // Delete
        public static void DeleteTodoItem(int id)
        {
            var todoItem = todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem != null)
            {
                todoItems.Remove(todoItem);
            }
        }
    }
}
