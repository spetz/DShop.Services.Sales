namespace DShop.Services.Sales.Infrastructure.EF
{
    public interface IEfJsonSerializer
    {
        string Serialize(object obj);
        T Deserialize<T>(string value);
    }
}