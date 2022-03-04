namespace FirstBlazorApp.Store.Interfaces;

public interface ICrudState
{
    bool Creating { get; init; }
    bool Updating { get; init; }
    bool Loading { get; init; }
    bool Deleting { get; init; }

}