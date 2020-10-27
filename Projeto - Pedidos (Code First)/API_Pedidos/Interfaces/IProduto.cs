using API_Pedidos.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pedidos.Interfaces
{
    interface IProduto
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid Id);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Excluir(Guid Id);
        List<Produto> BuscarPorNome(string nome);

    }
}
