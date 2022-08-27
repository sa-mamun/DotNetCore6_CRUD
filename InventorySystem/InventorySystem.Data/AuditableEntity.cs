using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Data;

public abstract class AuditableEntity<TKey> : BaseEntity<TKey>
{
    public long CreateBy { get; set; }
}
