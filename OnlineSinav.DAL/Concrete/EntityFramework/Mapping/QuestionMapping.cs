using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.Mapping
{
    class QuestionMapping : EntityTypeConfiguration<Question>
    {
        public QuestionMapping()
        {
            HasKey(a => a.QuestionID);

            Property(a => a.Text)
                .HasMaxLength(500);

            Property(a => a.Image)
                .HasMaxLength(500)
                .IsOptional();

            HasRequired(a => a.Exam)
                .WithMany(a => a.Questions)
                .HasForeignKey(a => a.ExamID);
        }
    }
}
