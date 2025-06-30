using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public abstract class BaseEntity
    {
        
        public bool IsDeleted { get; set; }
        
    }
}
