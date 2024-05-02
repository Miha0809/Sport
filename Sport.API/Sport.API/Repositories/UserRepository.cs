namespace Sport.API.Repositories;

using Models;
using Interfaces;
using Contexts;

/// <summary>
/// Репозіторі профілю користувача.
/// </summary>
/// <param name="context">Контекст БД.</param>
public sealed class UserRepository(SportDbContext context) : IUserRepository
{
    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <param name="user">Користувач.</param>
    public void Remove(User user)
    {
        context.Users.Remove(user!);
    }
    
    /// <summary>
    /// Редагування профілю.
    /// </summary>
    /// <param name="user">Відредагований користувач.</param>
    public void Update(User user)
    {
        context.Users.Update(user);
    }

    /// <summary>
    /// Зберегти зміни.
    /// </summary>
    public void Save() 
    {
        context.SaveChanges();
    }
}