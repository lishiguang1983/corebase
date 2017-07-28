using System;
using System.Collections.Generic;
using System.Text;

namespace kdb.platform.models
{
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Linkman { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Mobile { get; set; }
        
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }
    }
}
