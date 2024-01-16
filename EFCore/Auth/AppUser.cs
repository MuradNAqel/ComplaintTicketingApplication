using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Auth
{
    public class AppUser : IdentityUser
    {

        public IEnumerable<Complaint>? complaints { get; set; }
    }
}
