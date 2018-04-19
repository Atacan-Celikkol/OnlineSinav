using OnlineSinav.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace OnlineSinav.Model
{
    public class UserExam : IEntity
    {
        public int UserID { get; set; }
        public int ExamID { get; set; }
        [Range(0, 100)]
        public int Score { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
