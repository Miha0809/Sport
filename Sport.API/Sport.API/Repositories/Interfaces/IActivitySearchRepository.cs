namespace Sport.API.Repositories.Interfaces;

using Models;

/// <summary>
/// Інтерфейс репозіторія пошуку активностей.
/// </summary>
public interface IActivitySearchRepository : IDisposable
{
    /// <summary>
    /// Всі активності.
    /// </summary>
    Task<List<Activity>> GetAllAsync();

    /// <summary>
    /// Активність авторизованого користувача.
    /// </summary>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    Task<List<Activity>> GetAllByUserAsync(string email);

    /// <summary>
    /// Активність по ідентифікатору.
    /// </summary>
    /// <param name="id">Ідентифікатор активності.</param>
    Task<Activity?> GetByIdAsync(int id);
}