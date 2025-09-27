using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace MundialWeb.Controllers
{
    public class OperadorController : Controller
    {
        Sistema instancia = Sistema.GetInstance();

        private bool CheckLoginOperador()
        {
            
            string rol = HttpContext.Session.GetString("TipoUsuario");
            if (rol == "Operador")
            {
                return true;
            }

            return false;
        }

        
        public IActionResult MostrarOpciones()
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }

            return View();
        }
        public IActionResult MostrarPendientes()
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario");
            }
            
            List<Partido> retorno = new List<Partido>();
            retorno = instancia.MostrarEstadoPartido();

            return View(retorno);
        }

        public IActionResult PartidoDetallado(int id)
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            
            List<Incidencia> inci = instancia.IncidenciaPorPartido(id);
            return View(inci);
        }

        
        public IActionResult PartidoAFinalizar(int id)
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }


            Partido partido = instancia.GetPartidoById(id);
            instancia.FinalizarPartido(id);
            ViewBag.Mensaje = "Partido Finalizado con Éxito - ver Detalle del partido en vistas de estado";
            return View();
        }

        public IActionResult MostrarFinalizado()
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            
            List<Partido> finales = instancia.MostrarEstadoPartido();
            
            return View(finales);
        }

       

        public IActionResult Busqueda(string date1, string date2)
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            
            List<Partido> buscados = instancia.BuscarPartidoFecha(date1, date2);
            
            return View(buscados);
        }

        public IActionResult MostrarPeriodistas()
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            
            List<Periodista> p = instancia.DevolverPeriodistasOrdenados();
            
            return View(p);
        }

        public IActionResult MostrarUnaReseña(string name)
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            
            Usuario unPeriodista = instancia.GetPeriodistaPorEmail(name);

            return View(instancia.GetReseñaPorEmail(unPeriodista.Email));

        }

        public IActionResult Estadistica()
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            
            //string email = HttpContext.Session.GetString("loggedname");

            ViewBag.SeleccionesGoleadoras = instancia.ObtenerSeleccionGoleadora();



            return View(instancia.GetReseñaConRoja());
        }

        [HttpPost]
        public IActionResult Estadistica(string FiltrarEmail)
        {
            if (!CheckLoginOperador())
            {
                return RedirectToAction("Login", "Permiso", new { error = "Por favor corrobore su usuario" });
            }

            ViewBag.SeleccionesGoleadoras = instancia.ObtenerSeleccionGoleadora();
            List<Reseña> Buscada = instancia.ResConTarjetaRoja(FiltrarEmail);

            if (Buscada.Count() == 0)
            {
                ViewBag.msg = "Reseña no encontrada";
            }

            return View(Buscada);
        }
    }
}
