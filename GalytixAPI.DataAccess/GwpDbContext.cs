using GalytixAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalytixAPI.DataAccess
{
    public class GwpDbContext : DbContext 
    {
        public GwpDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Gwp> Gwps { get; set; }
    }
}
