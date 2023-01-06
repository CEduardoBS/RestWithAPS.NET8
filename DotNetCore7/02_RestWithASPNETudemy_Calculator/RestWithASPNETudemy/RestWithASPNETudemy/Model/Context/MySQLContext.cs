using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETudemy.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}

        public DbSet<Person> People { get; set; }

        public DbSet<Books> Library { get; set; }

        public DbSet<AppAgendaCD> Agenda { get; set; }

    }
}
