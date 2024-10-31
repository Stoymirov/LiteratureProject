using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Infrastructure.Data.SeedDb;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiteratureProject.Infrastructure.Data.SeedDb
{
    internal class TeacherLiteratureWorkConfiguration : IEntityTypeConfiguration<TeacherLiteratureWork>
    {
        public void Configure(EntityTypeBuilder<TeacherLiteratureWork> builder)
        {
            var data = new SeedData();
            builder.HasData(new TeacherLiteratureWork[] { data.TabachkaBalkanskiSindrom});
        }
    }
}
