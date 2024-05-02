namespace Sport.API.Repositories.Interfaces;

/// <summary>
/// Інтерфейс репозіторія для типу активності.
/// </summary>
public interface IActivityTypeRepository
{
    /// <summary>
    /// Чи інсує сутність.
    /// </summary>
    /// <param name="data">Сутність.</param>
    bool IsExists(string data);
}