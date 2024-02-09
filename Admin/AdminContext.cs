using FarmCooperation.Data;
using FarmCooperation.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin;

public class AdminContext : DbContext
{
    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<ArticleImage> ArticleImages { get; set; }
    public AdminContext(DbContextOptions<AdminContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=FarmerProject.mssql.somee.com; id=musicShop_SQLLogin_1;pwd=1aaemb6yh3; initial catalog=FarmerProject");
    //}
}