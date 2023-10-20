using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp_TestApp_W3_InlvrOpdr.Models;

namespace WebApp_TestApp_W3_InlvrOpdr.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Joke()
        {
            var joke = await GetRandomJokeAsync();
            return View(joke);
        }

        private async Task<Joke> GetRandomJokeAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://api.chucknorris.io/jokes/random");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Joke>(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Functie(string parameter)
        {
            ViewData["Parameter"] = parameter;
            return View();
        }

        public IActionResult Optellen(int num1, int num2)
        {
            int result = num1 + num2;
            ViewData["Result"] = result;
            return View("Functie");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
