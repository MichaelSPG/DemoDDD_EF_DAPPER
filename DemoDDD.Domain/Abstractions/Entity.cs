using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        protected Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }

        public IReadOnlyList<IDomainEvent> DomainEvents() 
        {
            return _domainEvents.ToList();
        }
        public void ClearEvents() => _domainEvents.Clear();
        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
