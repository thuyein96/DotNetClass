using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace CloudHRMS.Repositories.Common
{
    public interface IBaseRepository<T> where T : class
    {
        //CRUD Process
        void Create(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<T,bool>> expression);
        void Update(T entity);
        void Delete(T entity);
    }
}
