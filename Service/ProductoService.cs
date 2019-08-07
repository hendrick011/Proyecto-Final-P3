using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAll();
        bool Add(Producto model);
        bool Delete(int id);
        bool Update(Producto model);
        Producto Get(int id);
    }

    public class ProductoService : IProductoService
    {
        private readonly BreadDbContext _breadDbContext;

        public ProductoService(
            BreadDbContext breadDbContext
            )
        {
            _breadDbContext = breadDbContext;
        }

        public IEnumerable<Producto> GetAll()
        {
            var result = new List<Producto>();
            try
            {
                result = _breadDbContext.Producto.ToList();
            }
            catch (System.Exception)
            {
            }

            return result;

        }

        public Producto Get(int id)
        {
            var result = new Producto();
            try
            {
                result = _breadDbContext.Producto.Single(x => x.IdProducto == id);
            }
            catch (System.Exception)
            {
            }

            return result;

        }


        public bool Add(Producto model)
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

        public bool Update(Producto model)
        {
            try
            {
                var originalModel = _breadDbContext.Producto.Single(x =>
                    x.IdProducto == model.IdProducto
                 );

                originalModel.Tipo = model.Tipo;
                originalModel.Precio = model.Precio;
                originalModel.Proveedor = model.Proveedor;

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
                _breadDbContext.Entry(new Producto { IdProducto = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
