using OnlineSinav.Core.DataAccess.EntityFramework;
using OnlineSinav.DAL.Abstract;
using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework.DAL
{
    public class EFUserExamDAL : EFEntityRepositoryBase<UserExam, OnlineSinavDbContext>, IUserExamDAL
    {
    }
}
