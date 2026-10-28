using System;

namespace TechStoreMVC.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }  
    public string Descricao { get; set; } 
    public bool Ativa { get; set; }

    public Categoria()
    {
    }

    public Categoria(int id, string nome, string descricao, bool ativa)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Ativa = ativa;
    }
}