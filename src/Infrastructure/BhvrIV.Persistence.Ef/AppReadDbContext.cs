using Microsoft.EntityFrameworkCore;

namespace BhvrIV.Persistence.Ef;

public class AppReadDbContext : AppDbContext
{
    public AppReadDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}

