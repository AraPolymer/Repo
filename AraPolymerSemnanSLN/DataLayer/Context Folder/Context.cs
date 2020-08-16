
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;

namespace DataLayer
{
    public class Context: DbContext
    { 
        public class OptionBuild
        {
            public OptionBuild()
            {
                settings = new AppConfiguration();
                opsbuilder = new DbContextOptionsBuilder<Context>();
                opsbuilder.UseSqlServer(settings.SqlConnectionString);
                dboptions = opsbuilder.Options;
            }
            public DbContextOptionsBuilder<Context> opsbuilder { get; set; }
            public DbContextOptions<Context> dboptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static OptionBuild ops = new OptionBuild();

        public Context(DbContextOptions<Context> options) : base(options)
        { }
          public DbSet<Product> Products { get; set; }
          public DbSet<Producttype> Producttypes { get; set; }

          public DbSet<PagesContent> Pagescontents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producttype>().HasData(
                new Producttype {Serial= 1, Code = "1", Name = "نوع محصول یک" },
                new Producttype {Serial= 2, Code = "2", Name = "نوع محصول دو" }
            );

            modelBuilder.Entity<PagesContent>().HasData(
                new PagesContent {Serial=1, PageName = "ContactUs", PageCaption = "تماس با ما" },
                new PagesContent {Serial=2, PageName = "AboutUs", PageCaption = "درباره ما" }
            );
        }

    }

}
