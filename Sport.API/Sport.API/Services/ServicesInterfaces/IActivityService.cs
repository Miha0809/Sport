namespace Sport.API.Services.ServicesInterfaces;

using Models;

/// <summary>
/// Інтерфейс сервісу активності.
/// </summary>
public interface IActivityService
{
    /// <summary>
    /// Створення активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    /// <param name="email">Електронна пошта користувача.</param>
    Task<Activity> CreateAsync(Activity activity, string email);

    /// <summary>
    /// Всі активності.
    /// </summary>
    Task<List<Activity>> GetAllAsync();

    /// <summary>
    /// Активність по ідентифікатору.
    /// </summary>
    /// <param name="id">Ідентифікатор активності.</param>
    Task<Activity> GetByIdAsync(int id);
    
    /// <summary>
    /// Активність авторизованого користувача.
    /// </summary>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    Task<List<Activity>> GetAllByUserAsync(string email);
}