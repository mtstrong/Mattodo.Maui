using Refit;

namespace Mattodo.Maui;

public class TodoTaskApiService
{
    readonly ITodoTasks _client;
    public TodoTaskApiService(ITodoTasks client)
    {
        _client = client;
    }

    public Task<List<TodoTask>> GetTodoTasks() => _client.GetTodoTasks();
}

public interface ITodoTasks
{
    [Get("/tasks")]
    public Task<List<TodoTask>> GetTodoTasks();

    //[Post("/task/{id}")]
    //public Task
}