using AutoMapper;
using Sport.API.Models;
using Sport.API.Models.DTOs;
using Sport.API.Models.DTOs.User;

namespace Sport.API.Services;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserShowDto>();
        CreateMap<User, UserUpdateDto>();
        CreateMap<Image, ImageDto>();
        CreateMap<ImageDto, Image>();
    }
}