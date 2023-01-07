using FirstDemoCSAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstDemoCSAngular.Context;

public class NewContext : DbContext
{
    public NewContext(DbContextOptions<NewContext> options)
    : base(options)
    {
    }

    public DbSet<NewModel>? NewModels { get; set; }
}