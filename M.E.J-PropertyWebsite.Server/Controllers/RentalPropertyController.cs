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
                .Include(rp => rp.PropertyPrice)
                .Select(rp => new RentalPropertyDTO
                {
                    RentalProperty_id = rp.RentalProperty_id,
                    PropertyName = rp.PropertyName,
                    PropertyAddress = rp.PropertyAddress,
                    Description = rp.Description,
                    PropertySquareFootage = rp.PropertySquareFootage,
                    IsAvailable = rp.IsAvailable,
                    PetsAllowed = rp.PetsAllowed,
                    PropertyRoomSize = rp.PropertyRoomSize,
                    DateAvailable = rp.DateAvailable,
                    PropertyPrice = rp.PropertyPrice != null ? new PropertyPriceDTO
                    {
                        Deposit = rp.PropertyPrice.Deposit,
                        RentalPrice = rp.PropertyPrice.RentalPrice,
                        Aconto = rp.PropertyPrice.Aconto,
                        PropertyPriceId = rp.PropertyPrice.RentalProperty_id
                    } : null
                })
                .ToList();

            return Ok(rentalProperties);
        }

        [HttpGet]
		[Route("GetRentalPropertyById/{id}")]
		public IActionResult GetRentalPropertyById(int id)
		{
			var rentalProperty = _context.RentalProperty
				.Where(rp => rp.RentalProperty_id == id)
				.Select(rp => new RentalPropertyDTO
				{
                    RentalProperty_id = rp.RentalProperty_id,
                    PropertyName = rp.PropertyName,
                    PropertyAddress = rp.PropertyAddress,
                    Description = rp.Description,
                    PropertySquareFootage = rp.PropertySquareFootage,
                    IsAvailable = rp.IsAvailable,
                    PetsAllowed = rp.PetsAllowed,
                    PropertyRoomSize = rp.PropertyRoomSize,
                    DateAvailable = rp.DateAvailable,
                    PropertyPrice = new PropertyPriceDTO
                    {
                        Deposit = rp.PropertyPrice.Deposit,
                        RentalPrice = rp.PropertyPrice.RentalPrice,
                        Aconto = rp.PropertyPrice.Aconto,
                        PropertyPriceId = rp.PropertyPrice.Price_Id
                    }
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
        public IActionResult AddRentalProperty([FromBody] RentalPropertyDTO rentalPropertyDTO)
        {
            if (rentalPropertyDTO == null || string.IsNullOrEmpty(rentalPropertyDTO.PropertyName) || string.IsNullOrEmpty(rentalPropertyDTO.PropertyAddress))
            {
                return BadRequest("Rental property details are missing.");
            }

            var rentalProperty = new RentalProperty
            {
                RentalProperty_id = rentalPropertyDTO.RentalProperty_id,
                PropertyName = rentalPropertyDTO.PropertyName,
                PropertyAddress = rentalPropertyDTO.PropertyAddress,
                Description = rentalPropertyDTO.Description,
                PropertySquareFootage = rentalPropertyDTO.PropertySquareFootage,
                IsAvailable = rentalPropertyDTO.IsAvailable,
                PetsAllowed = rentalPropertyDTO.PetsAllowed,
                PropertyRoomSize = rentalPropertyDTO.PropertyRoomSize,
                DateAvailable = rentalPropertyDTO.DateAvailable,
                PropertyPrice = new PropertyPrice
                {
                    Deposit = rentalPropertyDTO.PropertyPrice.Deposit,
                    RentalPrice = rentalPropertyDTO.PropertyPrice.RentalPrice,
                    Aconto = rentalPropertyDTO.PropertyPrice.Aconto,
                    Price_Id = rentalPropertyDTO.PropertyPrice.PropertyPriceId
                }
            };

            _context.RentalProperty.Add(rentalProperty);
            _context.SaveChanges();

            return Ok(new { Message = "Rental property added successfully!" });
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateRentalProperty")]
        public IActionResult UpdateRentalProperty([FromBody] RentalPropertyDTO rentalPropertyDTO)
        {
            if (rentalPropertyDTO == null || rentalPropertyDTO.RentalProperty_id == 0 || string.IsNullOrEmpty(rentalPropertyDTO.PropertyName) || string.IsNullOrEmpty(rentalPropertyDTO.PropertyAddress))
            {
                return BadRequest("Rental property details are missing.");
            }

            var existingRentalProperty = _context.RentalProperty
                .Include(rp => rp.PropertyPrice)
                .FirstOrDefault(rp => rp.RentalProperty_id == rentalPropertyDTO.RentalProperty_id);

            if (existingRentalProperty == null)
            {
                return NotFound("Rental property not found.");
            }

            existingRentalProperty.PropertyName = rentalPropertyDTO.PropertyName;
            existingRentalProperty.PropertyAddress = rentalPropertyDTO.PropertyAddress;
            existingRentalProperty.Description = rentalPropertyDTO.Description;
            existingRentalProperty.PropertySquareFootage = rentalPropertyDTO.PropertySquareFootage;
            existingRentalProperty.IsAvailable = rentalPropertyDTO.IsAvailable;
            existingRentalProperty.PetsAllowed = rentalPropertyDTO.PetsAllowed;
            existingRentalProperty.PropertyRoomSize = rentalPropertyDTO.PropertyRoomSize;
            existingRentalProperty.DateAvailable = rentalPropertyDTO.DateAvailable;

            if (existingRentalProperty.PropertyPrice == null)
            {
                existingRentalProperty.PropertyPrice = new PropertyPrice();
            }

            existingRentalProperty.PropertyPrice.Deposit = rentalPropertyDTO.PropertyPrice.Deposit;
            existingRentalProperty.PropertyPrice.RentalPrice = rentalPropertyDTO.PropertyPrice.RentalPrice;
            existingRentalProperty.PropertyPrice.Aconto = rentalPropertyDTO.PropertyPrice.Aconto;
            existingRentalProperty.PropertyPrice.Price_Id = rentalPropertyDTO.PropertyPrice.PropertyPriceId;

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

			var rentalProperty = _context.RentalProperty.FirstOrDefault(rp => rp.RentalProperty_id == id);

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
