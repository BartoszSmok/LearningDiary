using LearingDiary.WEB.Models;
using LearningDiary.COMMON.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LearingDiary.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient("LearningDiaryApi");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/Entries");
            var content = await response.Content.ReadAsStringAsync();
            var entriesList = JsonConvert.DeserializeObject<IEnumerable<EntryDto>>(content);
            return View();
            //return View(entriesList);
            //using (HttpClient client = new HttpClient())
            //{
            //    HttpResponseMessage response =
            //        await client.GetAsync($"http://learningdiary.api/api/Entries");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var entries =
            //            JsonConvert.DeserializeObject<IEnumerable<EntryDto>>(await response.Content.ReadAsStringAsync());
            //        return View(entries);
            //    }
            //    else
            //    {
            //        return View();
            //    }
            //}
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
