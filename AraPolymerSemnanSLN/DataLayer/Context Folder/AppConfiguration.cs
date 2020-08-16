using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var ConfigBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            ConfigBuilder.AddJsonFile(path, false);
            var root = ConfigBuilder.Build();
            var appsetting = root.GetSection("ConnectionString:DefaultConnection");
            SqlConnectionString = appsetting.Value;
        }
        public string SqlConnectionString { get; set; }
    }
}
