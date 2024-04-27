using Sport.API.Contexts;
using Sport.API.Repositories.Interfaces;

namespace Sport.API.Repositories;

/// <summary>
/// Інтерфейс репозіторія для типу активності.
/// </summary>
public class ActivityTypeRepository(SportDbContext context) : IActivityTypeRepository
{
    /// <summary>
    /// Чи існує тип активності.
    /// </summary>
    /// <param name="type">Тип активності.</param>
    public bool IsExists(string type)
    {
        var isExistsActivityType = context.ActivityTypes.FirstOrDefault(a => a.Name.ToUpper().Equals(type.ToUpper())) is not null;

        return isExistsActivityType;
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