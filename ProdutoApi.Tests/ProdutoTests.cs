namespace ProdutoApi.Tests;

public class ProdutoTests
{
    [Fact]
    public void DeveCriarProdutoComDadosCorretos()
    {
        var produto = new Produto
        {
            Id = 1,
            Nome = "Teclado",
            Preco = 150.00m,
            Estoque = 10
        };

        Assert.Equal(1, produto.Id);
        Assert.Equal("Teclado", produto.Nome);
        Assert.Equal(150.00m, produto.Preco);
        Assert.Equal(10, produto.Estoque);
    }
}