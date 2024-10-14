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

        // TODO: Criar command para operacao get
        /// <summary>
        /// Recupera uma venda ou uma lista de vendas registradas.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>uma lista de vendas.</returns>
        [HttpGet("listar-venda/{numero-venda}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CriarVendaCommand), StatusCodes.Status201Created)]
        public async Task<IActionResult> ListarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Ok(message);
        }

        // TODO: Criar command para operacao put
        /// <summary>
        /// Alterar dados da venda.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("alterar-venda/{numero-venda}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CriarVendaCommand), StatusCodes.Status201Created)]
        public async Task<IActionResult> AlterarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Ok(message);
        }

        // TODO: Criar command para operacao patch
        /// <summary>
        ///  Atualiza dados de uma venda.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("atualizar-venda/{numero-venda}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Ok(message);
        }

        // TODO: Criar command para operacao delete
        /// <summary>
        /// Deleta dados de um registro venda
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("apagar-venda/{numero-venda}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CriarVendaCommand), StatusCodes.Status201Created)]
        public async Task<IActionResult> DeletarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Ok(message);
        }
    }

}
