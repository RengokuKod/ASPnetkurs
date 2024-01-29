using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp2.Models;

namespace ASP_net_kurs.Data
{
    public class ASP_net_kursContext : DbContext
    {
        public ASP_net_kursContext (DbContextOptions<ASP_net_kursContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp2.Models.Posetitel> Posetitel { get; set; } = default!;
        public DbSet<BlazorApp2.Models.Rabotnik> Rabotnik { get; set; } = default!;
    }
}
