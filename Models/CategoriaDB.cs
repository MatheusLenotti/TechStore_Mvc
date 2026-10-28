namespace TechStoreMVC.Models;

public class CategoriasDB
{
    private static readonly List<Categoria> Categorias =
    [
            new Categoria(1, "Informática", "Computadores e componentes", true),
            new Categoria(2, "Periféricos", "Mouse, teclado e acessórios", true),
            new Categoria(3, "Áudio", "Fones, caixas e microfones", true),
            new Categoria(4, "Monitores", "Telas e monitores", true),
            new Categoria(5, "Descontinuados", "Categorias fora de uso", false),
           
    ];

    public List<Categoria> Listar()
    {
        return Categorias;
    }

    public Categoria? BuscarPorId(int id)
    {
        return Categorias.FirstOrDefault(categoria => categoria.Id == id);
    }

    public void Adicionar(Categoria categoria)
    {
        categoria.Id = Categorias.Count == 0
            ? 1
            : Categorias.Max(categoriaExistente => categoriaExistente.Id) + 1;
        Categorias.Add(categoria);
    }

    public bool Atualizar(Categoria categoriaAtualizada)
    {
        Categoria? categoriaExistente = BuscarPorId(categoriaAtualizada.Id);
        if (categoriaExistente is null)
            return false;

        categoriaExistente.Nome = categoriaAtualizada.Nome;
        categoriaExistente.Descricao = categoriaAtualizada.Descricao;
        categoriaExistente.Ativa = categoriaAtualizada.Ativa;
        return true;
    }

    public bool Excluir(int id)
    {
        Categoria? categoria = BuscarPorId(id);
        if (categoria is null)
            return false;

        Categorias.Remove(categoria);
        return true;
    }
}