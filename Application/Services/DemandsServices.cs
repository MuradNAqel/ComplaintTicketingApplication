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
    public class DemandsServices : IDemandsService
    {
        private readonly IDemandRepo _demandRepo;
        private readonly IMapper _mapper;

        public DemandsServices(IDemandRepo demandRepo, IMapper mapper)
        {
            _demandRepo = demandRepo;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<DemandCreateDTO>> Create(DemandCreateDTO demandCreateDTO)
        {
            ResponseDTO<DemandCreateDTO> responseDTO = new ResponseDTO<DemandCreateDTO>();
            try
            {
                var data = _mapper.Map<Demand>(demandCreateDTO);

                await _demandRepo.Create(data);
                await _demandRepo.SaveChanges();
                responseDTO.SetSuccessWithPayload(demandCreateDTO);

            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError("Error on creating Demand ", ex.Message);
                throw;
            }
            return responseDTO;
        }

        public async Task<ResponseDTO<DemandDTO>> Delete(int ID)
        {
            ResponseDTO<DemandDTO> responseDTO = new ResponseDTO<DemandDTO>();
            try
            {
                var data = _demandRepo.GetById(ID);
                var dataDto = _mapper.Map<DemandDTO>(data);

                await _demandRepo.Delete(ID);
                await _demandRepo.SaveChanges();

                responseDTO.SetSuccessWithPayload(dataDto);
            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError("Error on deleting Demand", ex.Message);
            }

            return responseDTO;
        }

        public async Task<ResponseDTO<IEnumerable<DemandDTO>>> GetAllDemands()
        {
            ResponseDTO<IEnumerable<DemandDTO>> responseDTO = new ResponseDTO<IEnumerable<DemandDTO>>();

            try
            {
                var data = await _demandRepo.GetAll();
                var dataDto = data.Select(demand => _mapper.Map<DemandDTO>(demand));
                responseDTO.SetSuccessWithPayload(dataDto);

            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError("Error Fetching data GetAll Demands", ex.Message);
            }
            return responseDTO;

        }

        public async Task<ResponseDTO<DemandDTO>> GetById(int ID)
        {
            ResponseDTO<DemandDTO> responseDTO = new ResponseDTO<DemandDTO>();
            try
            {
                var data = await _demandRepo.GetById(ID);

                if (data == null)
                {
                    responseDTO.SetFailureWithError("Demand not found", "Demands services GetByID");
                    return responseDTO;
                    throw new Exception("Demand not found");
                }

                var dataDto = _mapper.Map<DemandDTO>(data);
                responseDTO.SetSuccessWithPayload(dataDto);
            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError($"Error Fetching data for Demand ID {ID}", ex.Message);
            }
            return responseDTO;

        }

        public async Task<ResponseDTO<DemandCreateDTO>> Update(DemandCreateDTO demandCreateDTO)
        {
            ResponseDTO<DemandCreateDTO> responseDTO = new ResponseDTO<DemandCreateDTO>();
            try
            {
                var data = _mapper.Map<Demand>(demandCreateDTO);

                await _demandRepo.Update(data);

                await _demandRepo.SaveChanges();
                responseDTO.SetSuccessWithPayload(demandCreateDTO);

            }
            catch (Exception ex)
            {
                responseDTO.SetFailureWithError("Error on Updating Demand ", ex.Message);
            }
            return responseDTO;
        }
    }
}
