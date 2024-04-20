using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Models;
using Sport.API.Models.DTOs.Response.Activity;
using Sport.API.Models.DTOs.Response.User;
using Sport.API.Repositories.Interfaces;

namespace Sport.API.Controllers;

/// <summary>
/// Контроллер активності.
/// </summary>
/// <param name="userRepository">Репозіторі авторизованого користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ActivityController(IUserRepository userRepository, IMapper mapper) : Controller
{
    /// <summary>
    /// Збереження активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ActivityCreateDto? activity)
    {
        var user = await userRepository.GetUserAsync(User);

        if (activity is null)
        {
            return BadRequest("Activity is null");
        }

        activity.User = mapper.Map<UserShowPublicDto>(user);
        var activity2 = mapper.Map<Activity>(activity);
        
        return Ok(activity);
    }
}