using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI6.Models.Models;

namespace WebAPI6.Repository.Tests
{
    public class NORTHWND_UTContextTest : IDisposable
    {
        protected IDbContextTransaction Transaction { get; }
        protected NORTHWND_UTContext DbContext { get; }

        public NORTHWND_UTContextTest()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            // configure our database
            var connection = configuration.GetConnectionString("ConnectionString");
            var options = new DbContextOptionsBuilder<NORTHWND_UTContext>()
                .UseSqlServer(connection)
                .Options;

            DbContext = new NORTHWND_UTContext(options);

            // begin the transaction
            Transaction = DbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            //Clean up
            DbContext.Dispose();

            //Rollback 
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
            }
        }
    }
}
