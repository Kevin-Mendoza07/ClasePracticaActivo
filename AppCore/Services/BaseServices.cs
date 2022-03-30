using AppCore.IServices;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public abstract class BaseServices<T>: IServices<T>
    {
        private IModel<T> Model;
        protected BaseServices(IModel<T> model)
        {
            this.Model = model;
        }

        public void Add(T t)
        {
             Model.Add(t);
        }

        public void Delete(int id)
        {
            Model.Delete(id);
        }

        public void Delete(int id, List<int> listaIds)
        {
            Model.Delete(id, listaIds);
        }

        public List<T> Read()
        {
            return Model.Read();
        }

        public void Update(T t, int id)
        {
            Model.Update(t, id);
        }
    }
}
