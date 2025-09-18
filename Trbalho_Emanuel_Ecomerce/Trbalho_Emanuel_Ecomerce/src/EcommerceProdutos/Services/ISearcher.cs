using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Services
{
    public interface ISearcher
    {
        int BuscaBinariaPorNome(List<Produto> itens, string nome);   // retorna índice ou -1
        int BuscaBinariaPorPreco(List<Produto> itens, double preco);  // idem
    }
}