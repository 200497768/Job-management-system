using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Job_management_system.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
    public DbSet<Job_management_system.Models.Maintenance> Maintenance { get; set; } = default!;
    public DbSet<Job_management_system.Models.Job> Job { get; set; } = default!;
    public DbSet<Job_management_system.Models.MunicipalAddress> MunicipalAddress { get; set; } = default!;
    public DbSet<Job_management_system.Models.Office> Office { get; set; } = default!;
    public DbSet<Job_management_system.Models.Employee> Employee { get; set; } = default!;
    }
}
