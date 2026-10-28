using Microsoft.AspNetCore.Mvc;
using TechStoreMVC.Models;

namespace TechStoreMVC.Controllers;

[Route("categorias")]
public class CategoriasController : Controller
{
    
    private readonly CategoriasDB _categoriasDB = new();

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Categoria> categorias = new()
        {
            new Categoria(1, "Informática", "Computadores e componentes", true),
            new Categoria(2, "Periféricos", "Mouse, teclado e acessórios", true),
            new Categoria(3, "Áudio", "Fones, caixas e microfones", true),
            new Categoria(4, "Monitores", "Telas e monitores", true),
            new Categoria(5, "Descontinuados", "Categorias fora de uso", false)
        };
        return View(_categoriasDB.Listar());
    }

    [HttpGet("details/{id:int}")]
    public IActionResult Details(int id)
    {
        Categoria? categoria = _categoriasDB.BuscarPorId(id);
        if (categoria is null)
            return NotFound();

        return View(categoria);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Categoria categoria)
    {
        if (!ModelState.IsValid)
            return View(categoria);

        _categoriasDB.Adicionar(categoria);
        TempData["Sucesso"] = "Categoria cadastrada com sucesso!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id:int}")]
    public IActionResult Edit(int id)
    {
        Categoria? categoria = _categoriasDB.BuscarPorId(id);
        if (categoria is null)
            return NotFound();

        return View(categoria);
    }

    [HttpPost("edit/{id:int}")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Categoria categoria)
    {
        if (id != categoria.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(categoria);

        if (!_categoriasDB.Atualizar(categoria))
            return NotFound();

        TempData["Sucesso"] = "Categoria atualizada com sucesso!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("delete/{id:int}")]
    public IActionResult Delete(int id)
    {
        Categoria? categoria = _categoriasDB.BuscarPorId(id);
        if (categoria is null)
            return NotFound();

        return View(categoria);
    }

    [HttpPost("delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
{
    if (!_categoriasDB.Excluir(id))
        return NotFound();

    TempData["Sucesso"] = "Categoria excluída com sucesso!";
    return RedirectToAction(nameof(Index));
   }
}
