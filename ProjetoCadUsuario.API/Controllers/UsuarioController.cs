using Microsoft.AspNetCore.Mvc;
using ProjetoCadUsuario.Application.DTOs;
using ProjetoCadUsuario.Application.Interfaces;

namespace ProjetoCadUsuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var usuario = await _usuarioAppService.ObterPorIdAsync(id);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioAppService.ObterTodosAsync();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuarioDto)
        {
            await _usuarioAppService.AdicionarAsync(usuarioDto);
            return CreatedAtAction(nameof(Get), new { id = usuarioDto.Id }, usuarioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UsuarioDTO usuarioDto)
        {
            if (id != usuarioDto.Id) return BadRequest();

            await _usuarioAppService.AtualizarAsync(usuarioDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _usuarioAppService.RemoverAsync(id);
            return NoContent();
        }
    }

}
