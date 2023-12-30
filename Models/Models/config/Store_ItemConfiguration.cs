using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Store_ItemConfiguration : IEntityTypeConfiguration<Store_Item>
    {
        public void Configure(EntityTypeBuilder<Store_Item> builder)
        {
            builder.ToTable("Store_Item");

            builder.HasKey(o => o.Id);
            builder
                .Property(o=>o.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasOne(o => o.Item)
                .WithMany(o => o.Store_Items)
                .HasForeignKey(o => o.Item_Id);
            builder
                .HasOne(o => o.Store)
                .WithMany(o => o.Store_Items)
                .HasForeignKey(o => o.Store_Id);
        }
    }
}
