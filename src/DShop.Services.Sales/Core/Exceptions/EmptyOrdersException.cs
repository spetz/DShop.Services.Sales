namespace DShop.Services.Sales.Core.Exceptions
{
    public class EmptyOrdersException : ExceptionBase
    {
        public override string Code => "empty_orders";
    }
}