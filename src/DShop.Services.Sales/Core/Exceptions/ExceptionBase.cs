using System;

namespace DShop.Services.Sales.Core.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public abstract string Code { get; }
    }
}