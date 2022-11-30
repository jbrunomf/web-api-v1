using api.Models;

namespace api.Repository;

public static class ProdutoRepository
{
    public static List<Produto> Produtos { get; set; }

    public static void Add(Produto produto)
    {
        if (Produtos == null)
        {
            Produtos = new List<Produto>();
        }
        Produtos.Add(produto);
    }

    public static List<Produto> ListarProdutos()
    {
        return Produtos;
    }

    public static Produto GetByCodigo(string codigo)
    {
        return Produtos.FirstOrDefault(p => p.Code == codigo);
    }
    
}