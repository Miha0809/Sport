namespace Sport.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Models;
using Models.DTOs.Response.Activity;
using Services.Interfaces;

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
    ///     ].
    /// </remarks>
    /// <param name="activityDto">Активність.</param>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ActivityCreateDto? activityDto)
    {
        try
        {
            var activityMapping = mapper.Map<Activity>(activityDto);
            var activity = await activityService.CreateAsync(activityMapping, User.Identity!.Name!);
            
            return Ok(mapper.Map<ActivityShowPublicDto>(activity));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    /// <summary>
    /// Всі активності.
    /// </summary>
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var activities = await activityService.GetAllAsync();
            
            return Ok(mapper.Map<List<Activity>, List<ActivityShowPublicDto>>(activities));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    /// <summary>
    /// Активність по ідентифікатору.
    /// </summary>
    /// <param name="id">Ідентифікатор.</param>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var activityById = await activityService.GetByIdAsync(id);
            
            return Ok(mapper.Map<ActivityShowPublicDto>(activityById));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    /// <summary>
    /// Всі активності авторизованого користувача.
    /// </summary>
    [HttpGet("user")]
    public async Task<IActionResult> GetByUser()
    {
        try
        {
            var email = User.Identity!.Name!;
            var activities = await activityService.GetAllByUserAsync(email);
            
            return Ok(mapper.Map<List<Activity>, List<ActivityShowPublicDto>>(activities));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}