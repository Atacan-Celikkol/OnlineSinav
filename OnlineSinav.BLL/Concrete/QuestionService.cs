using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    public class QuestionService : IQuestionService
    {
        EFQuestionDAL _questionDAL;

        public QuestionService()
        {
            _questionDAL = new EFQuestionDAL();
        }

        public void Add(Model.Question entity)
        {
            _questionDAL.Add(entity);
        }

        public void Update(Model.Question entity)
        {
            _questionDAL.Update(entity);
        }

        public void Delete(Model.Question entity)
        {
            entity.IsActive = false;
            _questionDAL.Update(entity);
        }

        public Model.Question GetByID(int id)
        {
            return _questionDAL.Get(a => a.QuestionID == id);
        }

        public ICollection<Model.Question> GetList()
        {
            return _questionDAL.GetAll();
        }
    }
}
