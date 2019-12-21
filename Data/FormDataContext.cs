using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD_Decisions_Case_Study.Models;

namespace HD_Decisions_Case_Study.Data
{
    public class HD_Decisions_Case_StudyContext : DbContext
    {
        public HD_Decisions_Case_StudyContext(DbContextOptions<HD_Decisions_Case_StudyContext> options)
            : base(options)
        {

        }

        public DbSet<FormData> FormData { get; set; }
    }
}