using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagementWebApi.Models;
using System.Net.Security;
using System.Text;

namespace OrderManagementWebApi.Controllers
{
    public class OrderInfoesController : Controller
    {
        HttpClientHandler httpHandler = new HttpClientHandler();
        Orderinfo _orderinfo = new Orderinfo();
        List<Orderinfo> _orderinfos = new List<Orderinfo>();

        public OrderInfoesController()
        {
            httpHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
        }
        public IActionResult Index()
        {
            return View();
        }

       

        [HttpGet]
        public async Task<List<Orderinfo>> GetAllOrderInfoes()
        {
            _orderinfos = new List<Orderinfo>();

            using (var httpClient = new HttpClient(httpHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7031/api/OrderInfoes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _orderinfos = JsonConvert.DeserializeObject<List<Orderinfo>>(apiResponse);

                }

            }
            return _orderinfos;
        }

        [HttpGet]
        public async Task<Orderinfo> GetById(int Id)
        {
            _orderinfo = new Orderinfo();

            using (var httpClient = new HttpClient(httpHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7031/api/OrderInfoes" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _orderinfos = JsonConvert.DeserializeObject<List<Orderinfo>>(apiResponse);

                }

            }
            return _orderinfo;
        }

        [HttpPost]
        public async Task<Orderinfo> AddUpdateOrderinfo(Orderinfo orderinfo)
        {
            _orderinfo = new Orderinfo();

            using (var httpClient = new HttpClient(httpHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(orderinfo), Encoding.UTF8, "application/json");
                using (var response = await httpClient.GetAsync("https://localhost:7031/api/OrderInfoes" + content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _orderinfo = JsonConvert.DeserializeObject<Orderinfo>(apiResponse);

                }

            }
            return _orderinfo;
        }

        [HttpDelete]
        public async Task<string> Delete(int Id)
        {
            string message = "";

            using (var httpClient = new HttpClient(httpHandler))
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7031/api/OrderInfoes" + Id))
                {
                    message = await response.Content.ReadAsStringAsync();
                }

            }
            return message;
        }

    }
}
