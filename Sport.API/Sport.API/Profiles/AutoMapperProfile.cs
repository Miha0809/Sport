using Sport.API.Models.DTOs.Response.Image;

namespace Sport.API.Profiles;

using AutoMapper;

using Models;
using Models.DTOs.Response.Activity;
using Models.DTOs.Response.User;

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
        CreateMap<ActivityType, ActivityTypeDto>().ReverseMap();
        CreateMap<Activity, ActivityCreateDto>().ReverseMap();
        CreateMap<Activity, ActivityShowPublicDto>();
    }
}