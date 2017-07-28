using kdb.platform.commons.jwt;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace kdb.platform.api.Common
{
    /// <summary>
    /// Token提供类
    /// </summary>
    public class TokenProvider
    {
        readonly TokenProviderOptions _options;
        public TokenProvider(TokenProviderOptions options)
        {
            _options = options;
        }
        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="context">http上下文</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<TokenEntity> GenerateToken(HttpContext context, string userId)
        {
            var identity = await GetIdentity(userId);
            if (identity == null)
            {
                return null;
            }
            var now = DateTime.UtcNow;
            //声明
            var claims = new Claim[]
            {
             new Claim(JwtRegisteredClaimNames.Sub,userId),
             new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Iat,ToUnixEpochDate(now).ToString(),ClaimValueTypes.Integer64),
             // new Claim(ClaimTypes.Role,username),
             new Claim(ClaimTypes.Name,userId)
            };
            //Jwt安全令牌
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            //生成令牌字符串
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new TokenEntity
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };
            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }

        /// <summary>
        /// 查看令牌是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        private Task<ClaimsIdentity> GetIdentity(string username)
        {
            return Task.FromResult(
                new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "token"),
                new Claim[] {
                 new Claim(ClaimTypes.Name, username)
                }));
        }
    }
}
