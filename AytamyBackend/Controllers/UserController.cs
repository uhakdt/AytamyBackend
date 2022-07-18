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

    [HttpGet("users/{search}")]
    public async Task<ActionResult<List<User>>> GetSearch(string search) {
        var users = await _dbContext.Users.Where(x => x.Name == search
                                                   || x.Country == search
                                                   || x.City == search
                                                   || x.Aspirations == search
                                                   || x.Hobbies == search
                                                   || x.Job == search
                                                   || x.Education == search
                                                   || x.Gender == search
                                                   || x.Age.ToString() == search
                                                   || x.Description.Contains(search)).ToListAsync();

        return Ok(users);
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
        userResult.PhoneNumber = user.PhoneNumber;
        userResult.ParentPhoneNumber = user.ParentPhoneNumber;
        userResult.Country = user.Country;
        userResult.City = user.City;
        userResult.Aspirations = user.Aspirations;
        userResult.Hobbies = user.Hobbies;
        userResult.Job = user.Job;
        userResult.Education = user.Education;
        userResult.EducationCertificateUrl = user.EducationCertificateUrl;
        userResult.Nationality = user.Nationality;
        userResult.DateOfBirth = user.DateOfBirth;
        userResult.MotherCertificateUrl = user.MotherCertificateUrl;
        userResult.FatherCertificateUrl = user.FatherCertificateUrl;
        userResult.Gender = user.Gender;
        userResult.Age = user.Age;
        userResult.Type= user.Type;
        userResult.Description = user.Description;
        userResult.Warranty = user.Warranty;
        userResult.IsWarranty = user.IsWarranty;
        userResult.IsComplete = user.IsComplete;
        userResult.UpdatedAt = DateTime.Now;
        await _dbContext.SaveChangesAsync();

        return Ok(_dbContext.Users.ToListAsync().Result);
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