using Microsoft.EntityFrameworkCore;

namespace BhvrIV.Persistence.Ef;

public class AppWriteDbContext : AppDbContext
{
    public AppWriteDbContext(DbContextOptions options) : base(options)
    {
    }
}

