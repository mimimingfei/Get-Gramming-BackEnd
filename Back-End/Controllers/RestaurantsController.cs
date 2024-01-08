using Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("[controller]")]
public class RestaurantsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public RestaurantsController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
    {
        return await _context.Restaurants.ToListAsync();
    }
    [HttpGet("city/{city}")]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurantsByCity([FromRoute] string city)
    {
        var restaurantsInCity = await _context.Restaurants
                                            .Where(r => r.City.ToLower() == city.ToLower())
                                            .ToListAsync();
        if (restaurantsInCity == null || !restaurantsInCity.Any())
        {
            return NotFound();
        }
        return restaurantsInCity;
    }
    [HttpGet("cuisines")]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllCuisines()
    {
        var cuisines = await _context.Restaurants
                                .Select(r => r.Cuisine)
                                .Distinct()
                                .ToListAsync();
        return Ok(cuisines);
    }
    [HttpGet("cuisine/{cuisine}")]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurantsByCuisine([FromRoute] string cuisine)
    {
        var restaurantsByCuisine = await _context.Restaurants
                                        .Where(r => r.Cuisine.ToLower().Contains(cuisine.ToLower()))
                                        .ToListAsync();
        if (restaurantsByCuisine == null || !restaurantsByCuisine.Any())
        {
            return NotFound();
        }
        return restaurantsByCuisine;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurantsByUserAsync([FromRoute] int userId)
    {
        var restaurantsByUser = await _context.Restaurants
                                        .Where(r => r.UserId == userId)
                                        .ToListAsync();
        if (!restaurantsByUser.Any())
        {
            return NotFound();
        }
        return restaurantsByUser;
    }

    //delete a restaurant by id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
        {
            return NotFound();
        }

        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
    //post a new restaurant
    [HttpPost]
    public async Task<IActionResult> PostRestaurant([FromBody] Restaurant newRestaurant)
    {
        if (newRestaurant == null)
        {
            return BadRequest("Invalid restaurant data.");
        }

        _context.Restaurants.Add(newRestaurant);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRestaurant), new { id = newRestaurant.Id }, newRestaurant);
    }

    //  retrieve a single restaurant
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurant(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }




}