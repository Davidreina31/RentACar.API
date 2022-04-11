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
    public class CarController : Controller
    {
        private readonly ICarManager _currentManager;

        public CarController(ICarManager carManager)
        {
            _currentManager = carManager;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCarsForDesktop(Guid id)
        {
            return Ok(await _currentManager.GetAllCarsForDesktop(id));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get([FromRoute] Guid id)
        {
            return Ok(await _currentManager.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Car>> Post([FromBody] Car car)
        {
            return Ok(await _currentManager.Add(car));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> Put([FromRoute] Guid id, [FromBody] Car car)
        {
            if (id != car.Car_Id)
                return BadRequest();
            return Ok(await _currentManager.Update(car));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete([FromRoute] Guid id)
        {
            return Ok(await _currentManager.Delete(id));
        }
    }
}
