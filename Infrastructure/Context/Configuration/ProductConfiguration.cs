using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           
                builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);
           

           builder.Property(p=>p.ManufacturePhone)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(p => p.ManufactureEmail)
                .IsRequired();

            builder.Property(p => p.ProduceDate)
                .IsRequired();


            builder.Property(p=>p.IsAvailable)
                .IsRequired();


            builder.HasIndex(p => new {
                p.ManufactureEmail,
                p.ProduceDate
            }).IsUnique();
        }
    }
}
