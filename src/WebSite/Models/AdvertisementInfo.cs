using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    /// <summary>
    /// 广告信息
    /// </summary>
    public class AdvertisementInfo
    {

        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 广告图片地址
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 广告内容说明
        /// </summary>
        public string AdvertisementContent { get; set; }
        /// <summary>
        /// 广告导向链接
        /// </summary>
        public string AdvertisementUrl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 类型id
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 状态（0草稿 1发布 2隐藏 3删除）
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
