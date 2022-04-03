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
    public class PackageController : Controller
    {
        private readonly IPackageManager _currentManager;

        public PackageController(IPackageManager packageManager)
        {
            _currentManager = packageManager;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> Get()
        {
            return Ok(await _currentManager.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> Get([FromRoute] Guid id)
        {
            return Ok(await _currentManager.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Package>> Post([FromBody] Package package)
        {
            return Ok(await _currentManager.Add(package));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Package>> Put([FromRoute] Guid id, [FromBody] Package package)
        {
            if (id != package.Package_Id)
                return BadRequest();
            return Ok(await _currentManager.Update(package));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Package>> Delete([FromRoute] Guid id)
        {
            return Ok(await _currentManager.Delete(id));
        }
    }
}
