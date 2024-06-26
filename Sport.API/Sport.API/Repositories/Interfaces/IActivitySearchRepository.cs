namespace Sport.API.Repositories.Interfaces;

using Models;

/// <summary>
/// Інтерфейс репозіторія пошуку активностей.
/// </summary>
public interface IActivitySearchRepository
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

    /// <summary>
    /// Активність користувача по ідентифіктаору.
    /// </summary>
    /// <param name="id">Ідентифікатор.</param>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    Task<Activity?> GetByIdAndUserAsync(int id, string email);
}