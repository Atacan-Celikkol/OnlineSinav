using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Model
{
    public class UserRole : IEntity
    {
        public int UserRoleID { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual ICollection<User> Users { get; set; }
    }
}
