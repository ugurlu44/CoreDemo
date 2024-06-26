using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=KORKMAZ; database=CoreBlogApiDb; integrated security=true;");
            //optionsBuilder.UseSqlServer("Data Source=KORKMAZ; Initial Catalog=CoreBlogDb; Integrated Security=True");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
