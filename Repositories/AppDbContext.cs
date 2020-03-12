using Microsoft.EntityFrameworkCore;
using OregonHikes3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonHikes3.Repositories
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options) : base(options){}
        
        //DbSets for each model-- Identity will take care of AppUser
        public DbSet<Hike> Hikes { get; set; }
    }
}
