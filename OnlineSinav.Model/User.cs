using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Model
{
    public class User : IEntity
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int UserRoleID { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }

        // Navigation Properties
        public virtual UserRole UserRole { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
