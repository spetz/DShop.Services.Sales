using System;
using System.Collections.Generic;

namespace DShop.Services.Sales.Core.Domain
{
    public class Order : IEquatable<Order>
    {
        private ISet<OrderItem> _items = new HashSet<OrderItem>();
        public AggregateId Id { get; private set; }
        public AggregateId CustomerId { get; private set; }
        public string State { get; private set; }
        public ICollection<OrderItem> Items
        {
            get => _items;
            private set => _items = new HashSet<OrderItem>(value);
        }

        private Order()
        {
        }

        public Order(AggregateId id, AggregateId customerId, IEnumerable<OrderItem> items)
        {
            Id = id;
            CustomerId = customerId;
            State = States.New;
            _items = new HashSet<OrderItem>(items);
        }

        public void Complete()
        {
            State = States.Completed;
        }

        public void Cancel()
        {
            State = States.Canceled;
        }

        public static class States
        {
            public static string New => "new";
            public static string Completed => "completed";
            public static string Canceled => "canceled";
        }

        public bool Equals(Order other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Order) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}