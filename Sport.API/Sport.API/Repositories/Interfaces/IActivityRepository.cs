namespace Sport.API.Repositories.Interfaces;

using Sport.API.Interfaces.Repositories;
using Models;

/// <summary>
/// Інтерфейс репозіторія активності.
/// </summary>
public interface IActivityRepository : IDisposable, ISave
{
    /// <summary>
    /// Створення активності.
    /// </summary>
    /// <param name="activity"></param>
    void Create(Activity activity);
    
    /// <summary>
    /// Редагування активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    void Update(Activity activity);

    /// <summary>
    /// Видалення активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    void Remove(Activity activity);
}