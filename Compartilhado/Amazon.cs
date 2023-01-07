using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Compartilhado.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compartilhado
{
    public static class Amazon
    {
        public static async Task SalvarAsync(this Pedido pedido)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);

            await context.SaveAsync(pedido);
        }

        public static async Task<bool> ExcluirAsync(this Pedido pedido)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);
            var retorno = context.DeleteAsync(pedido);

            if (retorno.Status == TaskStatus.RanToCompletion)
                return false;
            else
                return true;
        }

        public static async Task<Pedido> CarregarAsync(this Pedido pedido)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);
            var retorno = await context.LoadAsync<Pedido>(pedido.Id);

            return retorno;
        }

        public static async Task<IEnumerable<Pedido>> CarregarTodosAsync(this Pedido pedido)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);
            var table = context.GetTargetTable<Pedido>();
            var scanOps = new ScanOperationConfig();
            var results = table.Scan(scanOps);
            List<Document> data = await results.GetNextSetAsync();

            return context.FromDocuments<Pedido>(data);
        }

        public static async Task<Pedido> AtualizarAsync(this Pedido pedido)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);
            var table = context.GetTargetTable<Pedido>();

            var putItemRequest = new PutItemRequest
            {
                TableName = table.TableName,
                Item = new Dictionary<string, AttributeValue> {
                        {
                          "Nome",
                          new AttributeValue {
                            S = pedido.cliente.Nome
                          }
                        },
                        {
                          "Email",
                          new AttributeValue {
                            S = pedido.cliente.Email
                          }
                        }
                }
            };

            var retorno = client.PutItemAsync(putItemRequest);
            var Newcontext = new DynamoDBContext(client);
            await Newcontext.SaveAsync(pedido);
            return null;
        }
    }
}
