using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prooram.Domain.Entities;


namespace prooram.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : AuditableEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            
            builder.Property(map => map.CategoryName).HasMaxLength(100).IsRequired(true).HasColumnName("CategoryName");


            base.Configure(builder);
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