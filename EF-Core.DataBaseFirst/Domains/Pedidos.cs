using System;
using System.Collections.Generic;

namespace EF_Core.DataBaseFirst.Domains
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            PedidosItens = new HashSet<PedidosItens>();
        }

        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<PedidosItens> PedidosItens { get; set; }
    }
}
