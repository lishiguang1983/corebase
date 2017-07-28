using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using kdb.platform.commons;
using kdb.platform.dtos.UserDto;
using kdb.platform.models;
using kdb.platform.repositorys.DataProvide;
using System.Threading.Tasks;
using PetaPoco.NetCore;
using System.Linq;

namespace kdb.platform.repositorys.Impl
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private ISqlContext _context;

        public UserRepository(ISqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 得到单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponseDto<User>> GetUser(int id)
        {
            var user = await _context.DataBase.Connection.QueryFirstOrDefaultAsync<User>("select * from User where id = @id", new { id = id });
            return new BaseResponseDto<User> { Result = user };
        }

        /// <summary>
        /// 得到所有用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public BaseResponseDto<User> GetUsers(BaseRequestDto<QueryUsersRequestDto> dto)
        {
            var sql = new Sql();
            if (!string.IsNullOrEmpty(dto.Filter.Account))
                sql.Where("account like @account", new { account = $"%{ dto.Filter.Account }%" });
            if (!string.IsNullOrEmpty(dto.Filter.Name))
                sql.Where("name like @name", new { name = $"%{ dto.Filter.Name }%" });
            var result = _context.DataBase.Page<User>(dto.PageNumber, dto.PageSize, sql);
            var response = new BaseResponseDto<User>
            {
                TotalPageCount = result.TotalPages,
                TotalCount = result.TotalItems,
                Success = true
            };
            if (result.Items.Count > 0)
                response.Results = result.Items.Select(m => m).ToList();
            return response;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<BaseResponseDto<User>> Login(string account, string pwd)
        {
            var sql = "select * from User where account = @account and pwd = @pwd";
            var user = await _context.DataBase.Connection.QueryFirstOrDefaultAsync<User>(sql, new
            {
                account = account,
                pwd = pwd
            });
            var response = new BaseResponseDto<User> { };
            if (user == null)
            {
                response.Msg = "用户不存在";
            }
            else
            {
                if (!user.Enable) response.Msg = "用户被禁用";
                else response.Result = user;
            }
            return response;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<BaseResponseDto<int>> Register(User user)
        {
            var response = new BaseResponseDto<int>
            {
            };
            //判断用户是否存在
            var temp = await _context.DataBase.Connection.QueryFirstOrDefaultAsync<User>("select * from User where account=@account", new { account = user.Account });
            if (temp != null)
            {
                response.Success = false;
                response.Msg = $"{user.Account}已经存在";
            }
            else
            {
                var result = _context.DataBase.Save(user);
                response.Msg = result > 0 ? "注册成功" : "注册失败";
                response.Result = result;
            }
            return response;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public BaseResponseDto<bool> UpdateUser(User user)
        {
            var result = _context.DataBase.Update("User", "Id", new
            {
                Name = user.Name,
                Avatar = user.Avatar,
                Introduction = user.Introduction
            }, user.Id);
            return new BaseResponseDto<bool>
            {
                Result = result > 0
            };
        }
    }
}
