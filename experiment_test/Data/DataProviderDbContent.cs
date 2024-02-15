using System.Collections.Generic;
using experiment_test.Data.Entityes;
using Microsoft.EntityFrameworkCore;

namespace experiment_test.Data
{
    public class DataProviderDbContent : DbContext
    {
        public DataProviderDbContent(DbContextOptions<DataProviderDbContent> options)
            : base(options)
        {
        }

        public DbSet<Result> Results { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Devise> Devises { get; set; }

    }
}
