using Sport.API.Models;

namespace Sport.API.Repositories.Interfaces;

/// <summary>
/// Репозіторі для профілю користувача.
/// </summary>
public interface IProfileRepository : IDisposable
{
    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <param name="user">Користувач.</param>
    void Delete(User user);

    /// <summary>
    /// Редагування профілю.
    /// </summary>
    /// <param name="user">Відредагований користувач.</param>
    /// <returns></returns>
    void Update(User user);
    
    /// <summary>
    /// Зберегти зміни.
    /// </summary>
    void Save();
}