using kdb.platform.commons.jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace kdb.platform.commons
{
    /// <summary>
    /// 基本返回对象
    /// </summary>
    public class BaseResponseDto<T>
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public bool Success { get; set; } = true;

        /// <summary>
        /// 消息
        /// </summary>
        /// <returns></returns>
        public string Msg { get; set; }

        /// <summary>
        /// 单个对象
        /// </summary>
        /// <returns></returns>
        public T Result { get; set; }

        /// <summary>
        /// 集合对象
        /// </summary>
        /// <returns></returns>
        public IList<T> Results { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        /// <returns></returns>
        public int? TotalPageCount { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        /// <returns></returns>
        public int? TotalCount { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        /// <returns></returns>
        public TokenEntity Token { get; set; }
    }
}
