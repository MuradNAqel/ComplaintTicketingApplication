using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IManageFileService
    {
        Task<string> UploadFile(IFormFile _IFormFile);
        //Task<(byte[], string, string)> DownloadFile(string FileName);
    }
}
