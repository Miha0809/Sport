namespace Sport.API.Repositories;

using Microsoft.EntityFrameworkCore;

using Contexts;
using Models;
using Interfaces;

/// <summary>
/// Репозіторі пошуку активності.
/// </summary>
/// <param name="context">Контекст БД.</param>
/// <param name="userSearchRepository"></param>
public class ActivitySearchRepository(SportDbContext context, IUserSearchRepository userSearchRepository) : IActivitySearchRepository
{
    /// <summary>
    /// Всі активності.
    /// </summary>
    public async Task<List<Activity>> GetAllAsync()
    {
        var activities = await context.Activities.ToListAsync();
        
        return activities;
    }

    /// <summary>
    /// Активність авторизованого користувача.
    /// </summary>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    public async Task<List<Activity>> GetAllByUserAsync(string email)
    {
        var activity = await context.Activities.Where(activity => activity.User.Email!.Equals(email)).ToListAsync();
        
        return activity;
    }

    /// <summary>
    /// Активність по ідентифікатору.
    /// </summary>
    /// <param name="id">Ідентифікатор активності.</param>
    public async Task<Activity?> GetByIdAsync(int id)
    {
        var activity = await context.Activities.FindAsync(id);
        
        return activity;
    }

    /// <summary>
    /// Активність користувача по ідентифіктаору.
    /// </summary>
    /// <param name="id">Ідентифікатор.</param>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    public async Task<Activity?> GetByIdAndUserAsync(int id, string email)
    {
        var user = await userSearchRepository.UserByEmailAsync(email);
        var activity = user?.Activities!.FirstOrDefault(activity1 => activity1.Id.Equals(id));

        return activity;
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