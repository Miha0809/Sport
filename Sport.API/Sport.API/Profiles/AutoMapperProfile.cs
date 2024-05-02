namespace Sport.API.Profiles;

using AutoMapper;

using Models.DTOs.Response.Location;
using Models.DTOs.Response.Image;
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
        CreateMap<Image, ImageDto>().ReverseMap();
        CreateMap<ActivityType, ActivityTypeDto>().ReverseMap();
        CreateMap<Activity, ActivityCreateDto>().ReverseMap();
        CreateMap<Activity, ActivityShowPublicDto>();
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<Activity, ActivityUpdateDto>();
    }
}