using OnlineSinav.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Core.DataAccess
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        // Get metotu bize tek bir kayıt dönecek. Bu tek kayıt kimi zaman id ile bulunacak kimi zaman email ve şifreden. Hatta ilerde belki başka bir alandan. Hepsini karşılayabilmesi için LINQ sorgusu yazabileceğimiz bir tipte parametre almaktadır. Bu metodu implemente ettiğimiz class'larda içerisine lambda sorgusu yazılacak. 
        T Get(Expression<Func<T, bool>> filter);
        // Eğer listeleme yaparken bu filter gönderilmemişse hepsini listele, gönderilmişse de filtreleyip çıkanları listele.
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
