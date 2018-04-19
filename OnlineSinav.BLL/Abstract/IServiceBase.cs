using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Abstract
{
    interface IServiceBase<T>
        where T : IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetByID(int id);
        ICollection<T> GetList();
    }
}
