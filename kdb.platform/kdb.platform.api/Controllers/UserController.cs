using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kdb.platform.services;
using Microsoft.AspNetCore.Authorization;
using kdb.platform.dtos.UserDto;
using kdb.platform.commons;

namespace kdb.platform.api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 得到所有的用户
        /// </summary>
        /// /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery]int pageNumber, [FromQuery]int pageSize, [FromQuery]string account, [FromQuery]string name)
        {
            var dto = new BaseRequestDto<QueryUsersRequestDto>
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                Filter = new QueryUsersRequestDto
                {
                    Account = account,
                    Name = name
                }
            };
            var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var result = _userService.GetUsers(dto);
            return Ok(result);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Info()
        {
            var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var result = _userService.GetUser(userId);
            return Ok(result.Result);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Update([FromBody]UpdateUserDto dto)
        {
            var result = _userService.UpdateUser(dto);
            return Ok(result);
        }
    }
}