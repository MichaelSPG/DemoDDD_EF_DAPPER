using DemoDDD.Application.Exceptions;
using DemoDDD.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoDDD.Infrastucture
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        protected readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add automatic entities configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


        // Override SaveChangesAsync to call domain events and handling concurrency
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Optimistic Concurrency
            // Blocks the record when is changing and avoid upcoming changes until is freed (saved)
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);
                await PublishDomainEventsAsync();

                return result;
            }
            // Handling Concurrency exceptions
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("Concurrency exception has been thrown", ex);
            }
        }

        private async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<Entity>()
                .Select(e => e.Entity)
                .SelectMany(entity =>
                {
                    var events = entity.GetDomainEvents();
                    entity.ClearDomainEvents();
                    return events;
                }).ToList();            

            foreach (var domainEvent in domainEvents) 
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }
}
