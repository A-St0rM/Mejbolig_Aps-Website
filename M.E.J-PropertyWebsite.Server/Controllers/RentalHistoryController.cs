using Microsoft.AspNetCore.Mvc;
using M.E.J_PropertyWebsite.Server.Database;
using M.E.J_PropertyWebsite.Server.Models;
using M.E.J_PropertyWebsite.Server.DTO;
using Microsoft.AspNetCore.Authorization;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RentalHistoryController : ControllerBase
    {
        private readonly AzureDBContext _context;

        public RentalHistoryController(AzureDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetRentalHistory")]
        public IActionResult GetRentalHistory()
        {
            var rentalHistory = _context.rentalHistories
                .Select(rh => new RentalHistoryDTO
                {
                    RentalHistoryId = rh.RentalHistoryId,
                    RentalPropertyId = rh.RentalPropertyId,
                    TenantId = rh.TenantId,
                    MoveInDate = rh.MoveInDate,
                    MoveOutDate = rh.MoveOutDate
                })
                .ToList();

            return Ok(rentalHistory);
        }
    }
}
