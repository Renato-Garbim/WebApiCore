using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPIAngular.Models
{
    public class HeroAngular : IdentityDbContext
    {
        public HeroAngular(DbContextOptions<HeroAngular> options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Hero> Hero { get; set; }


    }
}
