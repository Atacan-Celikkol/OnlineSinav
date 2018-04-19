using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.Mapping
{
    class LessonMapping : EntityTypeConfiguration<Lesson>
    {
        public LessonMapping()
        {
            HasKey(a => a.LessonID);

            Property(a => a.Name)
                .HasMaxLength(30)
                .HasColumnType("nchar");
        }
    }
}
