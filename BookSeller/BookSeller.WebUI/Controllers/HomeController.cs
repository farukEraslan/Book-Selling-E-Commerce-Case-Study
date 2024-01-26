using BookSeller.Core.Enums;
using BookSeller.Core.ResultSets.Concrete;
using BookSeller.Entity.DTO.Login;
using BookSeller.Entity.DTO.User;
using BookSeller.WebUI.HttpHelpers.Abstract;
using BookSeller.WebUI.Models.Product;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BookSeller.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpMethods _httpMethods;

        public HomeController(ILogger<HomeController> logger, IHttpMethods httpMethods)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpMethods = httpMethods;
        }

        public async Task<IActionResult> Index()
        {
            //var result = await _httpMethods.HttpGetAll<ProductViewModel>();
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        private async Task<DataResult<IEnumerable<string>>> SignIn(LoginDTO loginDto)
        {
            CookieContainer cookieContainer = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookieContainer;

            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:7086/api/");

            var jsonData = JsonConvert.SerializeObject(loginDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Login/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var headers = response.Headers;

                if (headers.Contains("Set-Cookie"))
                {
                    // Set-Cookie baþlýðýnýn deðeri alýnýr
                    var cookieValues = headers.GetValues("Set-Cookie");

                    // Alýnan çerez deðeri CookieContainer'a eklenir
                    foreach (var cookieValue in cookieValues)
                    {
                        cookieContainer.SetCookies(client.BaseAddress, cookieValue);
                    }

                    return new SuccessDataResult<IEnumerable<string>>(cookieValues, Messages.FoundSuccess);
                }
                else
                {
                    return new ErrorDataResult<IEnumerable<string>>(Messages.NotFound);
                }

                //string apiResponse = await response.Content.ReadAsStringAsync();
                //var result = JsonConvert.DeserializeObject<UserDTO>(apiResponse);
                //return new SuccessDataResult<UserDTO>(result, "Giriþ Yapýldý.");
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                return new ErrorDataResult<IEnumerable<string>>(errorMessage);
            }
        }


        public IActionResult Logout()
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
