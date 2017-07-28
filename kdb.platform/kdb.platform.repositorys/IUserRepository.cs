using kdb.platform.commons;
using kdb.platform.dtos.UserDto;
using kdb.platform.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kdb.platform.repositorys
{
    public interface IUserRepository
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<BaseResponseDto<int>> Register(User user);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="user">User.</param>
        BaseResponseDto<bool> UpdateUser(User user);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Task<BaseResponseDto<User>> Login(string account, string pwd);

        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResponseDto<User>> GetUser(int id);

        /// <summary>
        /// 分页获取用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        BaseResponseDto<User> GetUsers(BaseRequestDto<QueryUsersRequestDto> dto);
    }
}
