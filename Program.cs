using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/produto", (Produto produto) =>
{
    ProdutoRepository.Add(produto);
    return Results.Created($"/products/{produto.Code}", produto.Code);
});
app.MapGet("/produto", () => ProdutoRepository.ListarProdutos());
app.MapGet("/produto/{codigo}", (string? codigo) =>
{
    if (ProdutoRepository.Produtos == null)
    {
        ProdutoRepository.Produtos = new List<Produto>();
    }
    if (codigo != null)
    {
        var produto = ProdutoRepository.GetByCodigo(codigo);
        
        if (produto != null)
        {
            return Results.Ok(produto);
        }
    }
    return Results.NotFound("Produto não encontrado.");
});

app.MapGet("/configuration/database", (IConfiguration configuration ) =>
{
    return Results.Ok(configuration["Database"]);
});
app.Run();