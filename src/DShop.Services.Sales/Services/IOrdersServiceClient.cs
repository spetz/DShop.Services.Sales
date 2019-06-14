using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestEase;

namespace DShop.Services.Sales.Services
{
    public interface IOrdersServiceClient
    {
        [Get("orders/{id}")]
        Task<object> GetAsync([Path] Guid id);
    }

//    public class OrdersServiceClient : IOrdersServiceClient
//    {
//        private readonly HttpClient _client;
//
//        public OrdersServiceClient(HttpClient client)
//        {
//            _client = client;
//        }
//
//        public async Task<object> GetAsync(Guid id)
//        {
//            var response = await _client.GetAsync($"http://localhost:9999/products-service/orders/{id}");
//            if (!response.IsSuccessStatusCode)
//            {
//                return null;
//            }
//
//            var content = await response.Content.ReadAsStringAsync();
//
//            return JsonConvert.DeserializeObject<object>(content);
//        }
//    }
}