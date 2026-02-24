using APIWorkTest.DataAccessLayer.Models;
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
    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CategoryController( ApplicationDbContext context)
        {
            _context = context;
           
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var categories = _context.category.ToList();
            
            return Ok(new { Message = "Added Category Successfully", categories });
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Category category)
        {

                await _context.AddAsync(category);
            await _context.SaveChangesAsync();


            return Ok("Creared category Successfully");
        }

        [HttpPatch("{id}")]
        public IActionResult Edit(Category category)
        {
            
            if (category is not null)
            {

                category.Name = category.Name;
                category.Description = category.Description;
                _context.category.Update(category);
                _context.SaveChanges();


                return Ok("Updating Category Successfully");

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Category id)
        {

            
            _context.Remove(id);
            _context.SaveChangesAsync();


            return Ok("Deleted Category Successfully");
        }
    }
}
