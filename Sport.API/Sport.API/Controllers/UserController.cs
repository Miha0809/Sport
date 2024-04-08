using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sport.API.Models.DTOs.User;
using Sport.API.Services;

namespace Sport.API.Controllers;

/// <summary>
/// Котнроллер для роботи з користувачами для пошуку.
/// </summary>
/// <param name="context"></param>
/// <param name="mapper"></param>
public class UserController(SportDbContext context, IMapper mapper) : Controller
{
    /// <summary>
    /// Користувач по електронній пошті.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    /// <returns></returns>
    [HttpGet("{email}")]
    public async Task<IActionResult> UserByEmail(string email)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Email!.Equals(email));

        if (user is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<UserPublicShowDto>(user));
    }
}