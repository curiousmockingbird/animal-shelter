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
public class UsersController : ControllerBase
{
	private readonly IJWTManagerRepository _jWTManager;
  private readonly Animal_ShelterContext _db;

	public UsersController(IJWTManagerRepository jWTManager, Animal_ShelterContext db)
	{
		this._jWTManager = jWTManager;
    _db = db;
	}

	// GET api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
      return await _db.Users.ToListAsync();
    }

  // POST api/users
    [HttpPost]
    public async Task<ActionResult<User>> Post(User user)
    {
      _db.Users.Add(user);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(User), new { id = user.UserId }, user);
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
}
}