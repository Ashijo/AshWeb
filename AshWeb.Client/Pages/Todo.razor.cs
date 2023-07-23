namespace AshWeb.Client.Pages;

public partial class Todo
{
    public List<R_Todo> TodoList { get; private set; }

    public Todo()
    {
        TodoList = new List<R_Todo>();
    }

    private void CreateNewTodo(R_Todo todo)
    {
        TodoList.Add(todo);
    }

    private void DeleteTodo(R_Todo todo)
    {
        TodoList.Remove(todo);
    }
}