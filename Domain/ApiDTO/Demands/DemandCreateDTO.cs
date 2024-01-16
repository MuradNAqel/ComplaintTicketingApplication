using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Demands
{
    public class DemandCreateDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int ComplaintID { get; set; }
    }
}
