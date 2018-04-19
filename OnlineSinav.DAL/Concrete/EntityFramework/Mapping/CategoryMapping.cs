using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.Mapping
{
    class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey(a => a.CategoryID);

            Property(a => a.Name)
                .HasMaxLength(20);

            HasMany(a => a.Exams)
                .WithRequired(a => a.Category)
                .HasForeignKey(a => a.CategoryID);
        }
    }
}
