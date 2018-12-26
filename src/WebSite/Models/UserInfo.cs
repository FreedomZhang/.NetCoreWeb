using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 头像图片路径
        /// </summary>
        public string HeadImgPath { get; set; }
        /// <summary>
        /// 状态（0禁用 1正常 2删除）
        /// </summary>
        public int State { get; set; }
    }
}
