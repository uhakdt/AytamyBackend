using AytamyBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace AytamyBackend.Controllers;

[ApiController]
[Route("api/v0.1-beta")]
public class UserController : ControllerBase
{
    private readonly DataContext _dbContext;

    public UserController(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("users")]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        return Ok(await _dbContext.Users.ToListAsync());
    }

    [HttpGet("user/{id}")]
    public async Task<ActionResult<List<User>>> Get(int id) {
        var user = await _dbContext.Users.Where(x => x.UserID == id).FirstOrDefaultAsync();

        return Ok(user);
    }

    [HttpPost("user")]
    public async Task<ActionResult<List<User>>> Create(User user) {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return Ok(await _dbContext.Users.ToListAsync());
    }

    [HttpPut("user")]
    public async Task<ActionResult<List<User>>> Update(User user) {
        var userResult = await _dbContext.Users.FindAsync(user.UserID);

        if(userResult == null)
            return BadRequest("User not found.");

        userResult.Name = user.Name;
        userResult.Email = user.Email;
        userResult.Phone = user.Phone;
        userResult.UpdatedAt = DateTime.Now;
        await _dbContext.SaveChangesAsync();

        return Ok(_dbContext.Users.ToListAsync());
    }

    [HttpDelete("user/{id}")]
    public async Task<ActionResult<List<User>>> Delete(int id) {
        var userResult = await _dbContext.Users.FindAsync(id);

        if(userResult == null)
            return BadRequest("User not found.");

        _dbContext.Users.Remove(userResult);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}