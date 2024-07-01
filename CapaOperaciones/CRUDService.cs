using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaOperaciones
{
    public class CRUDService <T> where T : class
    {
        private readonly DbContext _context;

        public CRUDService(DbContext context)
        {
            this._context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public bool Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return _context.SaveChanges() > 0;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Delete(int id) 
        {
            var entity = _context.Set<T>().Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public T FindId(int? id)
        {
            var entidad = _context.Set<T>().Find(id);
            return entidad;
        }
    }
}
