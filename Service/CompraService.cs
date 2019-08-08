using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface ICompraService
    {
        IEnumerable<Compra> GetAll();
        bool Add(Compra model);
        bool Delete(int id);
        bool Update(Compra model);
        Compra Get(int id);
    }

    public class CompraService : ICompraService
    {
        private readonly BreadDbContext _breadDbContext;

        public CompraService(
            BreadDbContext breadDbContext
            )
        {
            _breadDbContext = breadDbContext;
        }

        public IEnumerable<Compra> GetAll()
        {
            var result = new List<Compra>();
            try
            {
                result = _breadDbContext.Compra.ToList();
            }
            catch (System.Exception)
            {
            }

            return result;

        }

        public Compra Get(int id)
        {
            var result = new Compra();
            try
            {
                result = _breadDbContext.Compra.Single(x => x.IdCompra == id);
            }
            catch (System.Exception)
            {
            }

            return result;

        }


        public bool Add(Compra model)
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

        public bool Update(Compra model)
        {
            try
            {
                var originalModel = _breadDbContext.Compra.Single(x =>
                    x.IdCompra == model.IdCompra
                 );

                originalModel.Producto = model.Producto;
                originalModel.Cliente = model.Cliente;
                originalModel.Empleado = model.Empleado;
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
                _breadDbContext.Entry(new Compra { IdCompra = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
