using Domain.ApiDTO.Demands;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Complaints
{
    public class ComplaintCreateDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }

        private string pdfPath;

        public string GetPdfPath()
        {
            return pdfPath;
        }

        public void SetPdfPath(string value)
        {
            pdfPath = value;
        }

        public Priority Importance { get; set; }
        private Status status { get; set; } = Status.Pending;
        public IFormFile formFile { get; set; }
    }
}
