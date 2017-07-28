using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kdb.platform.services;
using Microsoft.AspNetCore.Authorization;
using kdb.platform.dtos.UserDto;
using kdb.platform.api.Common;
using Microsoft.IdentityModel.Tokens;
using kdb.platform.commons;
using System.Text;
using kdb.platform.commons.jwt;

namespace kdb.platform.api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 登录action
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="role">角色</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var response = new BaseResponseDto<UserDto> { };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyForAspNetCoreAPIToken"));
            var options = new TokenProviderOptions
            {
                Audience = "audience",
                Issuer = "issuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };
            response = await _userService.Login(dto.Account, dto.Pwd);
            if (response.Success && response.Result != null)
            {
                var tpm = new TokenProvider(options);
                var token = await tpm.GenerateToken(HttpContext, response.Result.Id.ToString());
                if (null != token)
                {
                    response.Token = token;
                    return Ok(response);
                }
            }
            response.Msg = "用户不存在";
            return Ok(response);
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns>The register.</returns>
        /// <param name="dto">Dto.</param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterDto dto)
        {
            var result = await _userService.Register(dto);
            return Ok(result);
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult LoginOut()
        {
            return Ok(true);
        }
    }
}
