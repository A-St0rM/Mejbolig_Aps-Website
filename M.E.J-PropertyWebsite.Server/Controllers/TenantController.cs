﻿using M.E.J_PropertyWebsite.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M.E.J_PropertyWebsite.Server.Models;
using M.E.J_PropertyWebsite.Server.DTO;
using Microsoft.AspNetCore.Authorization;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
    [Authorize]
    [ApiController]
	[Route("api/[controller]")]
	public class TenantController : ControllerBase
	{
		private readonly AzureDBContext _context;

		public TenantController(AzureDBContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("GetTenants")]
		public IActionResult GetTenants()
		{
            var tenants = _context.Tenant
                .Select(t => new TenantDTO
                {
                    TenantId = t.TenantId,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Email = t.Email,
                    PhoneNumber = t.PhoneNumber
                })
                .ToList();

            return Ok(tenants);
        }

		[HttpPost]
		[Route("AddTenant")]
		public IActionResult AddTenant([FromBody] Tenant tenant)
		{
			if (tenant == null || string.IsNullOrEmpty(tenant.FirstName) || string.IsNullOrEmpty(tenant.LastName) || string.IsNullOrEmpty(tenant.Email) || string.IsNullOrEmpty(tenant.PhoneNumber))
			{
				return BadRequest("Tenant details are missing.");
			}

			_context.Tenant.Add(tenant);
			_context.SaveChanges();

			return Ok(new { Message = "Tenant added successfully!" });
		}

		[HttpPut]
		[Route("UpdateTenant")]
		public IActionResult UpdateTenant([FromBody] Tenant tenant)
		{
			if (tenant == null || tenant.TenantId == 0 || string.IsNullOrEmpty(tenant.FirstName) || string.IsNullOrEmpty(tenant.LastName) || string.IsNullOrEmpty(tenant.Email) || string.IsNullOrEmpty(tenant.PhoneNumber))
			{
				return BadRequest("Tenant details are missing.");
			}

			var existingTenant = _context.Tenant.FirstOrDefault(t => t.TenantId == tenant.TenantId);

			if (existingTenant == null)
			{
				return NotFound("Tenant not found.");
			}

			existingTenant.FirstName = tenant.FirstName;
			existingTenant.LastName = tenant.LastName;
			existingTenant.Email = tenant.Email;
			existingTenant.PhoneNumber = tenant.PhoneNumber;

			_context.SaveChanges();

			return Ok(new { Message = "Tenant updated successfully!" });
		}

		[HttpDelete]
		[Route("DeleteTenant/{tenantId}")]
		public IActionResult DeleteTenant(int tenantId)
		{
			if (tenantId == 0)
			{
				return BadRequest("Tenant ID is missing.");
			}

			var tenant = _context.Tenant.FirstOrDefault(t => t.TenantId == tenantId);

			if (tenant == null)
			{
				return NotFound("Tenant not found.");
			}

			_context.Tenant.Remove(tenant);
			_context.SaveChanges();

			return Ok(new { Message = "Tenant deleted successfully!" });
		}
	}
}
