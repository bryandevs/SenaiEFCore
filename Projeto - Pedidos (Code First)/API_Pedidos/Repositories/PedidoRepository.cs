using API_Pedidos.Contexts;
using API_Pedidos.Domains;
using API_Pedidos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pedidos.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext ctx;

        public PedidoRepository()
        {
            ctx = new PedidoContext();

        }

        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">Lista de pedidos itens</param>
        /// <returns>Objeto Pedido</returns>
        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                Pedido pedido = new Pedido
                {
                    Status = "Pedido adicionado",
                    OrderDate = DateTime.Now
                };

                foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem {
                        IdPedido = pedido.Id, 
                        IdProduto = item.IdProduto,
                        });
                }

                ctx.Pedidos.Add(pedido);
                ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public Pedido BuscarPorId(Guid Id)
        {
            try
            {
                return ctx.Pedidos.FirstOrDefault(a => a.Id == Id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Pedido pedido)
        {
            try
            {
                Pedido pedidoTemp = BuscarPorId(pedido.Id);

                if (pedidoTemp == null)
                    throw new Exception("Pedido não encontrado");

                pedidoTemp.Status = pedido.Status;
                pedidoTemp.OrderDate = pedido.OrderDate;

                ctx.Pedidos.Update(pedidoTemp);

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid Id)
        {
            try
            {
                Pedido pedido = BuscarPorId(Id);

                if (pedido == null)
                    throw new Exception("Pedido não encontrado");

                ctx.Pedidos.Remove(pedido);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
