using Azure;
using Domain.ApiDTO.Complaints;
using Domain.ApiDTO.Response;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaintsService _complaintsService;
        private readonly IManageFileService _iManageFile;


        public ComplaintsController(IComplaintsService complaintsService, IManageFileService iManageFile)
        {
            _complaintsService = complaintsService;
            _iManageFile = iManageFile;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<ComplaintCreateDTO>>> Create(ComplaintCreateDTO input)
        {
            var path = await _iManageFile.UploadFile(input.formFile);

            input.SetPdfPath(path);
            var response = await _complaintsService.Create(input);

            return response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpPut]
        public async Task<ActionResult<ResponseDTO<ComplaintCreateDTO>>> Update(ComplaintCreateDTO input)
        {
            var path = await _iManageFile.UploadFile(input.formFile);

            input.SetPdfPath(path);
            var response = await _complaintsService.Update(input);

            return response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpGet]
        public async Task<ActionResult<ResponseDTO<ComplaintGetDTO>>> Get(int ID)
        {
            var response = await _complaintsService.GetById(ID);

            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpDelete]
        public async Task<ActionResult<ResponseDTO<ComplaintGetDTO>>> Delete(int ID)
        {
            var response = await _complaintsService.Delete(ID);

            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<ComplaintGetDTO>>> GetAll()
        {
            var response = await _complaintsService.GetAll();

            return response.Success ? Ok(response) : BadRequest(response);
        }



    }
}
