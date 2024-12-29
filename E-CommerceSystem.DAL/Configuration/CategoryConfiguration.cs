using E_CommerceSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Configuration
{
    public class CategoryConfiguration     /* : IEntityTypeConfiguration<Category>*/
    {
        //{
        //    public void Configure(EntityTypeBuilder<Category> builder)
        //    {
        //        builder.HasKey(c => c.Id);

        //        builder.Property(c => c.Name)
        //            .IsRequired();

        //        builder.HasOne(c => c.Parent)
        //            .WithMany(c => c.Children)
        //            .OnDelete(DeleteBehavior.NoAction)
        //            .HasForeignKey(c => c.ParentId);

        //        builder.HasMany(x => x.Products)
        //            .WithOne(x => x.Category)
        //            .OnDelete(DeleteBehavior.NoAction)
        //            .HasForeignKey(x=>x.CategoryId);        }
        //}
    }
}
