using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(i => i.Id);
            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();
           
        }
    }
}
