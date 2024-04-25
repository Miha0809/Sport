using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Models;
using Sport.API.Models.DTOs.Response.Activity;
using Sport.API.Services.Interfaces;

namespace Sport.API.Controllers;

/// <summary>
/// Контроллер активності.
/// </summary>
/// <param name="activityService">Репозіторі авторизованого користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ActivityController(IActivityService activityService, IMapper mapper) : Controller
{
    /// <summary>
    /// Збереження активності.
    /// </summary>
    /// <remarks>
    /// Types:
    /// 
    ///     [
    ///         CYCLING
    ///         RUNNING
    ///         WALKING
    ///     ]
    /// </remarks>
    /// <param name="activityDto">Активність.</param>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ActivityCreateDto? activityDto)
    {
        try
        {
            var activityMapping = mapper.Map<Activity>(activityDto);
            var activity = await activityService.Create(activityMapping, User.Identity!.Name!);
            return Ok(activity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}