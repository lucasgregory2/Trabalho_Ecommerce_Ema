using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models
{
    public class Produto
    {

        public int Codigo { get; set; }
        public string Nome { get; set; } = "";
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public override string ToString() =>
            $"Código: {Codigo}, Nome: {Nome}, Preço: {Preco:C}, Qtd: {Quantidade}";

        

    }




}
