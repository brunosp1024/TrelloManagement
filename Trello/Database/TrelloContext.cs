using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trello.Models;

namespace Trello.Database
{
    public class TrelloContext : DbContext
    {

        public TrelloContext(DbContextOptions<TrelloContext> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<TaskCard> Cards { get; set; }

    }
}
