using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pais : IValidacion
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Nombre { get; set; }
        public string Alpha3 { get; set; }


        public Pais (string unNombre, string Alpha3P)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = unNombre;
            this.Alpha3 = Alpha3P;
            
        }

        public void EsValido()
        {
            if(Alpha3.Length <3 && Alpha3.Length >3)
            {
                throw new Exception("Codigo Alpha3 no es valido");
            }if(Nombre == "")
            {
                throw new Exception("Nombre no es valido");
            }
            
        }

        public override string ToString()
        {
            return $"{Nombre}-{Alpha3}";
        }
    }
}
