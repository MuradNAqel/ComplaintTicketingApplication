using Domain.Contracts;
using Domain.Entities;
using EFCore.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repositories
{
    public class ComplaintRepo : IComplaintRepo
    {
        private readonly AppDbContext _context;

        public ComplaintRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Create(Complaint complaint)
        {
            complaint.CreatedAt = DateTime.Now;
            complaint.status = Status.Pending;
            await _context.Complaints.AddAsync(complaint);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int ID)
        {
            var complaint = await GetById(ID);

            if (complaint != null)
            {
                _context.Complaints.Remove(complaint);
                _context.Demands.RemoveRange(complaint.Demands);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Complaint>> GetAll()
        {
            var comp = await _context.Complaints.ToListAsync();
            comp.ForEach(complaint => 
            { 
                complaint.Demands = _context.Demands.Where(demand => demand.ComplaintID == complaint.ID).ToList();
            });
            return comp;
        }

        public async Task<Complaint?> GetById(int ID)
        {
            var complaint = await _context.Complaints.FindAsync(ID);
            complaint.Demands =  _context.Demands.Where(d => d.ComplaintID == ID).ToList();
            return complaint;
        }

        public async Task Update(Complaint complaint)
        {
             _context.Complaints.Update(complaint);
            await _context.SaveChangesAsync();
            await Task.Yield();
        }

    }
}
