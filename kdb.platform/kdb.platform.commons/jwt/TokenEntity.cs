using System;
using System.Collections.Generic;
using System.Text;

namespace kdb.platform.commons.jwt
{
    /// <summary>
    /// Token实体
    /// </summary>
    public class TokenEntity
    {
        /// <summary>
        /// token字符串
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 过期时差
        /// </summary>
        public int expires_in { get; set; }
    }
}
