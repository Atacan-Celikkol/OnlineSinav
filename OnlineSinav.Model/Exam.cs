using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Model
{
    public class Exam : IEntity
    {
        public int ExamID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public uint Duration { get; set; }
        public bool IsActive { get; set; }
        public int LessonID { get; set; }
        public int CategoryID { get; set; }

        // Navigation Properties
        public virtual Category Category { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
