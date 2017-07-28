using System;
using System.Collections.Generic;
using System.Text;

namespace kdb.platform.dtos.UserDto
{
    /// <summary>
    /// 修改用户 Dto
    /// </summary>
    public class UpdateUserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Introduction { get; set; }
    }
}
