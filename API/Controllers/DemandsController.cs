using Application.Services;
using Domain.ApiDTO.Complaints;
using Domain.ApiDTO.Demands;
using Domain.ApiDTO.Response;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DemandsController : ControllerBase
    {
        private readonly IDemandsService _demandsService;

        public DemandsController(IDemandsService demandsService)
        {
            _demandsService = demandsService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<DemandCreateDTO>>> Create(DemandCreateDTO input)
        {
            var response = await _demandsService.Create(input);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDTO<DemandCreateDTO>>> Update(DemandCreateDTO input)
        {
            {
                var response = await _demandsService.Update(input);
                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDTO<DemandDTO>>> Get(int ID)
        {
            var response = await _demandsService.GetById(ID);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseDTO<DemandDTO>>> Delete(int ID)
        {
            var response = await _demandsService.Delete(ID);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DemandDTO>>> GetAll()
        {
            var response = await _demandsService.GetAllDemands();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
