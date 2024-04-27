namespace Sport.API.Repositories.Interfaces;

/// <summary>
/// Інтерфейс репозіторія для типу активності.
/// </summary>
public interface IActivityTypeRepository : IDisposable
{
    /// <summary>
    /// Чи існує тип активності.
    /// </summary>
    /// <param name="type">Тип активності.</param>
    bool IsExists(string type);
}