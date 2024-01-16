using Domain.ApiDTO.Complaints;
using Domain.ApiDTO.Demands;
using Domain.ApiDTO.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IComplaintsService
    {
        public Task<ResponseDTO<ComplaintCreateDTO>> Create(ComplaintCreateDTO complaintCreateDTO);
        public Task<ResponseDTO<ComplaintCreateDTO>> Update(ComplaintCreateDTO complaintCreateDTO);
        public Task<ResponseDTO<ComplaintGetDTO>> Delete(int ID);
        public Task<ResponseDTO<ComplaintGetDTO>> GetById(int ID);
        public Task<ResponseDTO<IEnumerable<ComplaintGetDTO>>> GetAll();
    }
}
