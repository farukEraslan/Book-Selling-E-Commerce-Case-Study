using RestSharp;

namespace BookSeller.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            var url = "https://localhost:7086/api/Category/GetAll?pageNumber=1&pageSize=10";

            var client = new RestClient(url);
            
            var request = new RestRequest();

            var response = client.Get(request);

            return View(response.Content);
        }
    }
}
