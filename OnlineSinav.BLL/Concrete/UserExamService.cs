using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    public class UserExamService : IUserExamService
    {
        EFUserExamDAL _userExamDAL;

        public UserExamService()
        {
            _userExamDAL = new EFUserExamDAL();
        }

        public void Add(Model.UserExam entity)
        {
            _userExamDAL.Add(entity);
        }

        public void Update(Model.UserExam entity)
        {
            _userExamDAL.Update(entity);
        }

        public void Delete(Model.UserExam entity)
        {
            entity.IsActive = false;
            _userExamDAL.Update(entity);
        }

        public Model.UserExam GetByID(int id)
        {
            return _userExamDAL.Get(a => a.UserID == id);
        }

        public ICollection<Model.UserExam> GetList()
        {
            return _userExamDAL.GetAll();
        }
    }
}
