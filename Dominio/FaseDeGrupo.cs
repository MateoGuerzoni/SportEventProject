using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public  class FaseDeGrupo : Partido
    {
        public string Grupo { get; set; }
        
       
        public FaseDeGrupo(string grupo,DateTime unaFecha, string unEstado, string unResultado):base(unaFecha,unEstado,unResultado)
        {
            this.Grupo = grupo;
        }



        public override void EsValido()
        {
            if (Grupo.Equals(""))
            {
                throw new Exception("El nombre de grupo no puede ser vacio");
            }
        }

        public override string ToString()
        {
            return $"{Fecha}-";
        }

        public override string FinalizarElPartido()
        {
            Seleccion sel1 = DevolverSeleccionesVs()[0];
            Seleccion sel2 = DevolverSeleccionesVs()[1];

            int golSel1 = 0;
            int golSel2 = 0;

            foreach (Incidencia i in DevolverIncidencias())
            {
                if (i.TipoIncidencia.Equals("Gol"))
                {
                    if (i.Jugador.Pais.Nombre.Equals(sel1.Pais.Nombre))
                    {
                        golSel1 = golSel1 + 1;

                    }
                    else
                    {
                        golSel2 = golSel2 + 1;
                    }


                }
            }

            if (golSel1 > golSel2)
            {
                Resultado = "Ganador " + sel1;
            }
            else if (golSel1 < golSel2)
            {
                Resultado = "Ganador " + sel2;
            }
            else
            {
                Resultado = "Empate";
            }

            return Resultado;



        }

        public override string TipoDePartido()
        {
            return "FasedeGrupo";
        }

        public override string FaseDelTorneo()
        {
            return "Fase de Grupo";
        }
       
        
        public override string DevolverResultado()
        {
            return this.Resultado;
        }
    }

}
