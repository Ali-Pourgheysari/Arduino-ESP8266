using IOT.Models;
using Microsoft.EntityFrameworkCore;  
namespace IOT.Context
{
    public class ApplicationDBContext : DbContext
    {
            public ApplicationDBContext(DbContextOptions options) : base(options)
            {
            }

            public DbSet<FormViewModel> FormViewModels { get; set; }

    }
}
