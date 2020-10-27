using System;
using System.Collections.Generic;

namespace EF_Core.DataBaseFirst.Domains
{
    public partial class PedidosItens
    {
        public Guid Id { get; set; }
        public Guid IdPedido { get; set; }
        public Guid IdProduto { get; set; }

        public virtual Pedidos IdPedidoNavigation { get; set; }
        public virtual Produtos IdProdutoNavigation { get; set; }
    }
}
