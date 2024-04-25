using Sport.API.Contexts;
using Sport.API.Models;
using Sport.API.Repositories.Interfaces;

namespace Sport.API.Repositories;

/// <summary>
/// Репозіторі активності.
/// </summary>
public class ActivityRepository(SportDbContext context) : IActivityRepository
{
    /// <summary>
    /// Створення активності.
    /// </summary>
    /// <param name="activity"></param>
    public void Create(Activity activity)
    {
        context.Activities.Add(activity);
    }

    /// <summary>
    /// Редагування активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    public void Update(Activity activity)
    {
        context.Activities.Update(activity);
    }

    /// <summary>
    /// Видалення активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    public void Remove(Activity activity)
    {
        context.Activities.Remove(activity);
    }

    /// <summary>
    /// Збереження змін.
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