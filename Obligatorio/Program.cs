using System;
using System.Collections.Generic;
using Dominio;

namespace Obligatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            int selected = -1;
            Sistema sistem = Sistema.GetInstance();
            

            while (selected != 0)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Alta Periodista");
                Console.WriteLine("2 - Asignar el valor de referencia");
                Console.WriteLine("3 - Listar partidos por id jugador");
                Console.WriteLine("4 - Listar jugadores expulsados");
                Console.WriteLine("5 - Busqueda de partido con mayor goleada");
                Console.WriteLine("6 - Jugador que haya marcado 1 gol");
                Console.WriteLine("7 - Finalizar Partido");
                int.TryParse(Console.ReadLine(), out selected);
                Console.WriteLine("-----------------------------------------------------------");



                switch (selected)
                {
                    case 0:
                        Console.WriteLine("Adios!");
                        break;
                    
                    case 1:
                        try
                        {
                            Console.WriteLine("Ingrese nombre del periodista");
                            string nombreP = Console.ReadLine();
                            Console.WriteLine("Ingrese el email ");
                            string email = Console.ReadLine();
                            Console.WriteLine("Ingrese la contraseña");
                            string password = Console.ReadLine();


                            sistem.AgregarPeriodista(nombreP, email, password);
                            Console.WriteLine("Se agrego exitosamente un periodista");

                        }catch(Exception e)
                        {
                            throw e;
                              
                        }
                        
                        break;

                    case 2:
                        Console.Write("Ingrese un valor de referencia \n");

                        double ValorReferencia = Int32.Parse(Console.ReadLine());
                        



                        sistem.CambiarElMontoDeReferenciaDelJugador(ValorReferencia);

                        Console.WriteLine("Se ingreso exitosamente el cambio de referencia");



                        break;

                    case 3:
                        
                        Console.WriteLine("Ingrese el id del jugador");
                        int unId = Convert.ToInt32(Console.ReadLine());
                         
                        
                        List<Partido> PartidoJugado = sistem.PartidoIdJugador(unId);



                        foreach(Partido unPartido in PartidoJugado)
                        {
                            Console.WriteLine("Se registraron un total de "+unPartido.IncidenciasEnPartidos()+" incidencias");
                            Console.WriteLine("La fecha del partido es "+unPartido.Fecha);

                            foreach (Seleccion unaSeleccion in unPartido.DevolverSeleccionesVs())
                            {
                                Console.WriteLine("Las 2 selecciones enfrentadas son "+unaSeleccion.ToString());

                            }
                            Console.WriteLine("---------------------------------------");



                        }
                        
                        break;

                       
                    case 4:

                        foreach(Jugador unJugador in sistem.MostrarJugadoresExpulsados()){
                            Console.WriteLine("Nombre Jugador: "+unJugador.Nombre);
                            Console.WriteLine("Valor de mercado: " + unJugador.ValorMercado);
                            Console.WriteLine("---------------------------------------");
                        }
                           
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el nombre de una seleccion");
                        string nombreSeleccion = Console.ReadLine();


                        if (sistem.ObtenerListaPartidos(nombreSeleccion).Count != 0) { 
                        foreach (Partido unPartido in sistem.ObtenerListaPartidos(nombreSeleccion))
                        {
                        
                            Console.WriteLine("La fecha del partido es: "+unPartido);
                            Console.WriteLine("La cantidad de incidencias es de: "+unPartido.IncidenciasDeGolesEnPartidos());
                            
                                foreach (Seleccion unaSeleccion in unPartido.DevolverSeleccionesVs())
                            {
                                    Console.WriteLine("Las 2 selecciones enfrentadas son " + unaSeleccion.ToString());
                                    
                            }
                            Console.WriteLine("---------------------------------------");

                           
                                    
                            
                        }
                        }
                        else
                        {
                            Console.WriteLine("La seleccion todavia no ha disputado ningun partido");
                        }
                        break;
                    
                    case 6:
                        foreach (Jugador losjugadores in sistem.MostrarGoleadores())
                        {
                            Console.WriteLine("Nombre: "+losjugadores.Nombre);
                            Console.WriteLine("Valor De Mercado: "+losjugadores.ValorMercado);
                            Console.WriteLine("Categoria Financiera: "+losjugadores.CategoriaFinanciera());
                            Console.WriteLine("---------------------------------------");
                        }
                        break;
                    case 7:
                        Console.WriteLine("id del partido");
                        int id = int.Parse(Console.ReadLine());
                        //Console.WriteLine("seleccion 1");
                        //string sel1 = Console.ReadLine();
                        //Console.WriteLine("seleccion 2");
                        //string sel2 = Console.ReadLine();
                        //sistem.FinalizarPartido(id, sel1, sel2);
                        
                        break;
                    default:
                        Console.WriteLine("Número Invalido");
                        break;



                }
                Console.ReadKey();



            }


             

        }
    }
}
