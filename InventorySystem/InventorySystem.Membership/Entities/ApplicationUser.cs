using InventorySystem.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Membership.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public Employee? Employee { get; set; }
        public long? EmployeeId { get; set; }
    }
}
