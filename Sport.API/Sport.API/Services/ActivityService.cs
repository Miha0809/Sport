using Sport.API.Contexts;
using Sport.API.Models;
using Sport.API.Repositories.Interfaces;
using Sport.API.Services.Interfaces;

namespace Sport.API.Services;

/// <summary>
/// Сервіс активності.
/// </summary>
public class ActivityService(SportDbContext context, ISearchRepository searchRepository, IProfileRepository profileRepository) : IActivityService
{
    /// <summary>
    /// Створення активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    /// <param name="email">Електронна пошта користувача.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<Activity> Create(Activity activity, string email)
    {
        var user =  await searchRepository.GetUserByEmailAsync(email);

        if (user is null)
        {
            throw new NullReferenceException("user is null");
        }

        var isExistsActivityType = context.ActivityTypes.FirstOrDefault(a => a.Name.ToLower().Equals(activity.ActivityType.ToLower())) is not null;

        if (!isExistsActivityType)
        {
            throw new NullReferenceException("Activity type is not correct");
        }
        
        user.Activities!.Add(activity);

        profileRepository.Update(user);
        profileRepository.Save();

        return activity;
    }
}