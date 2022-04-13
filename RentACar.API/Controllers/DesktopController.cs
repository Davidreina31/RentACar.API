using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.BLL.Interfaces.Managers;
using RentACar.MODELS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    public class DesktopController : Controller
    {
        private readonly IDesktopManager _currentManager;

        public DesktopController(IDesktopManager desktopManager)
        {
            _currentManager = desktopManager;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desktop>>> Get()
        {
            return Ok(await _currentManager.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desktop>> Get([FromRoute] Guid id)
        {
            return Ok(await _currentManager.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Desktop>> Post([FromBody] Desktop desktop)
        {
            try
            {
                return Ok(await _currentManager.Add(desktop));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Desktop>> Put([FromRoute] Guid id, [FromBody] Desktop desktop)
        {
            if (id != desktop.Desktop_Id)
                return BadRequest();
            return Ok(await _currentManager.Update(desktop));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Desktop>> Delete([FromRoute] Guid id)
        {
            return Ok(await _currentManager.Delete(id));
        }
    }
}
