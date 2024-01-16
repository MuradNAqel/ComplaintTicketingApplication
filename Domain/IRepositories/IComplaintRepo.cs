using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IComplaintRepo
    {
   
        public Task Create(Complaint complaint);
        public Task Update(Complaint complaint);
        public Task Delete(int ID);
        public Task<Complaint?> GetById(int ID);
        public Task<IEnumerable<Complaint>> GetAll();
        public Task<bool> SaveChanges();
    }
}
