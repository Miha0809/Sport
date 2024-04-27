namespace Sport.API.Repositories.Interfaces;

using Models;

/// <summary>
/// Інтерфейс репозіторія профілю користувача.
/// </summary>
public interface IProfileRepository : IDisposable
{
    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <param name="user">Користувач.</param>
    void Remove(User user);

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