using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOS.Domain.Context;
using YOS.Domain.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YOS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext contex;
        public UserController(AppDbContext contex)
        {
            this.contex = contex;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<User>>> GetUsers()
        {
          return await contex.Users.ToListAsync();
        }

        

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
