using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelations
{
    public class Engine
    {
        public int HorsePower { get; set; }
        public int RevLimiter { get; set; }
        public int NumberOfCilinders { get; set; }
        public string Make { get; set; }
        public int Id { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
