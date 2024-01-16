using Domain.ApiDTO.Demands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Complaints
{
    public class ComplaintGetDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Priority Importance { get; set; }
        public Status status { get; set; } // By default will set in the Service Status.Pending
        public List<DemandDTO> Demands { get; set; }
    }
}
