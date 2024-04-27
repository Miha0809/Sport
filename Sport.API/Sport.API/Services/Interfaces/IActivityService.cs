using Sport.API.Models;

namespace Sport.API.Services.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IActivityService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="activity"></param>
    /// <param name="email"></param>
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