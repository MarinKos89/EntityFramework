using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak72.Configuration;

namespace Zadatak72.Models
{
    class Context : DbContext
    {
        public DbSet<Student> Studenti { get; set; }

        public DbSet<Kolegij> Kolegiji { get; set; }



        public Context()
            :base("name=cs")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfig());
            modelBuilder.Configurations.Add(new KolegijConfig());
        }
    }
}
