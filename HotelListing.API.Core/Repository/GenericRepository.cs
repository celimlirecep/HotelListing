using AutoMapper;
using AutoMapper.QueryableExtensions;

using  HotelListing.API.Data;

using Microsoft.EntityFrameworkCore;
using HotelListing.API.Core.Abstract;
using HotelListing.API.Core.Models;

namespace  HotelListing.API.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(HotelListingDbContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<TResult> AddAsync<TSource, TResult>(TSource entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var entity=await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity=await GetAsync(id);
            return entity!=null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<PagesResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
        {
            var totalSıze= await _context.Set<T>().CountAsync();
            var items=await _context.Set<T>()
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new PagesResult<TResult>
            {
                Items = items,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSıze
            };
        }

        public Task<List<T>> GetAllAsync<TResult>()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id==null)
            {
                return null;
            }
           return await _context.Set<T>().FindAsync(id);
        }

        public Task<TResult> GetAsync<TResult>(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync<TSource>(int id, TSource entity)
        {
            throw new NotImplementedException();
        }
    }
}
