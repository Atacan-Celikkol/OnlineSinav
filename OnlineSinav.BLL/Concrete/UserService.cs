using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    public class UserService : IUserService
    {
        EFUserDAL _userDAL;

        public UserService()
        {
            _userDAL = new EFUserDAL();
        }

        public void Add(Model.User entity)
        {
            _userDAL.Add(entity);
        }

        public void Update(Model.User entity)
        {
            _userDAL.Update(entity);
        }

        public void Delete(Model.User entity)
        {
            entity.IsActive = false;
            _userDAL.Update(entity);
        }

        public Model.User GetByID(int id)
        {
            return _userDAL.Get(a => a.UserID == id);
        }

        public ICollection<Model.User> GetList()
        {
            return _userDAL.GetAll();
        }

        public Model.User GetByActivationCode(Guid code)
        {
            return _userDAL.Get(a => a.ActivationCode == code);
        }

        public Model.User GetByMailAndPassword(string mail, string password)
        {
            return _userDAL.Get(a => a.EMail == mail && a.Password == password);
        }
    }
}
