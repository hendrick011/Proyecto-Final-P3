using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IProveedorService
    {
        IEnumerable<Proveedor> GetAll();
        bool Add(Proveedor model);
        bool Delete(int id);
        bool Update(Proveedor model);
        Proveedor Get(int id);
    }

    public class ProveedorService : IProveedorService
    {
        private readonly BreadDbContext _breadDbContext;

        public ProveedorService(
            BreadDbContext breadDbContext
            )
        {
            _breadDbContext = breadDbContext;
        }

        public IEnumerable<Proveedor> GetAll()
        {
            var result = new List<Proveedor>();
            try
            {
                result = _breadDbContext.Proveedor.ToList();
            }
            catch (System.Exception)
            {
            }

            return result;

        }

        public Proveedor Get(int id)
        {
            var result = new Proveedor();
            try
            {
                result = _breadDbContext.Proveedor.Single(x => x.IdProveedor == id);
            }
            catch (System.Exception)
            {
            }

            return result;

        }


        public bool Add(Proveedor model)
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

        public bool Update(Proveedor model)
        {
            try
            {
                var originalModel = _breadDbContext.Proveedor.Single(x =>
                    x.IdProveedor == model.IdProveedor
                 );

                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
                originalModel.Empresa = model.Empresa;
                originalModel.Telefono = model.Telefono;

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
                _breadDbContext.Entry(new Proveedor { IdProveedor = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
