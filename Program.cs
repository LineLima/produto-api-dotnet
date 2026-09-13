var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var produtos = new List<Produto>
{
    new Produto
    {
        Id = 1,
        Nome = "Notebook",
        Preco = 3500.00m,
        Estoque = 10
    },
    new Produto
    {
        Id = 2,
        Nome = "Mouse",
        Preco = 80.00m,
        Estoque = 25
    }
};

app.MapGet("/", () =>
{
    return "API de Produtos funcionando!";
});

app.MapGet("/produtos", () =>
{
    return Results.Ok(produtos);
});

app.MapGet("/produtos/{id}", (int id) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == id);

    if (produto == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(produto);
});

app.MapPost("/produtos", (Produto produto) =>
{
    produto.Id = produtos.Count + 1;
    produtos.Add(produto);

    return Results.Created($"/produtos/{produto.Id}", produto);
});

app.MapPut("/produtos/{id}", (int id, Produto produtoAtualizado) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == id);

    if (produto == null)
    {
        return Results.NotFound();
    }

    produto.Nome = produtoAtualizado.Nome;
    produto.Preco = produtoAtualizado.Preco;
    produto.Estoque = produtoAtualizado.Estoque;

    return Results.Ok(produto);
});

app.MapDelete("/produtos/{id}", (int id) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == id);

    if (produto == null)
    {
        return Results.NotFound();
    }

    produtos.Remove(produto);

    return Results.NoContent();
});

app.Run();

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}