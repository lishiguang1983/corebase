using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace kdb.platform.commons.jwt
{
    /// <summary>
    /// token提供属性
    /// </summary>
    public class TokenProviderOptions
    {
        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 订阅者
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 过期时间间隔
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(30);

        /// <summary>
        /// 签名证书
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
    }
}
