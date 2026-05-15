using Microsoft.AspNetCore.Mvc;
using SimuladorFinanciamentoApi.DTOs;
using SimuladorFinanciamentoApi.Services;

namespace SimuladorFinanciamentoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimulacaoController : ControllerBase
    {
        private readonly SimuladorService _simuladorService;
        public SimulacaoController(SimuladorService simuladorService)
        {
            _simuladorService = simuladorService;
        }
        [HttpPost]
        public IActionResult Simular(SimulacaoRequestDto request)
        {
            try
            {
                var resultado = _simuladorService.SimularFinanciamento(request);    
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}