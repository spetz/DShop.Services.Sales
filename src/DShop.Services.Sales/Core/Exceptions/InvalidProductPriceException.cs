namespace DShop.Services.Sales.Core.Exceptions
{
    public class InvalidProductPriceException : ExceptionBase
    {
        public override string Code => "invalid_product_price";
    }
}