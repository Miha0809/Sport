using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Models;
using Sport.API.Models.DTOs.User;
using Sport.API.Services;

namespace Sport.API.Controllers;

/// <summary>
/// Контроллер власного профілю.
/// </summary>
/// <param name="context">Контекст БД.</param>
/// <param name="userManager">Медеджер користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfileController(SportDbContext context, UserManager<User> userManager, IMapper mapper) : Controller
{
    /// <summary>
    /// Інформація про профіль.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(mapper.Map<UserShowPrivateDto>(user));
    }

    /// <summary>
    /// Редагувати профіль.
    /// </summary>
    /// <param name="userDto">Редаговані дані.</param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UserUpdateDto? userDto)
    {
        var user = await userManager.GetUserAsync(User);

        if (user is null || userDto is null )
        {
            return BadRequest();
        }

        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        
        context.Users.Update(user);
        await context.SaveChangesAsync();

        return Ok(mapper.Map<UserShowPrivateDto>(user));
    }

    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        var user = await userManager.GetUserAsync(User);

        if (user is null)
        {
            return BadRequest();
        }

        if (user.Images is not null)
        {
            context.Images.RemoveRange(user.Images);
        }
        
        context.Users.Remove(user);
        await context.SaveChangesAsync();

        
        return RedirectToAction("Logout");
    }

    /// <summary>
    /// Визід із профіля.
    /// </summary>
    /// <returns></returns>
    [HttpDelete("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");

        return Ok(StatusCodes.Status200OK);
    }
}