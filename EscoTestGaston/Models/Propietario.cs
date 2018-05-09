using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscoTestGaston.Models
{
    public class Propietario
    {
        public int ID { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
       
        public virtual ICollection<Auto> Autos { get; set; }
    }
}