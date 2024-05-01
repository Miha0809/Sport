namespace Sport.API.Repositories;

using Models;
using RepositoriesInterfaces;
using Contexts;

/// <summary>
/// Репозіторі профілю користувача.
/// </summary>
/// <param name="context">Контекст БД.</param>
public sealed class ProfileRepository(SportDbContext context) : IProfileRepository
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
    
    private bool _disposed;

    /// <summary>
    /// Звільнення ресурсів.
    /// </summary>
    /// <param name="disposing">Стан.</param>
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        
        _disposed = true;
    }

    /// <summary>
    /// Звільнення ресурсів.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}