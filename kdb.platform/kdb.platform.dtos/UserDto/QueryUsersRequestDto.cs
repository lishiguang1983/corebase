using System;
using System.Collections.Generic;
using System.Text;

namespace kdb.platform.dtos.UserDto
{
    /// <summary>
    /// 查询用户
    /// </summary>
    public class QueryUsersRequestDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        /// <returns></returns>
        public string Account { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? Enable { get; set; }
    }

    public class QueryUsersResponseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        /// <returns></returns>
        public string Avatar { get; set; }
    }
 }
