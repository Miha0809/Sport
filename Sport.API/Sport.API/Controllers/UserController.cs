namespace Sport.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs.Response.User;
using Services.Interfaces;

/// <summary>
/// Контроллер для пошуку користувачів.
/// </summary>
/// <param name="userSearchService">Репозіторі авторизованого користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IUserSearchService userSearchService, IMapper mapper) : Controller
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    [HttpGet("{email}")]
    public async Task<IActionResult> ByEmail(string email)
    {
        try
        {
            var user = await userSearchService.UserByEmailAsync(email);

            return Ok(mapper.Map<UserShowPublicDto>(user));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    /// <summary>
    /// Пошук користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="firstName">Ім'я</param>
    /// <param name="lastName">Ім'я</param>
    [HttpGet("{firstName}/{lastName}")]
    public async Task<IActionResult> ByFullName(string firstName, string lastName)
    {
        try
        {
            var userEmail = User.Identity!.Name!;
            var user = await userSearchService.UserByEmailAsync(userEmail);
            var users = await userSearchService.UsersByFullNameAsync(firstName, lastName);

            return Ok(mapper.Map<List<User>, List<UserShowPublicDto>>(users));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }
}
