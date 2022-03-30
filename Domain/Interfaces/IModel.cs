using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IModel<T>
    {
        void Add(T t);
        void Delete(int id);
        void Delete(int id, List<int> listaIds);
        void Update(T t, int id);
        List<T> Read();

    }
}
