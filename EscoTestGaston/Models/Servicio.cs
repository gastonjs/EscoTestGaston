using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscoTestGaston.Models
{
    public class Servicio
    {        
        public int ID { get; set; }
        public string TipoServicio { get; set; }
        
        public virtual ICollection<Auto> Autos { get; set; }
    }
}