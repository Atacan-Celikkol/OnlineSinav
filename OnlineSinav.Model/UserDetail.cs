using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Model
{
    public class UserDetail : IEntity
    {
        public int UserID { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
    }
}
