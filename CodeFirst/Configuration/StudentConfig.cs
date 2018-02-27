using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Zadatak72.Models;

namespace Zadatak72.Configuration
{
    class StudentConfig:EntityTypeConfiguration<Student>
    {

        public StudentConfig()
        {
            ToTable("Studenti");
            HasKey(s => s.IDStudent);
            Property(s => s.Ime).IsRequired().HasMaxLength(30);
            Property(s => s.Prezime).IsRequired().HasMaxLength(30);
        }

    }
}
