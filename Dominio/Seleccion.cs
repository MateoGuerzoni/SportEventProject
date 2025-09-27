using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Seleccion : IValidacion ,IComparable<Seleccion>
    {
        public Pais Pais { get; set; }
        private List<Jugador> Plantel { get; set; }

        public int Id { get; set; }
        public static int UltimoId { get; set; }


        public Seleccion(Pais unPais)
        {
            this.Id = UltimoId;
            UltimoId++;
            Pais = unPais;
            this.Plantel = new List<Jugador>();

        }

        public void EsValido()
        {
            if (Pais == null)
            {
                throw new Exception("El pais no puede ser vacio");
            }
            if (!SeleccionCantidadJugadores())
            {
                throw new Exception("La cantidad de jugadores debe de ser igual o mayor a 11");
            }
        }

        public bool SeleccionCantidadJugadores()
        {


            bool CanJugadores = false;

            int contadorJugador = 0;

            foreach (Jugador j in Plantel)
            {
                contadorJugador++;

            }

            if (contadorJugador >= 11)
            {

                CanJugadores = true;
            }

            return CanJugadores;


        }

        public void AgregarJugador(Jugador unJugador)
        {
            if (unJugador != null)
            {
                Plantel.Add(unJugador);
            }

        }
        public List<Jugador> DevolverPlantel()
        {

            return Plantel;
        }

        public int CompareTo(Seleccion other)
        {
            if (Pais.Nombre.CompareTo(other.Pais.Nombre) > 0)
            {
                return 1;
            }
            else 
            {
                return -1;
            }
        }



        public override string ToString()
        {



            return $"{Pais.Nombre}";
        }
    }
}