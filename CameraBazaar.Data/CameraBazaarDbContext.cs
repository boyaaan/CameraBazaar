namespace CameraBazaar.Data
{
    using CameraBazaar.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CameraBazaarDbContext : IdentityDbContext
    {
        public CameraBazaarDbContext(DbContextOptions<CameraBazaarDbContext> options)
            : base(options)
        {
        }
        public DbSet<CameraModel> Camera { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(c => c.Cameras)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            base.OnModelCreating(builder);
        }
    }
}
