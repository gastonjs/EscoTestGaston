using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EscoTestGaston.Models;

namespace EscoTestGaston.DAL
{
    public class EscoTestGastonInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EscoTestGastonContext>
    {
        protected override void Seed(EscoTestGastonContext context)
        {
            var propietarios = new List<Propietario>
            {
                new Propietario{Nombre="Carson",    Apellido="Alexander"},
                new Propietario{Nombre="Meredith",  Apellido="Alonso"},
                new Propietario{Nombre="Arturo",    Apellido="Anand"},
                new Propietario{Nombre="Gytis",     Apellido="Barzdukas"},
                new Propietario{Nombre="Yan",       Apellido="Li"},
                new Propietario{Nombre="Peggy",     Apellido="Justice"},
                new Propietario{Nombre="Laura",     Apellido="Norman"},
                new Propietario{Nombre="Nino",      Apellido="Olivetto"}
                };

                propietarios.ForEach(s => context.Propietarios.Add(s));
                context.SaveChanges();
                var servicios = new List<Servicio>
                {
                new Servicio{TipoServicio="Cambio Aceite"     },
                new Servicio{TipoServicio="Cambio Filtro"},
                new Servicio{TipoServicio="Cambio de Correa"},
                new Servicio{TipoServicio="Revision General"      },
                new Servicio{TipoServicio="Otro"  }
                };
                servicios.ForEach(s => context.Servicios.Add(s));
                context.SaveChanges();
                var autos = new List<Auto>
                {
                new Auto{PropietarioID=1,ServicioID=1},
                new Auto{PropietarioID=1,ServicioID=2},
                new Auto{PropietarioID=1,ServicioID=3},
                new Auto{PropietarioID=2,ServicioID=4},
                new Auto{PropietarioID=2,ServicioID=5},
                new Auto{PropietarioID=2,ServicioID=1},
                new Auto{PropietarioID=3,ServicioID=2},
                new Auto{PropietarioID=4,ServicioID=3},
                new Auto{PropietarioID=4,ServicioID=4},
                new Auto{PropietarioID=5,ServicioID=5},
                new Auto{PropietarioID=6,ServicioID=1},
                new Auto{PropietarioID=7,ServicioID=2},
                };
                autos.ForEach(s => context.Autos.Add(s));
                context.SaveChanges();
            }
        }
}