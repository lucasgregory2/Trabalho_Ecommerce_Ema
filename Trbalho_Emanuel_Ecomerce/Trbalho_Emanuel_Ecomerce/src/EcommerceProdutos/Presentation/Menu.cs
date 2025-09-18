using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Repositories;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Services;


namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Presentation
{
    public class Menu
    {
        private readonly List<Produto> _produtos;
        private readonly IHashIndex _hash;
        private readonly ISorter _sorter;
        private readonly ISearcher _searcher;
        private readonly IProdutoRepository _repo;
        private const string Caminho = "estoque.csv";

        public Menu()
        {
            _produtos = new List<Produto>();
            _hash = new HashIndexLinear(211);
            _sorter = new QuickSorter();
            _searcher = new BinarySearcher();
            _repo = new ProdutoFileRepository();
        }

        public void Loop()
        {
            int op;
            do
            {
                Console.WriteLine("\n1-Adicionar  2-Buscar(código)  3-Listar por Nome  4-Listar por Preço");
                Console.WriteLine("5-Binária Nome  6-Binária Preço  7-Salvar  8-Carregar  0-Sair");
                Console.Write("Escolha: ");
                _ = int.TryParse(Console.ReadLine(), out op);
                switch (op)
                {
                    case 1: Adicionar(); break;
                    case 2: BuscarCodigo(); break;
                    case 3: ListarOrdenadoNome(); break;
                    case 4: ListarOrdenadoPreco(); break;
                    case 5: BuscarBinariaNome(); break;
                    case 6: BuscarBinariaPreco(); break;
                    case 7: Salvar(); break;
                    case 8: Carregar(); break;
                }
            } while (op != 0);
        }

        private void Adicionar()
        {
            Console.Write("Código: "); int cod = int.Parse(Console.ReadLine()!);
            Console.Write("Nome: "); string nome = Console.ReadLine()!;
            Console.Write("Preço: "); double preco = double.Parse(Console.ReadLine()!);
            Console.Write("Quantidade: "); int qtd = int.Parse(Console.ReadLine()!);

            var p = new Produto { Codigo = cod, Nome = nome, Preco = preco, Quantidade = qtd };
            _produtos.Add(p);
            _hash.Inserir(p);
            Console.WriteLine("OK!");
        }

        private void BuscarCodigo()
        {
            Console.Write("Código: "); int cod = int.Parse(Console.ReadLine()!);
            var p = _hash.Buscar(cod);
            Console.WriteLine(p is null ? "Não encontrado." : p.ToString());
        }

        private void ListarOrdenadoNome()
        {
            var copia = _produtos.ToList();
            _sorter.QuickSortPorNome(copia);
            copia.ForEach(p => Console.WriteLine(p));
        }

        private void ListarOrdenadoPreco()
        {
            var copia = _produtos.ToList();
            _sorter.QuickSortPorPreco(copia);
            copia.ForEach(p => Console.WriteLine(p));
        }

        private void BuscarBinariaNome()
        {
            Console.Write("Nome exato: "); string nome = Console.ReadLine()!;
            var copia = _produtos.ToList();
            _sorter.QuickSortPorNome(copia);
            int i = _searcher.BuscaBinariaPorNome(copia, nome);
            Console.WriteLine(i >= 0 ? copia[i].ToString() : "Não encontrado.");
        }

        private void BuscarBinariaPreco()
        {
            Console.Write("Preço exato: "); double preco = double.Parse(Console.ReadLine()!);
            var copia = _produtos.ToList();
            _sorter.QuickSortPorPreco(copia);
            int i = _searcher.BuscaBinariaPorPreco(copia, preco);
            Console.WriteLine(i >= 0 ? copia[i].ToString() : "Não encontrado.");
        }

        private void Salvar() { _repo.Salvar(_produtos, Caminho); Console.WriteLine("Salvo."); }
        private void Carregar()
        {
            _produtos.Clear();
            _produtos.AddRange(_repo.Carregar(Caminho));
            // reconstroi índice hash
            foreach (var p in _produtos) _hash.Inserir(p);
            Console.WriteLine("Carregado.");
        }
    }

}
