using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Complaint : BaseEntity
    {
        public string Text { get; set; }
        public string PdfPath  { get; set; }
        public Priority Importance { get; set; }
        public Status status { get; set; } // By default will set in the Service Status.Pending
        public int UserID { get; set; }
        public List<Demand> Demands { get; set; }

    }
}
