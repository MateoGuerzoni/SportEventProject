using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio

{
    public class Reseña : IValidacion, IComparable<Reseña>
    {
        public Periodista Periodista { get; set; }
        
        public Partido Partido { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public Reseña(Periodista unPeriodista, Partido unPartido,DateTime FechaR, string TituloR, string ContenidoR)
        {
            this.Periodista = unPeriodista;
            this.Partido = unPartido;
            this.Fecha = FechaR;
            this.Titulo = TituloR;
            this.Contenido = ContenidoR;
        }

        public Reseña() : base()
        {
            
        }

        //Metodo de validacion de reseña.
        public void EsValido()
        {
            if (Periodista == null)
            {
                throw new Exception("Periodista no puede ser null");
            }

            if (Partido == null)
            {
                throw new Exception("Partido no puede ser null");
            }

            if (Titulo.Equals(""))
            {
                throw new Exception("Titulo no puede ser vacio");
            }
            if (Contenido.Equals(""))
            {
                throw new Exception("Contenido no puede ser vacio");
            }
        }

        public int CompareTo(Reseña other)
        {
            if (Fecha.CompareTo(other.Fecha) > 0)
            {
                return 1;
            }
            else if (Fecha.CompareTo(other.Fecha) < 0)
            {
                return -1;
            }
            return 0;

        }
    }
}
