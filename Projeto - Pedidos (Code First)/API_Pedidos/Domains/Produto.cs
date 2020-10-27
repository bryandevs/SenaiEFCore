using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Pedidos.Domains
{
    /// <summary>
    /// Domínio referente ao produto
    /// </summary>
    public class Produto : BaseDomain
    {
        public string NomeProduto { get; set; }
        public float Preco { get; set; }

        [NotMapped] //Não mapeia a propriedade no banco de dados
        [JsonIgnore]//Ignora propriedade no retorno no Json
        public IFormFile Imagem { get; set; }

        //Url da imagem do produto salva no servidor
        public string UrlImagem { get; set; }

        //Propriedade referente ao relacionamento na classe PedidoItem com a classe Pedido
        public List<PedidoItem> PedidosItens { get; set; }

    }
}
