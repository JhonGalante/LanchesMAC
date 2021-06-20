using LanchesMAC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMAC.Components
{
    public class CategoriaCarrinhoCompra : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaCarrinhoCompra(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy( c => c.CategoriaNome );

            return View(categorias);
        }
    }
}
