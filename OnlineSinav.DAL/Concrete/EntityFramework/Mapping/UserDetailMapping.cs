using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.Mapping
{
    class UserDetailMapping : EntityTypeConfiguration<UserDetail>
    {
        public UserDetailMapping()
        {
            HasKey(a => a.UserID);
            Property(a => a.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(a => a.BirthDate)
                .HasColumnType("datetime2");
        }
    }
}
