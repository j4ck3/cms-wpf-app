using cms_wpf_app.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace cms_wpf_app.Data
{
    internal class DataContext : DbContext
    {

        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jakob\Desktop\cms-wpf-app\cms-wpf-app\Data\local_db.mdf;Integrated Security=True;Connect Timeout=30";


        #region setup
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        #endregion


        public DbSet<AddressModel> Addresses { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<OrderEntity> Orders { get; set; } = null!;
        public DbSet<OrderCommentEntity> OrderComments { get; set; } = null!;
    }
}
