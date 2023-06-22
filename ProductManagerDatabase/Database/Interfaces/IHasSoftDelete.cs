using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerDatabase.Database.Interfaces
{
    public interface IHasSoftDelete
    {
        DateTimeOffset? DeletedAt { get; set; }
    }
}
