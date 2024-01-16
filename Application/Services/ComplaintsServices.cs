using AutoMapper;
using Domain.ApiDTO.Complaints;
using Domain.ApiDTO.Demands;
using Domain.ApiDTO.Response;
using Domain.Contracts;
using Domain.Entities;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ComplaintsServices : IComplaintsService
    {
        private readonly IComplaintRepo _complaintRepo;
        private readonly IMapper _mapper;

        public ComplaintsServices(IComplaintRepo complaintRepo, IMapper mapper)
        {
            _complaintRepo = complaintRepo;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<ComplaintCreateDTO>> Create(ComplaintCreateDTO complaintCreateDTO)
        {
            ResponseDTO<ComplaintCreateDTO> responseDTO = new ResponseDTO<ComplaintCreateDTO>();
            try
            {
                var data = _mapper.Map<Complaint>(complaintCreateDTO);

                await _complaintRepo.Create(data);

                

                responseDTO.SetSuccessWithPayload(complaintCreateDTO);

            }
            catch (Exception ex) {
                responseDTO.SetFailureWithError("Error on creating Complaint ", ex.Message);
            }
            return responseDTO;
        }

        public async Task<ResponseDTO<ComplaintGetDTO>> Delete(int ID)
        {
            ResponseDTO<ComplaintGetDTO> responseDTO = new ResponseDTO<ComplaintGetDTO>();
            try
            {
                var data = await _complaintRepo.GetById(ID);
                var dataDto = _mapper.Map<ComplaintGetDTO>(data);

                await _complaintRepo.Delete(ID);
                await _complaintRepo.SaveChanges();

                responseDTO.SetSuccessWithPayload(dataDto);
            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError("Error on deleting Complaint", ex.Message);
            }

            return responseDTO;
        }

        public async Task<ResponseDTO<IEnumerable<ComplaintGetDTO>>> GetAll()
        {
            ResponseDTO<IEnumerable<ComplaintGetDTO>> responseDTO = new ResponseDTO<IEnumerable<ComplaintGetDTO>>();
            try
            {
                var data = await _complaintRepo.GetAll();
                var dataDto = data
                    .Select(comp => _mapper.Map<ComplaintGetDTO>(comp));
                responseDTO.SetSuccessWithPayload(dataDto); 
            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError("Error on Fetching Complaints", ex.Message);
            }
            return responseDTO;

        }

        public async Task<ResponseDTO<ComplaintGetDTO>> GetById(int ID)
        {
            ResponseDTO<ComplaintGetDTO> responseDTO = new ResponseDTO<ComplaintGetDTO>();
            try
            {
                var data = await _complaintRepo.GetById(ID);

                if (data == null)
                { 
                    responseDTO.SetFailureWithError("Complaint not found","Complaints services GetByID");
                    return responseDTO;
                    throw new Exception("Country not found");
                }

                var dataDto = _mapper.Map<ComplaintGetDTO>(data);
                responseDTO.SetSuccessWithPayload(dataDto);
                return responseDTO;
            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError($"Error Fetching data for Complaint ID {ID}", ex.Message);
                return responseDTO;
            }
        }

        public async Task<ResponseDTO<ComplaintCreateDTO>> Update(ComplaintCreateDTO complaintCreateDTO)
        {

            ResponseDTO<ComplaintCreateDTO> responseDTO = new ResponseDTO<ComplaintCreateDTO>();
            try
            {
                var data = _mapper.Map<Complaint>(complaintCreateDTO);

                await _complaintRepo.Update(data);

                await _complaintRepo.SaveChanges();

                responseDTO.SetSuccessWithPayload(complaintCreateDTO);

            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError("Error on Updating Complaint ", ex.Message);
            }
            return responseDTO;
        }

    }
}
