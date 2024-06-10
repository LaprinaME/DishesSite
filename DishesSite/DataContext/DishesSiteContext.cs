using System.Data;
using DishesSite.Models;
using Microsoft.EntityFrameworkCore;
using DishesSite.ViewModels;

namespace DishesSite.DataContext
{
    public class DishesSiteContext : DbContext
    {
        public DishesSiteContext(DbContextOptions<DishesSiteContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Roles> Роли { get; set; } = null!;
        public DbSet<Accounts> Аккаунты { get; set; } = null!;
        public DbSet<Recipe> Рецепты { get; set; } = null!;
        public DbSet<Comment> Комментарии { get; set; } = null!;
        public DbSet<Rating> Рейтинг { get; set; } = null!;
        public DbSet<Dish> Блюда { get; set; } = null!;
    }
}