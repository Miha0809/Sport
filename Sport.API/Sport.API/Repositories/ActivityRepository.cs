namespace Sport.API.Repositories;

using Contexts;
using Models;
using Interfaces;

/// <summary>
/// Репозіторі активності.
/// </summary>
/// <param name="context">Контекст БД.</param>
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
}