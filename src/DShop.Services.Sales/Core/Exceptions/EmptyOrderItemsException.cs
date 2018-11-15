namespace DShop.Services.Sales.Core.Exceptions
{
    public class EmptyOrderItemsException : ExceptionBase
    {
        public override string Code => "empty_order_items";
    }
}