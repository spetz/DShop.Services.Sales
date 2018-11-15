namespace DShop.Services.Sales.Core.Exceptions
{
    public class EmptyProductsException : ExceptionBase
    {
        public override string Code => "empty_products";
    }
}