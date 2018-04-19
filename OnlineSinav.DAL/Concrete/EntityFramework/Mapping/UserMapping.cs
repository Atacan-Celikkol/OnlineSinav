using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.Mapping
{
    class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(a => a.UserID);

            HasRequired(a => a.UserRole)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.UserRoleID);

            HasOptional(a => a.UserDetail)
                .WithRequired(a => a.User);

            HasMany(a => a.UserExams)
                .WithRequired(a => a.User)
                .HasForeignKey(a => a.UserID);
        }
    }
}
