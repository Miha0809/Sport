namespace Sport.API.Services;

using Sport.API.Repositories.Interfaces;
using Models;
using Interfaces;

/// <summary>
/// Сервіс активності.
/// </summary>
public class ActivityService(IActivityTypeRepository activityTypeRepository, IActivitySearchRepository activitySearchRepository, ISearchRepository searchRepository, IProfileRepository profileRepository) : IActivityService
{
    /// <summary>
    /// Створення активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    /// <param name="email">Електронна пошта користувача.</param>
    /// <exception cref="NullReferenceException">Активності не існує з відповідним ідентифікатором.</exception>
    public async Task<Activity> CreateAsync(Activity activity, string email)
    {
        var user =  await searchRepository.GetUserByEmailAsync(email);

        if (user is null)
        {
            throw new ArgumentNullException(nameof(email), "User is null");
        }

        var isExistsActivityType = activityTypeRepository.IsExists(activity.ActivityType);

        if (!isExistsActivityType)
        {
            throw new ArgumentNullException(nameof(activity.ActivityType), "Activity type is not correct");
        }
        
        user.Activities!.Add(activity);

        profileRepository.Update(user);
        profileRepository.Save();

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

    /// <summary>
    /// Активність авторизованого користувача.
    /// </summary>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    public async Task<List<Activity>> GetAllByUserAsync(string email)
    {
        var activities = await activitySearchRepository.GetAllByUserAsync(email);
        
        return activities;
    }
}