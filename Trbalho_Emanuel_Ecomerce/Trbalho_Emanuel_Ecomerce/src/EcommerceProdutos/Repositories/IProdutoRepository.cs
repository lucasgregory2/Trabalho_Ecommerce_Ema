using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Repositories
{
    public interface IProdutoRepository
    {
        void Salvar(IEnumerable<Produto> produtos, string path);
        List<Produto> Carregar(string path);
    }
}
