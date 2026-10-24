using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QLTV_CodeFirst.Data;

namespace QLTV_CodeFirst
{
    public class QLTVDBContextFactory : IDesignTimeDbContextFactory<QLTVDBContext>
    {
        public QLTVDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QLTVDBContext>();
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-6SN65NCS\HUECTMDB;Database=QLTV;Trusted_Connection=True;TrustServerCertificate=True;");
            return new QLTVDBContext(optionsBuilder.Options);
        }
    }
}
