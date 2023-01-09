using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;

namespace Compartilhado.Model
{
    public enum StatusPedido
    {
        Coletado,
        Pago,
        Faturado
    }

    [DynamoDBTable("pedidos")]
    public class Pedido
    {
        public string Id { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public List<Produto> Produtos { get; set; }
        public Cliente cliente { get; set; }
        public Pagamento Pagamento { get; set; }
        public string JustificativaDeCancelamento { get; set; }
        public StatusPedido Status { get; set; }
        public bool Cancelado { get; set; }
    }
}
