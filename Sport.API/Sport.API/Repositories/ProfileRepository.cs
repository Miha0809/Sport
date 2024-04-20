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
    /// 
    /// </summary>
    /// <returns></returns>
    public void Delete(User user)
    {
        context.Users.Remove(user!);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public void Update(User user)
    {
        context.Users.Update(user);
    }

    /// <summary>
    /// 
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