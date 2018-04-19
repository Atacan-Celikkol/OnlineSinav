using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Model
{
    public class Choice : IEntity
    {
        public int ChoiceID { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual Question Question { get; set; }
    }
}
