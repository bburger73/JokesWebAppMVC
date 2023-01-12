using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JokesWebAppMVC.Models;

namespace JokesWebAppMVC.Data
{
    public class JokesWebAppMVCContext : DbContext
    {
        public JokesWebAppMVCContext (DbContextOptions<JokesWebAppMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Joke> Joke { get; set; } = default!;
    }
}
