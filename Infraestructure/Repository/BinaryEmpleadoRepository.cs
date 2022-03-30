using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BinaryEmpleadoRepository : IEmpleadoModel
    {
        private RAFContext context;
        private const int SIZE = 568;
        public BinaryEmpleadoRepository()
        {
            context = new RAFContext("empleado", SIZE);
        }
        public void Add(Empleado t)
        {
            try
            {
                context.Create<Empleado>(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id, List<int> listaIds)
        {
            try
            {
                context.Delete<Empleado>(id, listaIds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Empleado GetById(int id)
        {
            try
            {
                return context.Get<Empleado>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Empleado> Read()
        {
            try
            {
                return context.GetAll<Empleado>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Empleado t, int id)
        {
            try
            {
                context.Update(t, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
