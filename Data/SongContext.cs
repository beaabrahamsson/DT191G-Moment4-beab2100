namespace DT191G_Moment4_beab2100.Data {
    using DT191G_Moment4_beab2100.Models;
    using Microsoft.EntityFrameworkCore;

    public class SongContext : DbContext {
        public SongContext(DbContextOptions<SongContext> options) : base(options) { }

        public DbSet<Song> Songs { get; set; }
    }
}