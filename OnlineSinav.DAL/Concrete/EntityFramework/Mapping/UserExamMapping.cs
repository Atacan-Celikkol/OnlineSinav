using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.Mapping
{
    class UserExamMapping : EntityTypeConfiguration<UserExam>
    {
        public UserExamMapping()
        {
            HasKey(a => new { a.ExamID, a.UserID });
        }
    }
}
