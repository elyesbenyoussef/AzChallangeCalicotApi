using AzChallangeCalicotApi.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace AzChallangeCalicotApi.Data
{
    public partial class CalicotContextExtension : CalicotContext
    {
        public CalicotContextExtension(DbContextOptions<CalicotContextExtension> options)
            : base(ChangeOptionsType<CalicotContext>(options))
        {
            var conn = (SqlConnection)Database.GetDbConnection();
        }

        public CalicotContextExtension(DbContextOptions<CalicotContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            var sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension);

            if (sqlExt == null)
                throw (new Exception("Failed to retrieve SQL connection string for base Context"));

            return new DbContextOptionsBuilder<T>()
                .UseSqlServer(((SqlServerOptionsExtension)sqlExt).ConnectionString)
                .Options;
        }
    }
}
