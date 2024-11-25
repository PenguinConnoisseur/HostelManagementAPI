using Microsoft.EntityFrameworkCore;
using HostelManagementAPI.Models;

namespace HostelManagementAPI.Data
{
    public class HostelManagementContext : DbContext
    {
        public HostelManagementContext(DbContextOptions<HostelManagementContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Dorm> Dorms { get; set; }
    }
}
