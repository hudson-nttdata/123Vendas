using _123Vendas.Venda.Application.Features.Commands.Vendas.Criar;
using Microsoft.AspNetCore.Mvc;

namespace _123Vendas.VendaAPI.Controllers
{
    [ApiController]
    [Route("api/vendas")]
    public class VendasController : ApiBaseController
    {
        /// <summary>
        /// Cria registros de vendas.
        /// </summary>      
        /// <returns>A <see cref="CriarVendaCommand"/> um novo registro de venda.</returns>
        [HttpPost("criar-venda")]
        [ProducesResponseType(typeof(CriarVendaCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CriarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Ok(message);
        }
      
    }

}
