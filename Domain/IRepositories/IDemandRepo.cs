using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IDemandRepo
    {
        public Task Create(Demand demand);
        public Task Update(Demand demand);
        public Task Delete(int ID);
        public Task<Demand?> GetById(int ID);
        public Task<IEnumerable<Demand>> GetAll();
        public Task<bool> SaveChanges();

    }
}
