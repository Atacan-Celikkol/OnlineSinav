using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    public class LessonService : ILessonService
    {
        EFLessonDAL _lessonDAL;

        public LessonService()
        {
            _lessonDAL = new EFLessonDAL();
        }

        public void Add(Model.Lesson entity)
        {
            _lessonDAL.Add(entity);
        }

        public void Update(Model.Lesson entity)
        {
            _lessonDAL.Update(entity);
        }

        public void Delete(Model.Lesson entity)
        {
            entity.IsActive = false;
            _lessonDAL.Update(entity);
        }

        public Model.Lesson GetByID(int id)
        {
            return _lessonDAL.Get(a => a.LessonID == id);
        }

        public ICollection<Model.Lesson> GetList()
        {
            return _lessonDAL.GetAll();
        }
    }
}
