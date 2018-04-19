using OnlineSinav.Core.DataAccess;
using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Abstract
{
    interface IUserExamDAL : IEntityRepository<UserExam>
    {
    }
}
