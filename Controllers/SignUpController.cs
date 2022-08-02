using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignUpAPI.Data;
using SignUpAPI.Models;

namespace SignUpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly SignUpAPIDbContext dbContext;

        public SignUpController(SignUpAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok(dbContext.Sign.ToList());

        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            var details = await dbContext.Sign.FindAsync(id);
            if (details == null)
            {
                return NotFound();

            }
            return Ok(details);
        }
        [HttpPost]
        public async Task<IActionResult> AddDetail(AddDetails adddetail)
        {
            var signup = new Signup()
            {

                Id = new int(),
                FirstName = adddetail.FirstName,
                LastName = adddetail.LastName,
                Email = adddetail.Email,
                Password = adddetail.Password


            };
            await dbContext.Sign.AddAsync(signup);
            await dbContext.SaveChangesAsync();

            return Ok(signup);

        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDetails([FromRoute] int id, Update updatedetails)
        {
            var details = await dbContext.Sign.FindAsync(id);

            if (details != null)
            {
                details.FirstName = updatedetails.FirstName;
                details.LastName = updatedetails.LastName;
                details.Email = updatedetails.Email;
                details.Password = updatedetails.Password;

                await dbContext.SaveChangesAsync();
                return Ok(details);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDetails([FromRoute] int id)
        {
            var details = await dbContext.Sign.FindAsync(id);
            if (details != null)
            {
                dbContext.Remove(details);
                await dbContext.SaveChangesAsync();
                return Ok(details);
            }
            return NotFound();
        }
    }
}
