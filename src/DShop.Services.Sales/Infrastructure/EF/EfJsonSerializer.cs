using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DShop.Services.Sales.Infrastructure.EF
{
    public class EfJsonSerializer : IEfJsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        
        public string Serialize(object obj)
            => JsonConvert.SerializeObject(obj, Settings);

        public T Deserialize<T>(string value)
            => JsonConvert.DeserializeObject<T>(value, Settings);
    }
}