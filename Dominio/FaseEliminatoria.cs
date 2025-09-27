using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseEliminatoria : Partido
    {
        public string Etapa { get; set; }
        public bool Alargue { get; set; }
        public bool Penales { get; set; }


        public FaseEliminatoria( DateTime unaFecha, string unEstado, string unResultado, string unaEtapa, bool unAlargue, bool unosPenales) : base(unaFecha, unEstado, unResultado)
        {
            this.Etapa = unaEtapa;
            this.Alargue = unAlargue;
            this.Penales = unosPenales;

        }

        public override void EsValido()
        {
            if (Etapa.Equals(""))
            {
                throw new Exception("La etapa no puede ser vacia");
            }
        }

        public override string FinalizarElPartido()
        {
            Seleccion s1 = DevolverSeleccionesVs()[0];
            Seleccion s2 = DevolverSeleccionesVs()[1];

            int golS1 = 0;
            int golS2 = 0;

            foreach (Incidencia i in DevolverIncidencias())
            {
                if (i.TipoIncidencia.Equals("Gol"))
                {
                    if (i.Jugador.Pais.Nombre.Equals(s1.Pais.Nombre))
                    {
                        golS1 = golS1 + 1;

                    }
                    else
                    {
                        golS2 = golS2 + 1;
                    }


                }
            }
            if (golS1 > golS2)
            {
                Resultado = "Ganador " + s1;
            } else if (golS1 < golS2)
            {
                Resultado = "Ganador " + s2;
            }
          
            if (golS1 > golS2 && Alargue == true)
            {
                Resultado = "Ganador " + s1 + " En tiempo agregado";
            }
            else if(golS2 > golS1 && Alargue == true)
            {
                Resultado = "Ganador " + s2 + " En tiempo agregado";
            }

            if (golS1 > golS2 && Penales == true)
            {
                Resultado = "Ganador " + s1 + " En tanda de penales";
            }
            else if(golS1 < golS2 && Penales == true)
            {
                Resultado = "Ganador " + s2 + " En tanda de penales";
            }

            return Resultado ;



        }


        

        public override string TipoDePartido()
        {
            return "FaseEliminatoria";



        }

        public override string FaseDelTorneo()
        {
            if(this.Etapa == "Octavos")
            {
                return "Octavos";
            }
            else if (this.Etapa == "Cuartos")
            {
                return "Cuartos";
            }
            else if(this.Etapa == "Semis")
            {
                return "Semis";
            }
            else
            {
                return "Final";
            }
                
        }
        public override string DevolverResultado()
        {
            return this.Resultado;
        }
    }


}
