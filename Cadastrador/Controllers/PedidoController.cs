using Compartilhado;
using Compartilhado.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cadastrador.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        [HttpPost]
        public async Task<object> PostAsync([FromBody] Pedido pedido)
        {
            try
            {
                pedido.Id = Guid.NewGuid().ToString();
                pedido.DataDeCriacao = DateTime.Now;

                await pedido.SalvarAsync();

                return Ok(pedido.Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
