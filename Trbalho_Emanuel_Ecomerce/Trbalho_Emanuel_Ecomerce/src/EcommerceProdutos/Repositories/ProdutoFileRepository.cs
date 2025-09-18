using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Repositories
{
    public class ProdutoFileRepository : IProdutoRepository
    {
        public List<Produto> Carregar(string path)
        {
            var lista = new List<Produto>();
            if (!File.Exists(path)) return lista;
            foreach (var linha in File.ReadAllLines(path))
            {
                var c = linha.Split(';');
                if (c.Length < 4) continue;
                lista.Add(new Produto
                {
                    Codigo = int.Parse(c[0]),
                    Nome = c[1],
                    Preco = double.Parse(c[2]),
                    Quantidade = int.Parse(c[3])
                });
            }
            return lista;
        }

        public void Salvar(IEnumerable<Produto> produtos, string path)
        {
            var linhas = produtos.Select(p => $"{p.Codigo};{p.Nome};{p.Preco};{p.Quantidade}");
            File.WriteAllLines(path, linhas);
        }
    }

}
