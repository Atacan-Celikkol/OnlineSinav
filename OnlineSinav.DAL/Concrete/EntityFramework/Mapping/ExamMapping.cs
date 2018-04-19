using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.Mapping
{
    class ExamMapping : EntityTypeConfiguration<Exam>
    {
        public ExamMapping()
        {
            HasKey(a => a.ExamID);

            Property(a => a.Name)
                .HasMaxLength(50);

            Property(a => a.Date)
                .HasColumnType("datetime2");

            HasRequired(a => a.Lesson)
                .WithMany(a => a.Exams)
                .HasForeignKey(a => a.LessonID);

            HasMany(a => a.UserExams)
                .WithRequired(a => a.Exam)
                .HasForeignKey(a => a.ExamID);
        }
    }
}
