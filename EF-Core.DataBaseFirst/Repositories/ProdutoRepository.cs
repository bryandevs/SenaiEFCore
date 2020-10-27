using EF_Core.DataBaseFirst.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core.DataBaseFirst.Repositories
{
    public class ProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
            _ctx.Pedidos.FirstOrDefault
        }

    }
}
