namespace TechStoreMVC.Models;

public class ProdutosDB
{
    // passo 1 - criar/trazer os dados de produtos do controller
    //método que vai listar os objetos de um produto
    //e armazena-los na variável produtos
    private static readonly List<Produto> produtos = new()
    {
                new Produto(1, "Mouse gamer", 129.9m, 10),
                new Produto(2, "Teclado Mecânico", 249.9m, 5),
                new Produto(3, "Monitor 24 Polegadas", 899.9m, 8),
                new Produto(4, "Headset Gamer", 179.9m, 15)
    };


    //passo 02 - criar o método CRUD e remover todas as regra de negócio do controller
    //responsabilidade do listar: devolver/mostrar os produtos. igual ao index
    //controller
    public List<Produto> Listar()
    {
        return produtos;
    }

    public Produto? buscarPorId(int id)
    {
        return produtos.FirstOrDefault(produto => produto.Id == id);
    }
    
    public void Adicionar(Produto produto)
    {
        produto.Id = produtos.Count + 1;
        produtos.Add(produto);
    }

    public bool Atualizar(Produto produtoAtualizado)
    {
        Produto? produtoExistente = 
            buscarPorId(produtoAtualizado.Id);

                if (produtoExistente is null)
            return false;
            produtoExistente.Nome = produtoAtualizado.Nome;
            produtoExistente.Preco = produtoAtualizado.Preco;
            produtoExistente.Estoque = produtoAtualizado.Estoque;
            return true;
    }

    public bool Excluir(int id)
    {
        Produto? produtoExistente = buscarPorId(id);
        if (produtoExistente is null)
            return false;
        produtos.Remove(produtoExistente);
        return true;
    }
    
}