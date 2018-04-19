using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    public class ExamService : IExamService
    {
        EFExamDAL _examDAL;

        public ExamService()
        {
            _examDAL = new EFExamDAL();
        }

        public void Add(Model.Exam entity)
        {
            _examDAL.Add(entity);
        }

        public void Update(Model.Exam entity)
        {
            _examDAL.Update(entity);
        }

        public void Delete(Model.Exam entity)
        {
            entity.IsActive = false;
            _examDAL.Update(entity);
        }

        public Model.Exam GetByID(int id)
        {
            return _examDAL.Get(a => a.ExamID == id);
        }

        public ICollection<Model.Exam> GetList()
        {
            return _examDAL.GetAll();
        }
    }
}
