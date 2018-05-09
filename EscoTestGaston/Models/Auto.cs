using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscoTestGaston.Models
{
    public class Auto
    {
        public int ID { get; set; }
        public int ServicioID { get; set; }
        public int PropietarioID { get; set; }
        public string Marca { get; set; }
        public int Anio { get; set; }
        public string Patente { get; set; }       


        public virtual Servicio Servicio { get; set; }
        public virtual Propietario Propietario { get; set; }
    }
}