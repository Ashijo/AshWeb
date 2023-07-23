using Microsoft.AspNetCore.Components;

namespace AshWeb.Client.Components.Todo;

public partial class TodoGrid
{
    [Parameter, EditorRequired]
    public List<R_Todo>? TodoList { get; set; }
    [Parameter, EditorRequired]
    public EventCallback<R_Todo> CreateNewTodoEvent { get; set; }
    [Parameter, EditorRequired]
    public EventCallback<R_Todo> DeleteTodoEvent { get; set; }

    protected string Name { get; set; } = "";
    protected string Description { get; set; } = "";

    protected override void OnParametersSet()
    {
        ArgumentNullException.ThrowIfNull(TodoList);
    }

    private async Task CreateNewTodo()
    {
        var newTodo = new R_Todo(Guid.NewGuid(), Name, Description);
        await CreateNewTodoEvent.InvokeAsync(newTodo);
        Name = "";
        Description = "";
    }

    private async Task DeleteTodo(R_Todo todo)
    {
        await DeleteTodoEvent.InvokeAsync(todo);
    }
}