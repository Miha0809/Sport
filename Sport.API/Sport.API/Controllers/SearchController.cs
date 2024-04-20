using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Models;
using Sport.API.Models.DTOs.Requests.Search;
using Sport.API.Models.DTOs.Response.User;
using Sport.API.Repositories.Interfaces;

namespace Sport.API.Controllers;

/// <summary>
/// Контроллер для пошуку користувачів.
/// </summary>
/// <param name="searchRepository">Репозіторі пошуку користувачів.</param>
/// <param name="userRepository">Репозіторі авторизованого користувача.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SearchController(ISearchRepository searchRepository, IUserRepository userRepository, IMapper mapper) : Controller
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Електронна пошта.</param>
    /// <returns></returns>
    [HttpPost("email")]
    public async Task<IActionResult> Email([FromBody] SearchByEmailRequest request)
    {
        if (!IsValidEmail(request.Email))
        {
            return BadRequest("Email is not valid");
        }
        
        var user = await searchRepository.GetUserByEmailAsync(request.Email);
        return Ok(mapper.Map<UserShowPublicDto>(user));
    }

    /// <summary>
    /// Пошук користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="request">Ім'я та/або прізвище</param>
    /// <returns></returns>
    [HttpPost("full_name")]
    public async Task<IActionResult> FullName([FromBody] SearchByFullNameRequest request)
    {
        var user = await userRepository.GetUserAsync(User);
        var fullName = request.FullName.Split(' ');
        var firstName = fullName[0];
        var lastName = fullName[1];
        var users = await searchRepository.FindUsersByFullNameAsync(firstName, lastName, user!.Email!);
        
        return Ok(mapper.Map<List<User>, List<UserShowPublicDto>>(users));
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^\w+@\w{2,}\.\w{2,}$");
    }
}