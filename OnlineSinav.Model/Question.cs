using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Model
{
    public class Question : IEntity
    {
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int ExamID { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
