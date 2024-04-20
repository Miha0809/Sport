using System.Security.Claims;
using Sport.API.Models;

namespace Sport.API.Repositories.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IProfileRepository : IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    void Delete(User user);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    void Update(User user);
    
    /// <summary>
    /// 
    /// </summary>
    void Save();
}