using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWithUOW.Core.Interfaces;

public interface IBaseRepository<T> where T : class
{

    Task< IEnumerable<T>> GetAllAsync(string[] includes = null); 

    Task<T> Find(Expression< Func<T, bool>> predicate, string[] includes = null);
    Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate, string[] includes = null);

    Task Add(T item);
    
    Task Update(T item);
    Task Delete(int Id);

}
