using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
public class Incidencia
{ 
     public string TipoIncidencia { get; set; }
     public Jugador Jugador { get; set; }
     public double MinutoDeIncidencia { get; set; }
     public int Id { get; set; }
     public static int UltimoId { get; set; }

    public Incidencia( string unTipoDeIncidencia, Jugador unJugador, double unMinutoDeIncidencia)
    {
            this.Id = UltimoId;
            UltimoId++;
            this.TipoIncidencia = unTipoDeIncidencia;
            this.Jugador = unJugador;
            this.MinutoDeIncidencia = unMinutoDeIncidencia;
    }

      
       
  
   
    public string GetIncidencia()
        {
            return this.TipoIncidencia;
        }

        public override string ToString()
        {



            return $"{TipoIncidencia}-{Jugador}";
        }
    }
}
