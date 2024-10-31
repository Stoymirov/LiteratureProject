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
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			var data = new SeedData();
			builder.HasData(new Author[] { data.IvanVazov, data.AlekoKonstantinov, data.StanislavStratiev });
		}
	}
}
