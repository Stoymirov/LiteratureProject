using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Infrastructure.Data.SeedDb;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


using LiteratureProject.Data.Models;
namespace LiteratureProject.Infrastructure.Data.SeedDb
{
    internal class LiteratureWorkConfiguration : IEntityTypeConfiguration<LiteratureWork>
    {
        public void Configure(EntityTypeBuilder<LiteratureWork> builder)
        {
            var data = new SeedData();
            builder.HasData(new LiteratureWork[] { data.BalkanskiSindrom, data.JelezniqtSvetilnik});
        }
    }
}
