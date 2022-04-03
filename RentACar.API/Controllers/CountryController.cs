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
    public class CountryController : Controller
    {
        private readonly ICountryManager _currentManager;

        public CountryController(ICountryManager countryManager)
        {
            _currentManager = countryManager;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return Ok(await _currentManager.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get([FromRoute] Guid id)
        {
            return Ok(await _currentManager.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Country>> Post([FromBody] Country country)
        {
            return Ok(await _currentManager.Add(country));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> Put([FromRoute] Guid id, [FromBody] Country country)
        {
            if (id != country.Country_Id)
                return BadRequest();
            return Ok(await _currentManager.Update(country));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> Delete([FromRoute] Guid id)
        {
            return Ok(await _currentManager.Delete(id));
        }
    }
}
