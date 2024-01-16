using Domain.ApiDTO.Demands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Complaints
{
    public class ComplaintUpdateDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PdfPath { get; set; }
        public Priority Importance { get; set; }
        public Status status { get; set; }
        public List<DemandCreateDTO> Demands { get; set; }
    }
}
