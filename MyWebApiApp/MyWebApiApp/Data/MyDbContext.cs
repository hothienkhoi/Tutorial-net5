using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoaEntity> HangHoas { get; set; }
        public DbSet<LoaiHoangHoaEntity> Loais { get; set; }
        #endregion
    }
}
