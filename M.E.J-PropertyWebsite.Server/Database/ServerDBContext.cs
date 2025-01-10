using Microsoft.EntityFrameworkCore;

namespace M.E.J_PropertyWebsite.Server.Database
{
	public class ServerDBContext : DbContext
	{
		public ServerDBContext(DbContextOptions<ServerDBContext> options) : base(options)
		{
		}
	
	}
}
