using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.Mapping
{
    class ChoiceMapping : EntityTypeConfiguration<Choice>
    {
        public ChoiceMapping()
        {
            HasKey(a => a.ChoiceID);

            Property(a => a.Text)
                .HasMaxLength(100);
                //.HasColumnName("ChoiceText");

            HasRequired(a => a.Question)
                .WithMany(a => a.Choices)
                .HasForeignKey(a => a.QuestionID);
        }
    }
}
