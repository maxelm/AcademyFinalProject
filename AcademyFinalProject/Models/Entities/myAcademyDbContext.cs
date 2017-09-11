using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.Entities
{
    public partial class AcademyDbContext : DbContext
    {

        public AcademyDbContext(DbContextOptions<AcademyDbContext> context) : base(context)
        {

        }
    }
}
