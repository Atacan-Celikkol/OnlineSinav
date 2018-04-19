using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Model
{
    public class Category : IEntity
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
