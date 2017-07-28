using System;

namespace kdb.platform.models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        /// <returns></returns>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        /// <returns></returns>
        public string Avatar { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        /// <returns></returns>
        public string Introduction { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 介绍人，无介绍人为空
        /// 如：/1
        /// /1/2
        /// /1/2/3
        /// </summary>
        public string ParentId { get; set; }
    }
}
