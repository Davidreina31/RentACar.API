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
    public class TripController : Controller
    {
        private readonly ITripManager _currentManager;

        public TripController(ITripManager tripManager)
        {
            _currentManager = tripManager;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> Get()
        {
            return Ok(await _currentManager.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> Get([FromRoute] Guid id)
        {
            return Ok(await _currentManager.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Trip>> Post([FromBody] Trip trip)
        {
            return Ok(await _currentManager.Add(trip));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Trip>> Put([FromRoute] Guid id, [FromBody] Trip trip)
        {
            if (id != trip.Trip_Id)
                return BadRequest();
            return Ok(await _currentManager.Update(trip));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trip>> Delete([FromRoute] Guid id)
        {
            return Ok(await _currentManager.Delete(id));
        }
    }
}
