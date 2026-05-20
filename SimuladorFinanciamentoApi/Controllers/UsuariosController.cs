using SimuladorFinanciamentoApi.Services;
using SimuladorFinanciamentoApi.DTOs;
using SimuladorFinanciamentoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SimuladorFinanciamentoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioDto dto)
        {
            try
            {
                var usuarioCriado = await _usuarioService.CriarUsuario(dto);
                return Ok(usuarioCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _usuarioService.ListarUsuarios();
            return Ok(usuarios);
        }
    }
}