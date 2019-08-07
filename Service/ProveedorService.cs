using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();
        bool Add(Cliente model);
        bool Delete(int id);
        bool Update(Cliente model);
        Cliente Get(int id);
    }

    public class ClienteService : IClienteService
    {
        private readonly BreadDbContext _breadDbContext;

        public ClienteService(
            BreadDbContext breadDbContext
            )
        {
            _breadDbContext = breadDbContext;
        }

        public IEnumerable<Cliente> GetAll()
        {
            var result = new List<Cliente>();
            try
            {
                result = _breadDbContext.Cliente.ToList();
            }
            catch (System.Exception)
            {
            }

            return result;

        }

        public Cliente Get(int id)
        {
            var result = new Cliente();
            try
            {
                result = _breadDbContext.Cliente.Single(x => x.ClienteId == id);
            }
            catch (System.Exception)
            {
            }

            return result;

        }


        public bool Add(Cliente model)
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

        public bool Update(Cliente model)
        {
            try
            {
                var originalModel = _breadDbContext.Cliente.Single(x =>
                    x.ClienteId == model.ClienteId
                 );

                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
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
                _breadDbContext.Entry(new Cliente { ClienteId = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
