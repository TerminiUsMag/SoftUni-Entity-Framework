using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelations
{
    public class Car
    {
        //public int CarPrimaryId { get; set; }

        public int Id { get; set; }

        //Scalar property
        public int EngineId { get; set; }

        //Navigation property
        public Engine Engine { get; set; }

        //public string LicensePlate { get; set; }

        //public string Region { get; set; }
    }
}
