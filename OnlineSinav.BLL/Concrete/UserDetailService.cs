using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    public class UserDetailService : IUserDetailService
    {
        EFUserDetailDAL _userDetailDAL;

        public UserDetailService()
        {
            _userDetailDAL = new EFUserDetailDAL();
        }

        public void Add(Model.UserDetail entity)
        {
            _userDetailDAL.Add(entity);
        }

        public void Update(Model.UserDetail entity)
        {
            _userDetailDAL.Update(entity);
        }

        public void Delete(Model.UserDetail entity)
        {
            entity.IsActive = false;
            _userDetailDAL.Update(entity);
        }

        public Model.UserDetail GetByID(int id)
        {
            return _userDetailDAL.Get(a => a.UserID == id);
        }

        public ICollection<Model.UserDetail> GetList()
        {
            return _userDetailDAL.GetAll();
        }
    }
}
