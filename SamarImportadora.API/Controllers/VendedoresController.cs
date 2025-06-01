using Microsoft.AspNetCore.Mvc;
using SamarImportadora.Core.DTOs;
using SamarImportadora.Core.Interfaces;

namespace SamarImportadora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedorService _vendedorService;

        public VendedoresController(IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendedorDto>>> Get()
        {
            var vendedores = await _vendedorService.ObtenerTodosVendedoresAsync();
            return Ok(vendedores);
        }
    }
}
