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

        [HttpDelete]
        public async Task<object> DeleteAsync([FromHeader] string keyPedido)
        {
            try
            {
                Pedido pedido = new()
                {
                    Id = keyPedido
                };

                var pedidoExcluido = await pedido.ExcluirAsync();

                if (pedidoExcluido)
                    return Ok();
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        public async Task<object> GetAsync([FromHeader] string keyPedido)
        {
            try
            {
                var pedido = new Pedido();
                pedido.Id = keyPedido;

                var retorno = await pedido.CarregarAsync();

                if (retorno != null)
                    return Ok(retorno);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<object> GetAllAsync()
        {
            try
            {
                var pedido = new Pedido();
                var retorno = await pedido.CarregarTodosAsync();

                if (retorno!= null && retorno.Any())
                    return Ok(retorno);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        public async Task<object> PutAsync([FromHeader] string keyPedido, [FromBody] Pedido pedido)
        {
            try
            {
                pedido.Id = keyPedido;
                var retorno = await pedido.AtualizarAsync();

                if (retorno != null)
                    return Ok(retorno);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
