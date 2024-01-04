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



}
