using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxadoCarrier.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Dispose();

        T GetById(int id);

        IEnumerable<T> GetAll();
    }
}
