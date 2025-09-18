using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos
{
    internal class Program
    {
        static List<Produto> produtos = new List<Produto>();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1 - Adicionar produto");
                Console.WriteLine("2 - Buscar por código (Hashing)");
                Console.WriteLine("3 - Listar ordenado (QuickSort)");
                Console.WriteLine("4 - Buscar em lista ordenada (Busca Binária)");
                Console.WriteLine("5 - Salvar em arquivo");
                Console.WriteLine("6 - Carregar de arquivo");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");

                if (!int.TryParse(Console.ReadLine(), out opcao)) opcao = -1;

                switch (opcao)
                {
                    //case 1: AdicionarProduto(); break;
                    case 2: BuscarProduto(); break;
                    case 3: ListarOrdenado(); break;
                    case 4: BuscarBinaria(); break;
                    //case 5: SalvarArquivo(); break;
                    case 6: CarregarArquivo(); break;
                    case 0: Console.WriteLine("Saindo..."); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

            } while (opcao != 0);

        }

        private static void CarregarArquivo()
        {
            throw new NotImplementedException();
        }

        private static void BuscarBinaria()
        {
            throw new NotImplementedException();
        }

        private static void ListarOrdenado()
        {
            throw new NotImplementedException();
        }

        private static void BuscarProduto()
        {
            throw new NotImplementedException();
        }

    }
}
