using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Animal_Shelter.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Animal_Shelter.Repository;

namespace Animal_Shelter.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class DogsController : ControllerBase
  {
    private readonly IJWTManagerRepository _jWTManager;
    private readonly Animal_ShelterContext _db;

    public DogsController(IJWTManagerRepository jWTManager, Animal_ShelterContext db)
    {
      this._jWTManager = jWTManager;
      _db = db;
    }

  [AllowAnonymous]
	[HttpPost]
	[Route("authenticate")]
	public IActionResult Authenticate(User usersdata)
	{
		var token = _jWTManager.Authenticate(usersdata);

		if (token == null)
		{
			return Unauthorized();
		}

		return Ok(token);
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

      return CreatedAtAction("POST", new { id = dog.DogId }, dog);
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