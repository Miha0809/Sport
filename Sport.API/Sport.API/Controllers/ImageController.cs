using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Models;
using Sport.API.Models.DTOs;
using Sport.API.Models.DTOs.User;
using Sport.API.Services;

namespace Sport.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ImageController(SportDbContext context, UserManager<User> userManager, IMapper mapper) : Controller
{
    /// <summary>
    /// Добавлення картонок.
    ///
    /// <remarks>
    ///
    /// [
    ///     {
    ///         "link": "https://img.freepik.com/free-photo/painting-mountain-lake-with-mountain-background_188544-9126.jpg"
    ///     },
    ///     {
    ///         "link": "https://images.ctfassets.net/hrltx12pl8hq/28ECAQiPJZ78hxatLTa7Ts/2f695d869736ae3b0de3e56ceaca3958/free-nature-images.jpg?fit=fill&w=1200&h=630"
    ///     },
    ///     {
    ///         "link": "https://cdn.pixabay.com/photo/2016/05/05/02/37/sunset-1373171_1280.jpg"
    ///     }
    /// ]
    /// 
    /// </remarks>
    /// </summary>
    /// <param name="images">Картинки.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] List<ImageDto>? images)
    {
        var user = await userManager.GetUserAsync(User);
        var validImages = images?.Where(image => Regex.IsMatch(image.Link, @"\.jpg|\.jpeg|\.svg|\.png", RegexOptions.IgnoreCase)).ToList();
        
        if (images is null || user is null || validImages is null || validImages.Count == 0)
        {
            return BadRequest();
        }

        user.Images!.AddRange(mapper.Map<List<ImageDto>, List<Image>>(validImages));

        await context.Images!.AddRangeAsync(mapper.Map<List<ImageDto>, List<Image>>(validImages));
        await context.SaveChangesAsync();
        
        return Ok(mapper.Map<UserShowDto>(user));
    }
}