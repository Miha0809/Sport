using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sport.API.Models;
using Sport.API.Models.DTOs.Activity;
using Sport.API.Models.DTOs.User;
using Sport.API.Services;

namespace Sport.API.Controllers;


/// <summary>
/// Контроллер активності.
/// </summary>
/// <param name="context">Контекст БД.</param>
/// <param name="userManager">Медеджер користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ActivityController(SportDbContext context, UserManager<User> userManager, IMapper mapper) : Controller
{
    /// <summary>
    /// Збереження активності.
    /// </summary>
    /// <param name="activity">Активність.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ActivityCreateDto? activity)
    {
        var user = await userManager.GetUserAsync(User);
        var a = await context.Images.ToListAsync();

        if (activity is null)
        {
            return BadRequest("Activity is null");
        }

        activity.User = mapper.Map<UserShowPublicDto>(user);
        var activity2 = mapper.Map<Activity>(activity);
        
        return Ok(activity);
    }
}