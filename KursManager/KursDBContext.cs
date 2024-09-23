using Microsoft.EntityFrameworkCore;

namespace KursManager
{
    internal class KursDBContext : DbContext
    {
        public DbSet<Kurs> Kurs { get; set; } = default!;
        public DbSet<Teilnehmer> Teilnehmer { get; set; } = default!;

        public string DbPath { get; }

        public KursDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "kurs.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
