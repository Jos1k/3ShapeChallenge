using _3ShapeChallenge.Models;
using AutoMapper;
using DataAccess.Models;
using DataAccess.Repositories.Common;
using System;
using System.Globalization;

namespace _3ShapeChallenge.Misc
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<_AddUser, User>();
            CreateMap<User, _ShowUser>().ForMember(
                x => x.Birthday,
                opt => opt.MapFrom(src=> src.Birthday.ToString("dd-MM-yyyy"))
            );
            CreateMap<_GetByFilter, UserFilterModel>()
                .ForMember(
                x => x.ToDate,
                opt => opt.MapFrom(
                    src => ! string.IsNullOrEmpty(src.ToDate) ?
                    DateTime.ParseExact(
                        src.ToDate,
                        new StrictDateConverter().DateTimeFormat,
                        CultureInfo.InvariantCulture
                    ) :
                    default(DateTime?)
                )
            );
        }
    }
}
