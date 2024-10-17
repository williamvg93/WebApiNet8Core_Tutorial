using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        // Inyección de dependencias
        public RolController(WebApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<ActionResult<List<Rol>>> Get()
        {
            var rolesList = await _context.Roles.ToListAsync();
            return Ok(rolesList);
        }


    }
}
