using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoPortofolio.Models;

    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Gallery> Galleries { get; set; } = default!;
        public DbSet<WeddingSolicitation> WeddingSolicitations { get; set; } = default!;
        public DbSet<Picture> Pictures { get; set; } = default!;
        public DbSet<Test> Tests { get; set; } = default!;


    }
