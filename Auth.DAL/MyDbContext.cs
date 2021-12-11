using System.Data.Entity;

namespace Auth.DAL
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext(): base("name=authmvc")
        {
        }


        public virtual DbSet<SysUser> SysUser { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
