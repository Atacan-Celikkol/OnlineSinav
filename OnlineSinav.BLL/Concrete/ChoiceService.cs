using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    class ChoiceService : IChoiceService
    {
        EFChoiceDAL _choiceDAL;

        public ChoiceService()
        {
            _choiceDAL = new EFChoiceDAL();
        }

        public void Add(Model.Choice entity)
        {
            _choiceDAL.Add(entity);
        }

        public void Update(Model.Choice entity)
        {
            _choiceDAL.Update(entity);
        }

        public void Delete(Model.Choice entity)
        {
            entity.IsActive = false;
            _choiceDAL.Update(entity);
        }

        public Model.Choice GetByID(int id)
        {
            return _choiceDAL.Get(a => a.ChoiceID == id);
        }

        public ICollection<Model.Choice> GetList()
        {
            return _choiceDAL.GetAll();
        }
    }
}
