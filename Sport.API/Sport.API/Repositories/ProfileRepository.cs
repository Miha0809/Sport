using System.Security.Claims;
using Sport.API.Models;
using Sport.API.Repositories.Interfaces;
using Sport.API.Services;

namespace Sport.API.Repositories;

/// <summary>
/// 
/// </summary>
/// <param name="context"></param>
public class ProfileRepository(SportDbContext context) : IProfileRepository
{
    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <param name="user">Користувач.</param>
    public void Delete(User user)
    {
        context.Users.Remove(user!);
    }
    
    /// <summary>
    /// Редагування профілю.
    /// </summary>
    /// <param name="user">Відредагований користувач.</param>
    /// <returns></returns>
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
    protected virtual void Dispose(bool disposing)
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