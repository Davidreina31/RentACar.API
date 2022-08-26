using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.BLL.Interfaces.Managers;
using RentACar.DAL.Repositories;
using RentACar.MODELS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/values
        [HttpGet]
        [Authorize("read:users")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _userManager.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get([FromRoute] Guid id)
        {
            return Ok(await _userManager.GetById(id));
        }

        [HttpGet("sub/{sub}")]
        public async Task<ActionResult<User>> GetBySub(string sub)
        {
            return Ok(await _userManager.GetUserBySub(sub));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            return Ok(await _userManager.Add(user));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put([FromRoute] Guid id, [FromBody] User user)
        {
            return Ok(await _userManager.Update(user));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete([FromRoute] Guid id)
        {
            return Ok(await _userManager.Delete(id));
        }
    }
}
