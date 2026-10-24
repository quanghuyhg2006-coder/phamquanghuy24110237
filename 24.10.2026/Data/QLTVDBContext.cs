using Microsoft.EntityFrameworkCore;
using QLTV_CodeFirst.Models;

namespace QLTV_CodeFirst.Data
{
    public class QLTVDBContext : DbContext
    {
        public QLTVDBContext(DbContextOptions<QLTVDBContext> options) : base(options)
        {
        }

        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<Sach> Sachs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-6SN65NCS\HUECTMDB;Database=QLTV;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sach>()
                .HasOne(s => s.TacGia)
                .WithMany(tg => tg.Sachs)
                .HasForeignKey(s => s.MaTacGia)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sach>()
                .HasOne(s => s.TheLoai)
                .WithMany(tl => tl.Sachs)
                .HasForeignKey(s => s.MaTheLoai)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
