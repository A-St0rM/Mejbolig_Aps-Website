using M.E.J_PropertyWebsite.Server.Database;
using M.E.J_PropertyWebsite.Server.DTO;
using M.E.J_PropertyWebsite.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RentalPropertyController : ControllerBase
	{
		private readonly AzureDBContext _context;

		public RentalPropertyController(AzureDBContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("GetRentalProperties")]
		public IActionResult GetRentalProperties()
		{
			var rentalProperties = _context.RentalProperty
				.Select(rp => new RentalPropertyDTO
				{
                    RentalPropertyId = rp.RentalPropertyId,
                    PropertyName = rp.PropertyName,
                    PropertyAddress = rp.PropertyAddress,
                    Description = rp.Description,
                    PropertySquareFootage = rp.PropertySquareFootage,
                    IsAvailable = rp.IsAvailable,
                    RentalPrice = rp.RentalPrice,
                    Deposit = rp.Deposit,
                    Aconto = rp.Aconto,
                    PetsAllowed = rp.PetsAllowed,
                    PropertyRoomSize = rp.PropertyRoomSize,
                    DateAvailable = rp.DateAvailable
                })
				.ToList();

			return Ok(rentalProperties);
		}

		[HttpGet]
		[Route("GetRentalPropertyById/{id}")]
		public IActionResult GetRentalPropertyById(int id)
		{
			var rentalProperty = _context.RentalProperty
				.Where(rp => rp.RentalPropertyId == id)
				.Select(rp => new RentalPropertyDTO
				{
                    RentalPropertyId = rp.RentalPropertyId,
                    PropertyName = rp.PropertyName,
                    PropertyAddress = rp.PropertyAddress,
                    Description = rp.Description,
                    PropertySquareFootage = rp.PropertySquareFootage,
                    IsAvailable = rp.IsAvailable,
                    RentalPrice = rp.RentalPrice,
                    Deposit = rp.Deposit,
                    Aconto = rp.Aconto,
                    PetsAllowed = rp.PetsAllowed,
                    PropertyRoomSize = rp.PropertyRoomSize,
                    DateAvailable = rp.DateAvailable
                })
				.FirstOrDefault();

			if (rentalProperty == null)
			{
				return NotFound("Rental property not found.");
			}

			return Ok(rentalProperty);
		}

		[Authorize]
		[HttpPost]
		[Route("AddRentalProperty")]
		public IActionResult AddRentalProperty([FromBody] RentalProperty rentalProperty)
		{
			if (rentalProperty == null || string.IsNullOrEmpty(rentalProperty.PropertyName) || string.IsNullOrEmpty(rentalProperty.PropertyAddress) || rentalProperty.RentalPrice == 0)
			{
				return BadRequest("Rental property details are missing.");
			}

			_context.RentalProperty.Add(rentalProperty);
			_context.SaveChanges();

			return Ok(new { Message = "Rental property added successfully!" });
		}

		[Authorize]
		[HttpPut]
		[Route("UpdateRentalProperty")]
		public IActionResult UpdateRentalProperty([FromBody] RentalProperty rentalProperty)
		{
			if (rentalProperty == null || rentalProperty.RentalPropertyId == 0 || string.IsNullOrEmpty(rentalProperty.PropertyName) || string.IsNullOrEmpty(rentalProperty.PropertyAddress) || rentalProperty.RentalPrice == 0)
			{
				return BadRequest("Rental property details are missing.");
			}

			var existingRentalProperty = _context.RentalProperty.FirstOrDefault(rp => rp.RentalPropertyId == rentalProperty.RentalPropertyId);

			if (existingRentalProperty == null)
			{
				return NotFound("Rental property not found.");
			}

			existingRentalProperty.PropertyName = rentalProperty.PropertyName;
			existingRentalProperty.PropertyAddress = rentalProperty.PropertyAddress;
			existingRentalProperty.Description = rentalProperty.Description;
			existingRentalProperty.PropertySquareFootage = rentalProperty.PropertySquareFootage;
			existingRentalProperty.IsAvailable = rentalProperty.IsAvailable;
			existingRentalProperty.RentalPrice = rentalProperty.RentalPrice;
			existingRentalProperty.Deposit = rentalProperty.Deposit;
			existingRentalProperty.Aconto = rentalProperty.Aconto;
			existingRentalProperty.PetsAllowed = rentalProperty.PetsAllowed;
			existingRentalProperty.PropertyRoomSize = rentalProperty.PropertyRoomSize;
			existingRentalProperty.DateAvailable = rentalProperty.DateAvailable;

			_context.SaveChanges();

			return Ok(new { Message = "Rental property updated successfully!" });
		}

		[Authorize]
		[HttpDelete]
		[Route("DeleteRentalProperty/{id}")]
		public IActionResult DeleteRentalProperty(int id)
		{
			if (id == 0)
			{
				return BadRequest("Rental property ID is missing.");
			}

			var rentalProperty = _context.RentalProperty.FirstOrDefault(rp => rp.RentalPropertyId == id);

			if (rentalProperty == null)
			{
				return NotFound("Rental property not found.");
			}

			_context.RentalProperty.Remove(rentalProperty);
			_context.SaveChanges();

			return Ok(new { Message = "Rental property deleted successfully!" });
		}
	}
}
