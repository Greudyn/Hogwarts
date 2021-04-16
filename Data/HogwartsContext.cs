using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hogwarts.Models;

namespace Hogwarts.Data
{
    public class HogwartsContext : DbContext
    {
        public HogwartsContext (DbContextOptions<HogwartsContext> options)
            : base(options)
        {
        }

        public DbSet<Hogwarts.Models.StudentModel> StudentModel { get; set; }
    }
}
