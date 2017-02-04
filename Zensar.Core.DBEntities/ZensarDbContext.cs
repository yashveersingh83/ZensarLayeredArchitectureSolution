using System.Data.Entity;
using System.Xml.Linq;

namespace Zensar.Core.DBEntities
{
    public class ZensarDbContext:DbContext
    {
        
        public ZensarDbContext():base("name=ZensarDBConnection")
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
