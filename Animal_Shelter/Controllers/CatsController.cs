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
  public class CatsController : ControllerBase
  {
    private readonly Animal_ShelterContext _db;

    public CatsController(Animal_ShelterContext db)
    {
      _db = db;
    }

    // GET api/cats
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cat>>> Get(string name, string sex)
    {
      var query = _db.Cats.AsQueryable();

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

    // POST api/cats
    [HttpPost]
    public async Task<ActionResult<Cat>> Post(Cat cat)
    {
      _db.Cats.Add(cat);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(Cat), new { id = cat.CatId }, cat);
    }

    // PUT: api/cats/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cat cat)
    {
      if (id != cat.CatId)
      {
        return BadRequest();
      }

      _db.Entry(cat).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CatExists(id))
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
    private bool CatExists(int id)
    {
      return _db.Cats.Any(e => e.CatId == id);
    }

    // DELETE: api/cats/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCat(int id)
    {
      var cat = await _db.Cats.FindAsync(id);
      if (cat == null)
      {
        return NotFound();
      }

      _db.Cats.Remove(cat);
      await _db.SaveChangesAsync();

      return NoContent();
    } 
  }
}