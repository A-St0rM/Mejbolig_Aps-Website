using Microsoft.AspNetCore.Mvc;
using M.E.J_PropertyWebsite.Server.Database;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalHistoryController : ControllerBase
    {
        private readonly AzureDBContext _context;

        public RentalHistoryController(AzureDBContext context)
        {
            _context = context;
        }
    }
}
