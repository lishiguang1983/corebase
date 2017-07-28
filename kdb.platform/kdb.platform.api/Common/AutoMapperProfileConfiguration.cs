using AutoMapper;
using kdb.platform.commons;
using kdb.platform.dtos.UserDto;
using kdb.platform.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kdb.platform.api.Common
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            #region User dto
            CreateMap<RegisterDto, User>();
            CreateMap<BaseResponseDto<User>, BaseResponseDto<UserDto>>();

            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<User, QueryUsersResponseDto>();
            CreateMap<BaseResponseDto<User>, BaseResponseDto<QueryUsersResponseDto>>();
            #endregion
        }
    }
}
