using Back_End.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>().HasData(SeedRestaurantData());
    }

    public List<Restaurant> SeedRestaurantData()
    {
        var restaurants = new List<Restaurant>();
        using (StreamReader r = new StreamReader(@"restaurantData.json"))
        {
            string json = r.ReadToEnd();
            restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
        }
        return restaurants;
    }
}
