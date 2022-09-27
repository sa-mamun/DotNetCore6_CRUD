using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Data
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        //[Timestamp]
        //public byte[] VersionNumber { get; set; }
    }
    
}
