1-Categoria representa os dados de uma categoria: código, nome, descrição e situação ativa.


2-CategoriasController atende à rota /categorias, cria a lista de categorias e a envia à View.


3-A View usa @model List<Categoria> porque recebe vários objetos Categoria em uma lista tipada.


4-O foreach percorre essa lista e gera uma linha da tabela para cada categoria.


5-Se a pasta fosse Views/Categoria, no singular, a busca convencional não encontraria a View em Views/Categorias/Index.cshtml, e a aplicação retornaria erro de View não encontrada.


6-Ao acessar /categorias, a requisição GET é encaminhada à action Index de CategoriasController. Ela cria a lista e chama View(categorias). O MVC localiza Index.cshtml, que percorre a lista e produz a resposta HTML.



Checklist de Categorias

- [x] **Testar a rota /categorias:** a requisição GET retorna HTTP 200 e apresenta cinco categorias.
- [x] **Responsabilidade da classe Categoria:** representar os dados de uma categoria, incluindo código, nome, descrição e situação ativa.
- [x] **Responsabilidade do CategoriasController:** atender à rota /categorias, criar a lista de categorias e enviá-la para a View.
- [x] **Por que a View utiliza uma lista em @model?** Porque recebe vários objetos Categoria em uma lista tipada.
- [x] **Para que serve o foreach?** Percorre a lista e gera uma linha da tabela para cada categoria.
- [x] **O que acontece se a pasta for Views/Categoria, no singular?** A busca convencional não encontra a View em Views/Categorias/Index.cshtml, causando um erro de View não encontrada.
- [x] **Caminho percorrido ao acessar /categorias:** a requisição GET é encaminhada ao Index de CategoriasController; a action cria a lista e chama View(categorias); o MVC localiza Views/Categorias/Index.cshtml, que renderiza a tabela HTML.
