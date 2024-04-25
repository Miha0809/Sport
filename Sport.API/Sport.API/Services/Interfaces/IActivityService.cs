using Sport.API.Models;

namespace Sport.API.Services.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IActivityService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="activity"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<Activity> Create(Activity activity, string email);
}