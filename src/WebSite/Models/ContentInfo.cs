using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
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
                    string p = Html2Text(Content);
                    if (p.Length > 20)
                    {
                        p = p.Substring(0,20);
                    }

                    return p;
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
        public string TypeName { get; set; }


        public static string Html2Text(string htmlStr)

        {

            if (String.IsNullOrEmpty(htmlStr))

            {

                return "";

            }

            string regEx_style = "<style[^>]*?>[\\s\\S]*?<\\/style>"; //定义style的正则表达式 

            string regEx_script = "<script[^>]*?>[\\s\\S]*?<\\/script>"; //定义script的正则表达式   

            string regEx_html = "<[^>]+>"; //定义HTML标签的正则表达式   

            htmlStr = Regex.Replace(htmlStr, regEx_style, "");//删除css

            htmlStr = Regex.Replace(htmlStr, regEx_script, "");//删除js

            htmlStr = Regex.Replace(htmlStr, regEx_html, "");//删除html标记

            htmlStr = Regex.Replace(htmlStr, "\\s*|\t|\r|\n", "");//去除tab、空格、空行

            htmlStr = htmlStr.Replace(" ", "");


            return htmlStr.Trim();

        }



    }
}
