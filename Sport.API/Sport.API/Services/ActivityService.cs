using Sport.API.Models.DTOs.Response.Activity;

namespace Sport.API.Services;

using Repositories.Interfaces;
using Models;
using Interfaces;


/// <summary>
/// Сервіс активності.
/// </summary>
/// <param name="activityRepository"></param>
/// <param name="activityTypeRepository">Інтерфейс репозіторія для типу активності.</param>
/// <param name="activitySearchRepository">Репозіторі пошуку активності.</param>
/// <param name="userSearchRepository">Репозіторі пошуку користувача.</param>
/// <param name="userRepository">Репозіторі профілю користувача.</param>
public class ActivityService(
    IActivityRepository activityRepository,
    IActivityTypeRepository activityTypeRepository,
    IActivitySearchRepository activitySearchRepository,
    IUserSearchRepository userSearchRepository,
    IUserRepository userRepository) : IActivityService
{
    /// <summary>
    /// Створення активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    /// <param name="email">Електронна пошта користувача.</param>
    /// <exception cref="NullReferenceException">Активності не існує з відповідним ідентифікатором.</exception>
    public async Task<Activity> CreateAsync(Activity activity, string email)
    {
        var user = await userSearchRepository.UserByEmailAsync(email);

        if (user is null)
        {
            throw new ArgumentNullException(nameof(email), "User is null");
        }

        var isExistsActivityType = activityTypeRepository.IsExists(activity.ActivityType);

        if (!isExistsActivityType)
        {
            throw new ArgumentNullException(nameof(activity.ActivityType), "Activity type is not correct");
        }

        var activityWithMetrics = CalculateMetrics(activity);

        user.Activities!.Add(activityWithMetrics);

        userRepository.Update(user);
        userRepository.Save();

        return activity;
    }

    /// <summary>
    /// Редагування активності.
    /// </summary>
    /// <param name="activityUpdateDto">Активність</param>
    /// <param name="location">Поточна локація.</param>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    public async Task<Activity> UpdateAsync(ActivityUpdateDto activityUpdateDto, Location location, string email)
    {
        var activity = await activitySearchRepository.GetByIdAndUserAsync(activityUpdateDto.Id, email);

        if (activity is null)
        {
            throw new ArgumentNullException(nameof(activity), "Activity id not correct");
        }

        location.DateTime = DateTime.UtcNow;
        activity.End = DateTime.UtcNow;
        activity.Distance += activityUpdateDto.Distance;
        activity = CalculateMetrics(activity);

        activity.Locations.Add(location);

        activityRepository.Update(activity);
        activityRepository.Save();

        return activity;
    }

    /// <summary>
    /// Активність авторизованого користувача.
    /// </summary>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    public async Task<List<Activity>> GetAllByUserAsync(string email)
    {
        var activities = await activitySearchRepository.GetAllByUserAsync(email);

        return activities;
    }

    /// <summary>
    /// Розрахунок часу та швидкості для активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    public Activity CalculateMetrics(Activity activity)
    {
        var start = activity.Start;
        var end = activity.End;

        var time = end.Ticks - start.Ticks;
        var speed = 0.0;

        if (time > 0)
        {
            var hours = time / (3600000.0 * 10000);
            speed = activity.Distance / hours;
        }

        activity.Speed = speed;
        activity.Time = end - start;

        return activity;
    }

    /// <summary>
    /// Всі активності.
    /// </summary>
    public async Task<List<Activity>> GetAllAsync()
    {
        var activities = await activitySearchRepository.GetAllAsync();

        return activities;
    }

    /// <summary>
    /// Активність по ідентифікатору.
    /// </summary>
    /// <param name="id">Ідентифікатор активності.</param>
    /// <exception cref="NullReferenceException">Активності не існує з відповідним ідентифікатором.</exception>
    public async Task<Activity> GetByIdAsync(int id)
    {
        var activity = await activitySearchRepository.GetByIdAsync(id);

        if (activity is null)
        {
            throw new ArgumentNullException(nameof(id), "Activity with this id does not exist");
        }

        return activity;
    }
}