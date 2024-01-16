using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Demand : BaseEntity
    {
        public string Text { get; set; }

        [ForeignKey(nameof(ComplaintID))]
        public int ComplaintID { get; set; }
        public Complaint ComplaintNav { get; set; }
    }
}
