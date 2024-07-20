using DemoDDD.Domain.Abstractions;
using DemoDDD.Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Infrastucture
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
    }
}
