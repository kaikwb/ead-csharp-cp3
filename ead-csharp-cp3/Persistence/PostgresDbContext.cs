using Microsoft.EntityFrameworkCore;

namespace ead_csharp_cp3.Persistence;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
}