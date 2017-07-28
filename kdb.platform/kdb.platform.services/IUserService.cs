using kdb.platform.commons;
using kdb.platform.dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kdb.platform.services
{
    public interface IUserService
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<BaseResponseDto<int>> Register(RegisterDto dto);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="dto">dto.</param>
        BaseResponseDto<bool> UpdateUser(UpdateUserDto dto);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Task<BaseResponseDto<UserDto>> Login(string account, string pwd);

        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResponseDto<UserDto>> GetUser(int id);

        /// <summary>
        /// 分页获取用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        BaseResponseDto<QueryUsersResponseDto> GetUsers(BaseRequestDto<QueryUsersRequestDto> dto);
    }
}
