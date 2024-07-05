namespace Sport.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Models;
using Models.DTOs.Response.Image;
using Services.Interfaces;

/// <summary>
/// Контроллер зображень для профілю.
/// </summary>
/// <param name="imageService">Сервіс зображень.</param>
/// <param name="mapper">Маппер об'єктів.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ImageController(IImageService imageService, IMapper mapper) : Controller
{
    /// <summary>
    /// Всі зображення авторизованого користувача.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Images()
    {
        try
        {
            var userEmail = User.Identity!.Name!;
            var images = await imageService.GetImagesAsync(userEmail);

            return Ok(mapper.Map<List<ImageDto>>(images));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
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
    /// <param name="imageCreateDtos">Зображення.</param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] List<ImageDto> imageCreateDtos)
    {
        try
        {
            var userEmail = User.Identity!.Name!;
            var imageMapping = mapper.Map<List<ImageDto>, List<Image>>(imageCreateDtos);
            var images = await imageService.AddAsync(imageMapping, userEmail);

            return Ok(mapper.Map<List<Image>, List<ImageDto>>(images));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    /// <summary>
    /// Редагування адресу зображення.
    /// </summary>
    /// <param name="imageDto">Нове зображення.</param>
    /// <param name="oldLink">Адрес старого зображення.</param>
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] ImageDto imageDto, string oldLink)
    {
        try
        {
            var imageMapping = mapper.Map<Image>(imageDto);
            var image = await imageService.UpdateAsync(imageMapping, oldLink);
            var imageMappingToDto = mapper.Map<ImageDto>(image);

            return Ok(imageMappingToDto);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    /// <summary>
    /// Видалення зображення.
    /// </summary>
    /// <param name="link">Адрес зображення.</param>
    [HttpDelete]
    public async Task<IActionResult> Remove(string link)
    {
        try
        {
            var isRemove = await imageService.RemoveAsync(link);

            return Ok(isRemove);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }
}
