using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prooram.Domain.Common;


namespace prooram.Infrastructure.Persistence.Configurations
{
    public class AuditableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(map => map.Created).IsRequired(true).HasColumnName("CreatedDate");
            builder.Property(map => map.CreatedBy).IsRequired(true).HasColumnName("CreatedBy").HasMaxLength(50);
            builder.Property(map => map.Modified).IsRequired(false).HasColumnName("Modified");
            builder.Property(map => map.ModifiedBy).IsRequired(false).HasColumnName("ModifiedBy").HasMaxLength(50);
        }
    }


    //public class PostConfiguration : AuditableEntityConfiguration<Post>
    //{
    //    public override void Configure(EntityTypeBuilder<Post> builder)
    //    {
    //        builder.ToTable("Posts");

    //        builder.HasKey(map => map.Id);

    //        base.Configure(builder);
    //    }
    //}

}

//AUTO MIGRATION?