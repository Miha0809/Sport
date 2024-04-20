using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Models;
using Sport.API.Models.DTOs;
using Sport.API.Models.DTOs.Response.User;
using Sport.API.Repositories.Interfaces;

namespace Sport.API.Controllers;

/// <summary>
/// Контроллер зображень для профілю.
/// </summary>
/// <param name="userRepository"></param>
/// <param name="imageRepository"></param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ImageController(IUserRepository userRepository, IImageRepository imageRepository, IMapper mapper) : Controller
{
    /// <summary>
    /// Всі зображення.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Images()
    {
        var user = await userRepository.GetUserAsync(User);
        var images = user?.Images;
        var imagesMapping = mapper.Map<List<ImageDto>>(images);
        
        return Ok(imagesMapping);
    }
    
    /// <summary>
    /// Добавлення зображення.
    /// </summary>
    /// <remarks>
    /// Simple example:
    /// 
    ///     [
    ///         {
    ///             "link": "https://img.freepik.com/free-photo/painting-mountain-lake-with-mountain-background_188544-9126.jpg"
    ///         },
    ///         {
    ///             "link": "https://images.ctfassets.net/hrltx12pl8hq/28ECAQiPJZ78hxatLTa7Ts/2f695d869736ae3b0de3e56ceaca3958/free-nature-images.jpg"
    ///         },
    ///         {
    ///             "link": "https://cdn.pixabay.com/photo/2016/05/05/02/37/sunset-1373171_1280.jpg"
    ///         }
    ///     ]
    /// 
    /// </remarks>
    /// <param name="images">Картинки.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] List<ImageDto> images)
    {
        var user = await userRepository.GetUserAsync(User);
        var validImages = images.Where(image => IsValidImage(image.Link)).ToList();
        
        if (user is null || validImages.Count == 0)
        {
            return BadRequest();
        }

        user.Images!.AddRange(mapper.Map<List<ImageDto>, List<Image>>(validImages));
        imageRepository.Save();
                
        return Ok(mapper.Map<UserShowPrivateDto>(user));
    }
    
    /// <summary>
    /// Редагування адресу зображення.
    /// </summary>
    /// <param name="imageDto">Нове зображення.</param>
    /// <param name="oldLink">Адрес старого зображення.</param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] ImageDto imageDto, string oldLink)
    {
        var oldImage = await imageRepository.GetByLink(oldLink);
        var isValidLink = IsValidImage(imageDto.Link);
        
        if (oldImage is null || !isValidLink)
        {
            return BadRequest();
        }

        oldImage.Link = imageDto.Link;
        
        imageRepository.Update(oldImage);
        imageRepository.Save();
                
        return Ok(oldImage);
    }

    /// <summary>
    /// Перевіряє чи адресс є зображенням.
    /// </summary>
    /// <param name="link">Адрес зображення.</param>
    /// <returns></returns>
    private bool IsValidImage(string link)
    {
        return Regex.IsMatch(link, @"\.jpg|\.jpeg|\.svg|\.png", RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// Видалення зображення.
    /// </summary>
    /// <param name="link">Адрес зображення.</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Remove(string link)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            return BadRequest();
        }

        var image = await imageRepository.GetByLink(link);

        if (image == null)
        {
            return BadRequest();
        }

        imageRepository.Remove(image);
        imageRepository.Save();

        return Ok(StatusCodes.Status200OK);
    }
}