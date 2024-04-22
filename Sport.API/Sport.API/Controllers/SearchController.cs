using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Models;
using Sport.API.Models.DTOs.Requests.Search;
using Sport.API.Models.DTOs.Response.User;
using Sport.API.Repositories.Interfaces;
using Sport.API.Services.Interfaces;

namespace Sport.API.Controllers;

/// <summary>
/// Контроллер для пошуку користувачів.
/// </summary>
/// <param name="searchService">Репозіторі авторизованого користувача.</param>
/// <param name="userRepository">Репозіторі авторизованого користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SearchController(ISearchService searchService, IUserRepository userRepository, IMapper mapper) : Controller
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Електронна пошта.</param>
    [HttpPost("email")]
    public async Task<IActionResult> Email([FromBody] SearchByEmailRequest request)
    {
        try
        {
            var user = await searchService.EmailAsync(request);
            return Ok(mapper.Map<UserShowPublicDto>(user));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    /// <summary>
    /// Пошук користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="request">Ім'я та/або прізвище</param>
    [HttpPost("full_name")]
    public async Task<IActionResult> FullName([FromBody] SearchByFullNameRequest request)
    {
        try
        {
            var user = await userRepository.GetUserAsync(User);
            var users = await searchService.FullNameAsync(user!, request);
            return Ok(mapper.Map<List<User>, List<UserShowPublicDto>>(users));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}