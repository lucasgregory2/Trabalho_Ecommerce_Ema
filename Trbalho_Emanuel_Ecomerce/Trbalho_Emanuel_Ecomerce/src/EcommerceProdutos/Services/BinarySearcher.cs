using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Services
{
    public class BinarySearcher : ISearcher
    {
        public int BuscaBinariaPorNome(List<Produto> itens, string nome) =>
            Busca(itens, (p) => string.Compare(p.Nome, nome, StringComparison.OrdinalIgnoreCase));

        public int BuscaBinariaPorPreco(List<Produto> itens, double preco) =>
            Busca(itens, (p) => p.Preco.CompareTo(preco));

        private int Busca(List<Produto> itens, Func<Produto, int> cmpToKey)
        {
            int lo = 0, hi = itens.Count - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int c = cmpToKey(itens[mid]);
                if (c == 0) return mid;
                if (c < 0) lo = mid + 1;
                else hi = mid - 1;
            }
            return -1;
        }
    }

}
