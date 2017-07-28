using AutoMapper;
using kdb.platform.commons;
using kdb.platform.dtos.UserDto;
using kdb.platform.models;
using kdb.platform.repositorys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kdb.platform.services.Impl
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<BaseResponseDto<int>> Register(RegisterDto dto)
        {
            dto.Pwd = commons.helper.SecureHelper.DesEncrypt(dto.Pwd);
            var user = _mapper.Map<User>(dto);
            user.Enable = true;
            user.CreateTime = DateTime.Now;
            return await _userRepository.Register(user);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="dto">dto.</param>
        public BaseResponseDto<bool> UpdateUser(UpdateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            return _userRepository.UpdateUser(user);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<BaseResponseDto<UserDto>> Login(string account, string pwd)
        {
            pwd = commons.helper.SecureHelper.DesEncrypt(pwd);
            var result = await _userRepository.Login(account, pwd);
            return _mapper.Map<BaseResponseDto<UserDto>>(result);
        }

        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponseDto<UserDto>> GetUser(int id)
        {
            var result = await _userRepository.GetUser(id);
            return _mapper.Map<BaseResponseDto<UserDto>>(result);
        }

        /// <summary>
        /// 分页获取用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public BaseResponseDto<QueryUsersResponseDto> GetUsers(BaseRequestDto<QueryUsersRequestDto> dto)
        {
            var result = _userRepository.GetUsers(dto);
            var response = _mapper.Map<BaseResponseDto<QueryUsersResponseDto>>(result);
            return response;
        }
    }
}
