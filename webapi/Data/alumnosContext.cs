using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{

    public class alumnosContext : DbContext
    {
        public alumnosContext(DbContextOptions<alumnosContext>options):base(options)
        {

        }
        public DbSet<alumnos> alumnos { get; set; }

    }

}