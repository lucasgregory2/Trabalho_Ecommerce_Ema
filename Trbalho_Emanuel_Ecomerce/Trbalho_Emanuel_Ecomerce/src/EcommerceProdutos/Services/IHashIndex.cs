using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Services
{
    public interface IHashIndex
    {
        void Inserir(Produto p);          // usa p.Codigo como chave
        Produto? Buscar(int codigo);
        bool Remover(int codigo);
    }
}

