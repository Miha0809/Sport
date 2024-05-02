namespace Sport.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Models.DTOs.Response.User;
using Services.Interfaces;

/// <summary>
/// Контроллер власного профілю.
/// </summary>
/// <param name="profileService">Репозіторі профіля користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfileController(IProfileService profileService, IMapper mapper) : Controller
{
    /// <summary>
    /// Інформація про профіль.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        try
        {
            var userEmail = User.Identity!.Name!;
            var user = await profileService.ProfileAsync(userEmail);
            
            return Ok(mapper.Map<UserShowPrivateDto>(user));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    /// <summary>
    /// Редагувати профіль.
    /// </summary>
    /// <param name="userDto">Редаговані дані.</param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UserUpdateDto? userDto)
    {
        try
        {
            var userEmail = User.Identity!.Name!;
            var userUpdate = await profileService.UpdateAsync(userDto, userEmail);
            
            return Ok(mapper.Map<UserShowPrivateDto>(userUpdate));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Remove()
    {
        try
        {
            var userEmail = User.Identity!.Name!;
            await profileService.RemoveAsync(userEmail);
            
            return RedirectToAction("Logout");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    /// <summary>
    /// Вихід із профіля.
    /// </summary>
    /// <returns></returns>
    [HttpDelete("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");
        
        return Ok(StatusCodes.Status200OK);
    }
}