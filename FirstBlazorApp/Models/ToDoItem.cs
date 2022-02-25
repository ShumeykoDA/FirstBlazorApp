namespace FirstBlazorApp.Models;

public class ToDoItem
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime? DueTime { get; set; }

    public ToDoItem(Guid id, string text, DateTime? dueTime = null)
    {
        Id = id;
        Text = text;
        DueTime = dueTime;
    }
}