using APIWorkTest.PresentationLayer.DataAccess;
using APIWorkTest.PresentationLayer.DTOs.Request;
using APIWorkTest.PresentationLayer.DTOs.Response;
using APIWorkTest.PresentationLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace APIWorkTest.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var Users = _context.Users.ToList();
            var user = Users.Adapt<List<ApplicationUserResponse>>();
            return Ok(new { Message = "Added Successfully", user });
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ApplicationUserRequest applicationUserRequest)
        {

            var Users = applicationUserRequest.Adapt<ApplicationUser>();
                await _context.AddAsync(Users);
            await _context.SaveChangesAsync();


            return Ok("Creared Successfully");
        }

        [HttpPatch("{id}")]
        public IActionResult Edit(ApplicationUser user)
        {
            //I cannot use (user.Id=id) becouse i injected the ApplicationUser
            //var users = _context.ApplicationUsers.Find( id);
            if (user is not null)
            {
                
                user.FullName = user.FullName;
                user.Email = user.Email;
                _context.Users.Update(user);
                _context.SaveChanges();


                return Ok("Updating Successfully");

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ApplicationUser id)
        {

            //var Users = _context.Users.Find(id);
            _context.Remove(id);
            _context.SaveChangesAsync();


            return Ok("Deleted Successfully");
        }
    }
}
