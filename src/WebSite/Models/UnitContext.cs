using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    //参考文档https://docs.microsoft.com/zh-cn/ef/core/miscellaneous/configuring-dbcontext
    public class UnitContext : DbContext
    {
        public DbSet<ContentInfo> ContentInfos { get; set; }
        public DbSet<TypeInfo> TypeInfos { get; set; }
        public DbSet<FileInfo> FileInfos { get; set; }
        public DbSet<AdvertisementInfo> AdvertisementInfos { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        private readonly string _sqlitePath = Directory.GetCurrentDirectory() + @"\db\content.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(string.Format("data Source = {0}", _sqlitePath));
        }
    }






}
