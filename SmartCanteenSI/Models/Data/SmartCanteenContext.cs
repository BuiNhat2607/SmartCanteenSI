using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SmartCanteenSI.Models.Data
{
    public partial class SmartCanteenContext : DbContext
    {
        public SmartCanteenContext()
            : base("name=SmartCanteenContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
