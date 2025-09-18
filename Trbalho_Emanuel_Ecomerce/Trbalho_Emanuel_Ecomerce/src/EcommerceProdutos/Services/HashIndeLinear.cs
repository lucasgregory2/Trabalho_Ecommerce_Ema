using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Services
{
    public class HashIndexLinear : IHashIndex
    {
        private readonly Produto?[] tabela;
        public HashIndexLinear(int capacidade = 211) => tabela = new Produto?[capacidade];
        private int Hash(int codigo) => Math.Abs(codigo) % tabela.Length;

        public void Inserir(Produto p)
        {
            int i = Hash(p.Codigo);
            for (int k = 0; k < tabela.Length; k++)
            {
                int idx = (i + k) % tabela.Length;
                if (tabela[idx] == null || tabela[idx]!.Codigo == p.Codigo)
                { tabela[idx] = p; return; }
            }
            throw new InvalidOperationException("Tabela hash cheia.");
        }

        public Produto? Buscar(int codigo)
        {
            int i = Hash(codigo);
            for (int k = 0; k < tabela.Length; k++)
            {
                int idx = (i + k) % tabela.Length;
                var p = tabela[idx];
                if (p == null) return null;
                if (p.Codigo == codigo) return p;
            }
            return null;
        }

        public bool Remover(int codigo)
        {
            int i = Hash(codigo);
            for (int k = 0; k < tabela.Length; k++)
            {
                int idx = (i + k) % tabela.Length;
                var p = tabela[idx];
                if (p == null) return false;
                if (p.Codigo == codigo) { tabela[idx] = null; return true; }
            }
            return false;
        }
    }

}
