﻿using LanchesMAC.Repositories;
using LanchesMAC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMAC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };

            return View(homeViewModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
