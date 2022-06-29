using Microsoft.AspNetCore.Mvc;

namespace AytamyBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext _dbContext;

    public UserController(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult<List<User>>> GetAsync()
    {
        return Ok(await _dbContext.users.ToListAsync());
    }
}