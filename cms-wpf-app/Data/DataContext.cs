using Microsoft.EntityFrameworkCore;
using System.Printing;

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



    }
}
