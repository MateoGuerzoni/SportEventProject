using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Jugador: IValidacion, IComparable<Jugador>
    {
        public int Id { get; set; }

        
        public string Nombre { get; set; }
        public string NumeroCamiseta { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double Altura { get; set; }
        public string Piehabil { get; set; }
        public double ValorMercado { get; set; }
        public string Moneda { get; set; }
        public string Puesto { get; set; }
        public Pais Pais { get; set; }
        
        public static double MontoReferencia { get; set; }
        

        public Jugador(int Id, string NumeroCamisetaJ,  string NombreJ, DateTime FechaNacimientoj,
            double AlturaJ, string PieHabilJ, double ValorMercadoJ, string MonedaJ, Pais unPais, string Puestoj)
        {
            this.Id = Id;
            this.NumeroCamiseta = NumeroCamisetaJ;
            this.Nombre = NombreJ;
            this.FechaNacimiento = FechaNacimientoj;
            this.Altura = AlturaJ;
            this.Piehabil = PieHabilJ;
            this.ValorMercado = ValorMercadoJ;
            this.Moneda = MonedaJ;
            this.Pais = unPais;
            this.Puesto = Puestoj;
        }

        public string CategoriaFinanciera()
        {
            if (ValorMercado < MontoReferencia)
            {
                return "standar";
            }
            return "vip";
        }



        public void EsValido()
        {
            if(Nombre.Equals(""))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
            if (NumeroCamiseta.Equals(""))
            {
                throw new Exception("Numero de camiseta no valido");
            }if (Id < 0)
            {
                throw new Exception("Id no valido");
            }
            if (Altura < 0)
            {
                throw new Exception("Altura no puede ser menor de 0");
            }if (Piehabil.Equals(""))
            {
                throw new Exception("Pie habil no puede ser vacio");
            }if (Moneda.Equals(""))
            {
                throw new Exception("Moneda no puede ser vacio");
            }
            if(Pais == null)
            {
                throw new Exception("Pais no puede ser vacio");
            }
            if (Puesto.Equals(""))
            {
                throw new Exception("Puesto no puede ser vacio");
            }
            if (ValorMercado < 0)
            {
                throw new Exception("Valor del mercado no puede ser menor a 0");
            }
            
            
            
            
            
        }

        

        public override bool Equals(object obj)
        {
            var unJugador = obj as Jugador;

            return unJugador != null && Id == unJugador.Id;

        }

        public override string ToString()
        {
           
        
        
            return $"{Nombre}-{NumeroCamiseta}";
        }

        public int CompareTo([AllowNull] Jugador other)
        {
            if (ValorMercado.CompareTo(other.ValorMercado) <0)
            {
                return 1;
            }else if (ValorMercado.CompareTo(other.ValorMercado) > 0)
            {
                return -1;
            }
            else 
            {
                if (Nombre.CompareTo(other.Nombre) < 0)
                {
                    return -1;
                }else if(Nombre.CompareTo(other.Nombre) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            

        }
    }
}
