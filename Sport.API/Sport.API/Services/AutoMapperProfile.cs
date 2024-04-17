using AutoMapper;
using Sport.API.Models;
using Sport.API.Models.DTOs;
using Sport.API.Models.DTOs.Activity;
using Sport.API.Models.DTOs.User;

namespace Sport.API.Services;

/// <summary>
/// Профіль маппера об'єктів.
/// </summary>
public class AutoMapperProfile : Profile
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public AutoMapperProfile()
    {
        CreateMap<User, UserShowPublicDto>().ReverseMap();
        CreateMap<User, UserShowPrivateDto>();
        CreateMap<User, UserUpdateDto>();
        CreateMap<Image, ImageDto>();
        CreateMap<ImageDto, Image>();
        CreateMap<Activity, ActivityCreateDto>().ReverseMap();
    }
}