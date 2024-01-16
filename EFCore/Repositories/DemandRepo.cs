using Domain.Contracts;
using Domain.Entities;
using EFCore.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repositories
{
    public class DemandRepo : IDemandRepo
    {
        private readonly AppDbContext _context;

        public DemandRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Create(Demand demand)
        {
            demand.CreatedAt = DateTime.Now;
            await _context.Demands.AddAsync(demand);
        }

        public async Task Delete(int ID)
        {
            var demand = await GetById(ID);

            if (demand != null)
            {
                _context.Demands.Remove(  demand);
            }
        }

        public async Task<IEnumerable<Demand>> GetAll()
        {
           return await _context.Demands.ToListAsync();
        }

        public async Task<Demand?> GetById(int ID)
        {
            return await _context.Demands.FindAsync(ID);
        }

        public async Task Update(Demand demand)
        {
            _context.Demands.Update(demand);
            await Task.Yield();
        }
    }
}
