using _123Vendas.Venda.Application.Features.Commands.Vendas.Criar;
using _123Vendas.Venda.Application.Features.Commands.Vendas.Listar;
using _123Vendas.Venda.Domain.Entities.Vendas;
using Microsoft.AspNetCore.Mvc;

namespace _123Vendas.VendaAPI.Controllers
{
    [ApiController]
    [Route("api/vendas")]
    public class VendasController : ApiBaseController
    {
        /// <summary>
        /// Cria registro de vendas.
        /// </summary>      
        /// <returns>Um <see cref="Guid"/> com o novo registro de venda.</returns>
        [HttpPost("criar-venda")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Created(string.Empty, message);
        }

        /// <summary>
        /// Recupera uma venda ou uma lista de vendas registradas.
        /// </summary>
        /// <returns>uma lista de vendas.</returns>
        [HttpGet("listar-venda/{numero-venda}")]
        [ProducesResponseType(typeof(List<OrdemVenda>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarVendaAsync()
        {
            var command = new ListarVendaCommand();
            var vendas = await GetMediator().Send(command);

            return Ok(vendas);
        }

        /// <summary>
        /// Alterar dados da venda.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("alterar-venda/{numero-venda}")]
        [ProducesResponseType(typeof(CriarVendaCommand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlterarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Ok(message);
        }

        /// <summary>
        ///  Atualiza dados de uma venda.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("atualizar-venda/{numero-venda}")]
        [ProducesResponseType(typeof(CriarVendaCommand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Ok(message);
        }

        /// <summary>
        /// Deleta dados de um registro venda
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("apagar-venda/{numero-venda}")]
        [ProducesResponseType(typeof(CriarVendaCommand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletarVendaAsync([FromBody] CriarVendaCommand command)
        {
            var message = await GetMediator().Send(command);
            return Ok(message);
        }
    }

}
