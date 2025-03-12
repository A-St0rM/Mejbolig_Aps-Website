using M.E.J_PropertyWebsite.Server.DTO;
using M.E.J_PropertyWebsite.Server.Models;
using M.E.J_PropertyWebsite.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyTypeController : ControllerBase
    {
        private readonly AzureDBContext _context;

        public PropertyTypeController(AzureDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetPropertyTypes")]
        public IActionResult GetPropertyTypes()
        {
            var propertyTypes = _context.PropertyType.ToList();
            return Ok(propertyTypes);
        }

        [HttpPost]
        [Route("CreatePropertyType")]
        public IActionResult CreatePropertyType([FromBody] PropertyType propertyType)
        {
            _context.PropertyType.Add(propertyType);
            _context.SaveChanges();

            return Created("", propertyType);
        }

        [HttpDelete]
        [Route("DeletePropertyType/{id}")]
        public IActionResult DeletePropertyType(int id)
        {
            var propertyType = _context.PropertyType.FirstOrDefault(p => p.PropertyTypeId == id);
            if (propertyType == null)
            {
                return NotFound();
            }

            _context.PropertyType.Remove(propertyType);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
