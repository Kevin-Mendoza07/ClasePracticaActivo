using Domain.Entities;
using Domain.Interfaces;
using Domain.SubModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class JsonActivoRepository : IActivoModel
    {
        private RAFContext context;
        private const int SIZE = 1600;
        public JsonActivoRepository()
        {
            context = new RAFContext("activoSubModel", SIZE);
        }
        public void Add(Activo t)
        {
            try
            {
                t.Id = context.GetLastId() + 1;
                ActivoSubModel subModel = ActivoSubModel.Convert(t);
                context.Create<ActivoSubModel>(subModel);
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

        public void Delete(int id, List<int> listaIds)
        {
            context.Delete<ActivoSubModel>(id, listaIds);
        }

        public Activo GetById(int id)
        {
            if(id < 0)
            {
                return null;
            }
            ActivoSubModel subModel = context.Get<ActivoSubModel>(id);
            Activo activo = ActivoSubModel.Convert(subModel);
            return activo;
        }

        public List<Activo> Read()
        {
            List<ActivoSubModel> list = context.GetAll<ActivoSubModel>();
            return list.Count == 0 ? new List<Activo>() : list.Select(x => ActivoSubModel.Convert(x)).ToList();
        }

        public void Update(Activo t, int id)
        {
            if(t == null || id < 0)
            {
                throw new Exception();
            }
            ActivoSubModel subModel = ActivoSubModel.Convert(t);
            context.Update<ActivoSubModel>(subModel, id);
        }
    }
}
