using Domain.ApiDTO.Demands;
using Domain.ApiDTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IDemandsService
    {
        public Task<ResponseDTO<DemandCreateDTO>> Create(DemandCreateDTO demandCreateDTO);
        public Task<ResponseDTO<DemandCreateDTO>> Update(DemandCreateDTO demandCreateDTO);
        public Task<ResponseDTO<DemandDTO>> Delete(int ID);
        public Task<ResponseDTO<DemandDTO>> GetById(int ID);
        public Task<ResponseDTO<IEnumerable<DemandDTO>>> GetAllDemands();
    }
}
