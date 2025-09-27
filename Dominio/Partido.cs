using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Partido: IValidacion
    {
       
        private List<Seleccion> SeleccionVsSeleccion{ get; set; }
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        
        private List<Incidencia> Incidencias { get; set; }

        public string Resultado { get; set; }



        public Partido(DateTime unaFecha, string unEstado, string unResultado)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Fecha = unaFecha;
            this.Estado = "No finalizado";
            this.Resultado = "Pendiente";
            this.Incidencias = new List<Incidencia>();
            this.SeleccionVsSeleccion = new List<Seleccion>();
        }

        


        public abstract string FinalizarElPartido();

        public virtual void EsValido()
        {
            if (!ValidarFecha(Fecha))
            {
                throw new Exception("Fecha no valida");
            }
            //despues validar si incidencias y selecciones no son null
        }

        public string SetPartido(string valor)
        {
            return this.Estado = valor;
            
        }

        public List<Seleccion> DevolverSeleccionesVs()
        {

            return SeleccionVsSeleccion;
        }
        
        public virtual List<Seleccion> AgregarSeleccionesVs(Seleccion S1, Seleccion S2)
        {
            //validar que no sean las mismas selecciones, la 1 y la 2 (CompareTo)
            if(S1 != null && S2 != null)
            {
                SeleccionVsSeleccion.Add(S1);
                SeleccionVsSeleccion.Add(S2);
            }
            return SeleccionVsSeleccion;
        }
        
        public List<Incidencia> DevolverIncidencias()
        {
            return Incidencias;
        }

        public virtual List<Incidencia> AgregarUnaIncidencia(Incidencia unaIncidencia)
        {
            
            Incidencias.Add(unaIncidencia);
            
            return Incidencias;
        }

        public int IncidenciasEnPartidos()
        {
            int contador = 0;
            foreach(Incidencia unaIncidencia in Incidencias)
            {
                
                contador++;

            }
            return contador;
        }

        public int IncidenciasDeGolesEnPartidos()
        {
            int goles = 0;
            foreach (Incidencia unaIncidencia in Incidencias)
            {
                if(unaIncidencia.TipoIncidencia.Equals("Gol"))
                
                    goles++;

            }
            return goles;
        }

        


        public virtual bool ValidarFecha(DateTime unaFecha) 
        {
            DateTime fechaInicio= DateTime.Parse("2022-11-20");
            DateTime fechaFinal = DateTime.Parse("2022-12-18"); ;
            
            if(unaFecha< fechaInicio || unaFecha>fechaFinal)
            {
                return false;
            }
            return true;
     
        }
        public override string ToString()
        {



            return $"{Fecha}";
        }
        public abstract string TipoDePartido();
        public abstract string DevolverResultado();
        public abstract string FaseDelTorneo();
        public virtual int CantGolesSel1()
        {
            Seleccion s1 = DevolverSeleccionesVs()[0];

            int contador = 0;


            foreach (Incidencia i in DevolverIncidencias())
            {
                if (i.TipoIncidencia.Equals("Gol"))
                {
                    if (i.Jugador.Pais.Nombre.Equals(s1.Pais.Nombre))
                    {
                        contador = contador + 1;

                    }



                }
            }

            return contador;
        }

        public virtual int CantGolesSel2()
        {
            Seleccion s2 = DevolverSeleccionesVs()[1];

            int contador = 0;


            foreach (Incidencia i in DevolverIncidencias())
            {
                if (i.TipoIncidencia.Equals("Gol"))
                {
                    if (i.Jugador.Pais.Nombre.Equals(s2.Pais.Nombre))
                    {
                        contador = contador + 1;

                    }



                }
            }

            return contador;
        }

        public virtual int CantAmarillasSel1()
        {
            Seleccion s1 = DevolverSeleccionesVs()[0];

            int contador = 0;


            foreach (Incidencia i in DevolverIncidencias())
            {
                if (i.TipoIncidencia.Equals("Amarilla"))
                {
                    if (i.Jugador.Pais.Nombre.Equals(s1.Pais.Nombre))
                    {
                        contador = contador + 1;

                    }



                }
            }

            return contador;
        }

        public virtual int CantAmarillasSel2()
        {
            Seleccion s2 = DevolverSeleccionesVs()[1];

            int contador = 0;


            foreach (Incidencia i in DevolverIncidencias())
            {
                if (i.TipoIncidencia.Equals("Amarilla"))
                {
                    if (i.Jugador.Pais.Nombre.Equals(s2.Pais.Nombre))
                    {
                        contador = contador + 1;

                    }



                }
            }

            return contador;
        }

        public virtual int CantRojasSel1()
        {
            Seleccion s1 = DevolverSeleccionesVs()[0];

            int contador = 0;


            foreach (Incidencia i in DevolverIncidencias())
            {
                if (i.TipoIncidencia.Equals("Roja"))
                {
                    if (i.Jugador.Pais.Nombre.Equals(s1.Pais.Nombre))
                    {
                        contador = contador + 1;

                    }



                }
            }

            return contador;
        }

        public virtual int CantRojasSel2()
        {
            Seleccion s2 = DevolverSeleccionesVs()[1];

            int contador = 0;


            foreach (Incidencia i in DevolverIncidencias())
            {
                if (i.TipoIncidencia.Equals("Roja"))
                {
                    if (i.Jugador.Pais.Nombre.Equals(s2.Pais.Nombre))
                    {
                        contador = contador + 1;

                    }



                }
            }

            return contador;
        }

    }
}
