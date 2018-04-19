using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    public class UserRoleService : IUserRoleService
    {
        EFUserRoleDAL _userRoleDAL;

        public UserRoleService()
        {
            _userRoleDAL = new EFUserRoleDAL();
        }

        public void Add(Model.UserRole entity)
        {
            _userRoleDAL.Add(entity);
        }

        public void Update(Model.UserRole entity)
        {
            _userRoleDAL.Update(entity);
        }

        public void Delete(Model.UserRole entity)
        {
            entity.IsActive = false;
            _userRoleDAL.Update(entity);
        }

        public Model.UserRole GetByID(int id)
        {
            return _userRoleDAL.Get(a => a.UserRoleID == id);
        }

        public ICollection<Model.UserRole> GetList()
        {
            return _userRoleDAL.GetAll();
        }

        public Model.UserRole GetByRoleName(string role)
        {
            return _userRoleDAL.Get(a => a.Role == role);
        }
    }
}
