using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Models;
using Sport.API.Models.DTOs.User;
using Sport.API.Services;

namespace Sport.API.Controllers;

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
        return Ok(mapper.Map<UserShowDto>(user));
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

        return Ok(mapper.Map<UserShowDto>(user));
    }
}