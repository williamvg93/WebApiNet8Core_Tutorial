using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.DTOs;
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
        public async Task<ActionResult<List<RolDTO>>> Get()
        {
            var rolListDTO = new List<RolDTO>();
            var rolesList = await _context.Roles.ToListAsync();

            foreach (var ele in rolesList)
            {
                rolListDTO.Add(new RolDTO
                {
                    Id = ele.IdRol,
                    Name = ele.Name
                });
            }

            return Ok(rolListDTO);
        }

        [HttpGet]
        [Route("GetRol/{id}")]
        public async Task<ActionResult<RolDTO>> Get(int id)
        {
            var rolDto = new RolDTO();
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) return NotFound();
            rolDto.Id = rol.IdRol;
            rolDto.Name = rol.Name;
            // return rol == null ? NotFound() : Ok(rol);
            return Ok(rolDto);
        }

        [HttpPost]
        [Route("AddRol")]
        public async Task<ActionResult<RolDTO>> AddRol(RolDTO rolDTO)
        {
            var rol = new Rol { 
                Name = rolDTO.Name
            };

            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
            return Ok("Rol Creado Correctamente");
        }

        [HttpPut]
        [Route("UpdateRol")]
        public async Task<ActionResult<RolDTO>> Update(RolDTO rolDTO)
        {
            var rol = await _context.Roles.FindAsync(rolDTO.Id);
            rol.Name = rolDTO.Name;
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
            return Ok("Rol was Update");
        }

        [HttpDelete]
        [Route("DeleteRol")]
        public async Task<ActionResult<RolDTO>> Delete(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol is null) return NotFound($"No Rol was found with this ID({id})");
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return Ok("Rol was Deleted");
        }


    }
}
