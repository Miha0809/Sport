namespace Sport.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Models;
using Models.DTOs.Requests.Search;
using Models.DTOs.Response.User;
using Services.ServicesInterfaces;

/// <summary>
/// Контроллер для пошуку користувачів.
/// </summary>
/// <param name="userSearchService">Репозіторі авторизованого користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SearchController(IUserSearchService userSearchService, IMapper mapper) : Controller
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Електронна пошта.</param>
    [HttpPost("email")]
    public async Task<IActionResult> ByEmail([FromBody] SearchByEmailRequest request)
    {
        try
        {
            var user = await userSearchService.UserByEmailAsync(request);
            
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
    /// <param name="request">Ім'я та/або прізвище</param>
    [HttpPost("full_name")]
    public async Task<IActionResult> ByFullName([FromBody] SearchByFullNameRequest request)
    {
        try
        {
            var userEmail = User.Identity!.Name!;
            var user = await userSearchService.UserByEmailAsync(userEmail);
            var users = await userSearchService.UsersByFullNameAsync(user!, request);
            
            return Ok(mapper.Map<List<User>, List<UserShowPublicDto>>(users));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }
}