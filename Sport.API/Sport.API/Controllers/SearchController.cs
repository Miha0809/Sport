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
public class SearchController(SportDbContext context, IMapper mapper) : Controller
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Електронна пошта.</param>
    /// <returns></returns>
    [HttpPost("email")]
    public async Task<IActionResult> Email([FromBody] SearchByEmailRequest request)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Email!.Equals(request.Email));
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
        var users = await context.Users.ToListAsync();
        return Ok(mapper.Map<List<User>, List<UserShowPublicDto>>(users));
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^\w+@\w{2,}\.\w{2,}$");
    }
}