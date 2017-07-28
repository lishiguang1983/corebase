using System;
using System.Collections.Generic;
using System.Text;

namespace kdb.platform.dtos.UserDto
{
    /// <summary>
    /// 注册用户 Dto
    /// </summary>
    public class RegisterDto
    {
        public string Name { get; set; }

        public string Account { get; set; }

        public string Pwd { get; set; }
    }
}
