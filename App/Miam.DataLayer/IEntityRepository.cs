using System.Linq;
using Miam.Domain.Entities;

namespace Miam.DataLayer
{
    public  interface IEntityRepository<T> where T : Entity
    {

        IQueryable<T> GetAll(); 
        T GetById(int id);
        void DeleteById(int id);


        void Delete(T entity);
        void Add(T entity);
        void Update(T entity);
    }
}