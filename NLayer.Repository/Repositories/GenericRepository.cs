using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class   
    {

        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {

            await _dbSet.AddAsync(entity);     

        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        // productRepository.where(x=>x.id>5).OrderBy.ToListAsync ile aynı 
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        //delete ve update neden async await kullanmadık çünkü bu işlemler zaten var olan veri üzerinden işlem yapar
        //yani hafızada olan veriyi kullanır mesela add işleminde hafızada olmadığı için eklerken kullanılır
        //burda öyle bir duruma gerek yoktutayrıca bu durumda update ve delete işlemlerinde flag atmış gibi düşünebiliriz
        //hafızayı yormamış olur savechanges fonksiyonu çalıştığında bu flaglanmış verileri vtye kaydeder
        //yani gidip de 1000 tane veriyi işlemek vtden çekmek yerinde flag atar savechanges çağrılınca çeker veriyi
    }
}
