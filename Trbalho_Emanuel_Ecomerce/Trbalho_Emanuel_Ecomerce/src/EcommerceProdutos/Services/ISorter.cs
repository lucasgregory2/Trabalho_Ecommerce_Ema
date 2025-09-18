using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Services
{
    public interface ISorter
    {
        void QuickSortPorNome(List<Produto> itens);
        void QuickSortPorPreco(List<Produto> itens);
    }

   
}
