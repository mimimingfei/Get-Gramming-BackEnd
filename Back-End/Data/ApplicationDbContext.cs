using Back_End.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

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
        modelBuilder.Entity<User>().HasData(SeedUserData());
    }

    private List<Restaurant> SeedRestaurantData()
    {
        var restaurants = new List<Restaurant>();
        using (StreamReader r = new StreamReader(@"restaurantData.json"))
        {
            string json = r.ReadToEnd();
            restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
        }
        int id = 1;
        foreach (var restaurant in restaurants)
        {
            restaurant.Id = id++;
            if (restaurant.PhotosUrl == null)
            {
                restaurant.PhotosUrl = new List<string>();
            }
        }

        return restaurants;
    }

    private List<User> SeedUserData()
    {
        var users = new List<User>();
        using (StreamReader r = new StreamReader(@"userData.json"))
        {
            string json = r.ReadToEnd();
            users = JsonConvert.DeserializeObject<List<User>>(json);
        }
        int id = 1;
        foreach (var user in users)
        {
            user.Id = id++;  
        }
        return users;
    }
}

