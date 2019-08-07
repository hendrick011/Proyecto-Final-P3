using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IEmpleadoService
    {
        IEnumerable<Empleado> GetAll();
        bool Add(Empleado model);
        bool Delete(int id);
        bool Update(Empleado model);
        Empleado Get(int id);
    }

    public class EmpleadoService : IEmpleadoService
    {
        private readonly BreadDbContext _breadDbContext;

        public EmpleadoService(
            BreadDbContext breadDbContext
            )
        {
            _breadDbContext = breadDbContext;
        }

        public IEnumerable<Empleado> GetAll()
        {
            var result = new List<Empleado>();
            try
            {
                result = _breadDbContext.Empleado.ToList();
            }
            catch (System.Exception)
            {
            }

            return result;

        }

        public Empleado Get(int id)
        {
            var result = new Empleado();
            try
            {
                result = _breadDbContext.Empleado.Single(x => x.IdEmpleado == id);
            }
            catch (System.Exception)
            {
            }

            return result;

        }


        public bool Add(Empleado model)
        {
            try
            {
                _breadDbContext.Add(model);
                _breadDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
            
        }

        public bool Update(Empleado model)
        {
            try
            {
                var originalModel = _breadDbContext.Empleado.Single(x =>
                    x.IdEmpleado == model.IdEmpleado
                 );

                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
                originalModel.puesto = model.puesto;

                _breadDbContext.Update(originalModel);
                _breadDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;

        }

        public bool Delete(int id)
        {
            try
            {
                _breadDbContext.Entry(new Empleado { IdEmpleado = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _breadDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;

        }
    }
}
