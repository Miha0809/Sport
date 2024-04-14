using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sport.API.Models;
using Sport.API.Models.DTOs.Requests;
using Sport.API.Models.DTOs.User;
using Sport.API.Services;

namespace Sport.API.Controllers;

/// <summary>
/// Контроллер для пошуку користувачів.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SearchController(SportDbContext context, UserManager<User> userManager, IMapper mapper) : Controller
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Електронна пошта.</param>
    /// <returns></returns>
    [HttpPost("email")]
    public async Task<IActionResult> Email([FromBody] SearchByEmailRequest request)
    {
        var user = await context.Users.FirstOrDefaultAsync(user =>
            IsValidEmail(user.Email!) && user.Email!.Equals(request.Email));
        return Ok(mapper.Map<UserShowPublicDto>(user));
    }

    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Ім'я та/або прізвище</param>
    /// <returns></returns>
    [HttpPost("full_name")]
    public async Task<IActionResult> FullName([FromBody] SearchByFullNameRequset request)
    {
        var user = await userManager.GetUserAsync(User);
        var fullName = request.FullName.Split(' ');
        var firstName = fullName[0];
        var lastName = fullName[1];
        var users = await context.Users.Where(_user =>
                _user.FirstName!.Equals(firstName) &&
                _user.LastName!.Equals(lastName) &&
                !_user.Email!.Equals(user!.Email))
            .ToListAsync();

        return Ok(mapper.Map<List<User>, List<UserShowPublicDto>>(users));
    }

    /// <summary>
    /// Перевіряє на валідність електронну пошту.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    /// <returns></returns>
    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^\w+@\w{2,}\.\w{2,}$");
    }
}