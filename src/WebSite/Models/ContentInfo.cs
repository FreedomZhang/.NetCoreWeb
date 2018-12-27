using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    /// <summary>
    /// 内容信息
    /// </summary>
    public class ContentInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 类型id
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int ClickNum { get; set; }
        /// <summary>
        /// 推荐次数
        /// </summary>
        public int RecommendNum { get; set; }
        /// <summary>
        /// 预览中显示的图片路径
        /// </summary>
        public string PreviewImgPath { get; set; }
        /// <summary>
        /// 状态（0草稿 1发布 2隐藏 3删除）
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建用户id
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        [NotMapped]
        public string ContentPreview
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Content))
                {
                    string p = "";
                    var ayy = this.Content.Split(new string[] { "<p>", "</p>" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in ayy)
                    {
                        p += item;
                        if (p.Length > 30)
                        {
                            return p += "......";
                        }
                    }
                    return p + "......";
                }
                return this.Content;
            }
        }
        [NotMapped]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        [NotMapped]
        public  string TypeName { get; set; }
    }
}
