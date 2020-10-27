using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API_Pedidos.Domains;
using API_Pedidos.Interfaces;
using API_Pedidos.Repositories;
using API_Pedidos.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProduto _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        /// <summary>
        /// Ler todos os produtos cadastrados
        /// </summary>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var produtos = _produtoRepository.Listar();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (produtos.Count == 0)
                    return NoContent();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca um único produto
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <returns>Produto buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busco o produto no repositorio
                var produto = _produtoRepository.BuscarPorId(id);

                //Verifica se o produto existe
                //Caso produto não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                Moeda dolar = new Moeda();

                return Ok(new
                {
                    produto,
                    ValorDolar = produto.Preco / dolar.GetDolarValue()
                });
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }


        }

        //FromForm - Recebe os dados do produto via form-Data
        /// <summary>
        /// Cadastra um produto na aplicação
        /// </summary>
        /// <param name="produto">Obejto completo de um produto</param>
        /// <returns>Produto cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                if (produto.Imagem != null)
                {
                    //Verifico se foi enviado um arquivo com a imagem
                    var urlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = urlImagem;
                }

                 //Adiciona um produto
                _produtoRepository.Adicionar(produto);

                //retorna ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera determinado produto da aplicação
        /// </summary>
        /// <param name="id">ID do Produto</param>
        /// <param name="produto">Objeto alterado do Produto</param>
        /// <returns>Produto alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um produto do sistema
        /// </summary>
        /// <param name="id">ID do produto a ser excluído</param>
        /// <returns>ID do produto excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _produtoRepository.Excluir(Id);

                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
