using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store");

            builder.HasKey(s => s.Id);
            builder
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder 
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
