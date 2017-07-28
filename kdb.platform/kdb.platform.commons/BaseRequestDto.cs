using System;
using System.Collections.Generic;
using System.Text;

namespace kdb.platform.commons
{
    /// <summary>
    /// 基本的请求对象
    /// </summary>
    public class BaseRequestDto<T>
    {
        /// <summary>
        /// 请求对象
        /// </summary>
        /// <returns></returns>
        public T Filter { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public int? Id { get; set; }

        /// <summary>
        /// 每一页大小
        /// </summary>
        /// <returns></returns>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 当前页
        /// </summary>
        /// <returns></returns>
        public int PageNumber { get; set; } = 1;
    }
}
