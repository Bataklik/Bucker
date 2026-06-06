using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

    public class BugContext : DbContext
    {
        public BugContext (DbContextOptions<BugContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Models.Bug> Bug { get; set; } = default!;
    }
