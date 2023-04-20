﻿using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.Entites;
using SocialNetwork.UI.Models;
using SocialNetwork.UI.Services.Interfaces;
using System.Diagnostics;

namespace SocialNetwork.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiService;

        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _apiService.GetAsync<List<Post>>("api/Posts");

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}