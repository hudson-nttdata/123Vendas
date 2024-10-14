using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _123Vendas.VendaAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiBaseController : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender GetMediator() => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
