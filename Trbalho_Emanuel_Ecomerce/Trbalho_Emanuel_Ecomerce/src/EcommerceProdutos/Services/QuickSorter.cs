using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Models;

namespace Trabalho_Emanuel_Ecommerce.src.EcommerceProdutos.Services
{
    public class QuickSorter : ISorter
    {
        public void QuickSortPorNome(List<Produto> a) =>
            QuickSort(a, 0, a.Count - 1, (x, y) => string.Compare(x.Nome, y.Nome, StringComparison.OrdinalIgnoreCase));
        public void QuickSortPorPreco(List<Produto> a) =>
            QuickSort(a, 0, a.Count - 1, (x, y) => x.Preco.CompareTo(y.Preco));

        private void QuickSort(List<Produto> a, int lo, int hi, Comparison<Produto> cmp)
        {
            if (lo >= hi) return;
            int p = Particionar(a, lo, hi, cmp);
            QuickSort(a, lo, p - 1, cmp);
            QuickSort(a, p + 1, hi, cmp);
        }
        private int Particionar(List<Produto> a, int lo, int hi, Comparison<Produto> cmp)
        {
            var pivot = a[hi];
            int i = lo;
            for (int j = lo; j < hi; j++)
                if (cmp(a[j], pivot) <= 0) { (a[i], a[j]) = (a[j], a[i]); i++; }
            (a[i], a[hi]) = (a[hi], a[i]);
            return i;
        }
    }

}
