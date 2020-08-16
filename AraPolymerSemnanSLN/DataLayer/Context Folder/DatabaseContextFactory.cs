using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context_Folder
{
    public class DatabaseContextFactory: IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            AppConfiguration appConfing = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<Context>();
            opsBuilder.UseSqlServer(appConfing.SqlConnectionString);
            return new Context(opsBuilder.Options);
        }
    }
}
