using BhvrIV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhvrIV.Persistence.Ef.Configs;

public class WarehousesConfig : IEntityTypeConfiguration<Warehouses>
{
    public void Configure(EntityTypeBuilder<Warehouses> builder)
    {
        builder.ToTable(nameof(Warehouses), "InventoryManagement");
        builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
        builder.Property(e => e.Location).HasMaxLength(255).IsRequired();
    }
}

