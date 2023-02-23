using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShare.Domain.Commons
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
    }
}
