using System;

namespace kdb.platform.commons
{
    public class AppSettings
    {
        /// <summary>
        /// mysql 连接地址
        /// </summary>
        /// <returns></returns>
        public string MySqlConnectionStrings { get; set; }

        /// <summary>
        /// sql server 连接地址
        /// </summary>
        /// <returns></returns>
        public string MsSqlConnectionStrings { get; set; }
    }
}
