using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Zadatak72.Models;

namespace Zadatak72.Configuration
{
    class KolegijConfig:EntityTypeConfiguration<Kolegij>
    {


        public KolegijConfig()
        {
            ToTable("Kolegiji");
            HasKey(k => k.IDKolegij);
            Property(k => k.Naziv).IsRequired().HasMaxLength(120);
            Property(k => k.SkraceniNaziv).IsOptional().HasMaxLength(30);

        }
    }
}
