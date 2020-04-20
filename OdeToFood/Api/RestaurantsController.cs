using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.core;
using OdeToFood.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OdeToFoodDbContext _context;

        public RestaurantsController(OdeToFoodDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurants;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant([FromRoute]int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _context.Restaurants.FindAsync(id);

            if(restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);

        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
