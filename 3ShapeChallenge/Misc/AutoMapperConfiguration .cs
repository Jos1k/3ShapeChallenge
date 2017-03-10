using _3ShapeChallenge.Models;
using AutoMapper;
using DataAccess.Models;
using System;

namespace _3ShapeChallenge.Misc
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<_AddUser, User>()
                .ForMember(
                    x=>x.Birthday,
                    opt=>opt.MapFrom(src=>src.Birthday.ToString("MM-dd-yyyy"))
                )
                .ReverseMap();
        }
    }
}
