using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Animal_Shelter.Models;
using System.Linq;

namespace Animal_Shelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DogsController : ControllerBase
  {
    private readonly Animal_ShelterContext _db;

    public DogsController(Animal_ShelterContext db)
    {
      _db = db;
    }

    // GET api/dogs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dog>>> Get(string name, string sex)
    {
      var query = _db.Dogs.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (sex != null)
      {
        query = query.Where(entry => entry.Sex == sex);
      }

      return await query.ToListAsync();
    }

    // POST api/dogs
    [HttpPost]
    public async Task<ActionResult<Dog>> Post(Dog dog)
    {
      _db.Dogs.Add(dog);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(Dog), new { id = dog.DogId }, dog);
    }

    // PUT: api/cats/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Dog dog)
    {
      if (id != dog.DogId)
      {
        return BadRequest();
      }

      _db.Entry(dog).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DogExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool DogExists(int id)
    {
      return _db.Dogs.Any(e => e.DogId == id);
    }

    // DELETE: api/dogs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDog(int id)
    {
      var dog = await _db.Dogs.FindAsync(id);
      if (dog == null)
      {
        return NotFound();
      }

      _db.Dogs.Remove(dog);
      await _db.SaveChangesAsync();

      return NoContent();
    } 
  }
}