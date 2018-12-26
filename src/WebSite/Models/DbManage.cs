using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
namespace WebSite.Models
{
    public class DbManage
    {
        private readonly string _sqlitePath = Directory.GetCurrentDirectory() + @"\db\db.db";

        private string _conn
        {
            get
            {
                //1.基础连接，FailIfMissing 参数 true=没有数据文件将异常;false=没有数据库文件则创建一个
                //data Source=test.db;Pooling=true;FailIfMissing=false
                //2。使用utf-8 格式
                //data Source={0};Version=3;UTF8Encoding=True;
                //3.禁用日志
                //data Source={0};Version=3;UTF8Encoding=True;Journal Mode=Off;
                //4.连接池
                //data Source=c:\mydb.db;Version=3;Pooling=True;Max Pool Size=100;

                return string.Format(@"data Source={0};Pooling=true;FailIfMissing=false;Version=3;UTF8Encoding=True;Journal Mode=Off;", _sqlitePath);
            }
        }

        public List<ContentInfo> GetBlogContents()
        {
            var sql = @"SELECT * FROM content";
            var list = new List<ContentInfo>();
            using (var conn = new SQLiteConnection(_conn))
            {
                list = conn.Query<ContentInfo>(sql) as List<ContentInfo>;
            }
            return list;
        }
    }
}
