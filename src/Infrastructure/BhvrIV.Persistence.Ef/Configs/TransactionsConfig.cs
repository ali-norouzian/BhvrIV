using BhvrIV.Domain.Entities;
using BhvrIV.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhvrIV.Persistence.Ef.Configs;

public class TransactionsConfig : IEntityTypeConfiguration<Transactions>
{
    public void Configure(EntityTypeBuilder<Transactions> builder)
    {
        builder.ToTable(nameof(Transactions), "InventoryManagement");
        builder.Property(e => e.TransactionType).HasMaxLength(50).IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (TransactionType)Enum.Parse(typeof(TransactionType), v, true));  // true for case-insensitive parsing
        builder.Property(e => e.Date).HasDefaultValueSql("GETDATE()");

    }
}

