using BookSeller.Core.Enums;
using BookSeller.Core.ResultSets.Concrete;
using BookSeller.Entity.DTO.Login;
using BookSeller.Entity.DTO.User;
using BookSeller.WebUI.HttpHelpers.Abstract;
using BookSeller.WebUI.Models.Product;
using Newtonsoft.Json;
using RestSharp;
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
            var loginDTO = new LoginDTO
            {
                Email = "admin@bookseller.com",
                Password = "3R4sl4n_"
            };

            var result = await SignIn(loginDTO);
            return View(result.Data);
        }

        private async Task<DataResult<IEnumerable<string>>> SignIn(LoginDTO loginDto)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7086/api/");

            var jsonData = JsonConvert.SerializeObject(loginDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Login/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var headers = response.Headers;

                if (headers.Contains("Set-Cookie"))
                {
                    var cookie = headers.GetValues("Set-Cookie");
                    return new SuccessDataResult<IEnumerable<string>>(cookie, Messages.FoundSuccess);
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
