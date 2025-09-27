using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace MundialWeb.Controllers
{
    public class UsuarioController : Controller
    {
        Sistema Instancia = Sistema.GetInstance();

        private bool CheckLoginUser()
        {

            string rol = HttpContext.Session.GetString("TipoUsuario");
            if (rol == "Operador")
            {
                return false;
            }

            return true;
        }

        public IActionResult Inicio()
        {
            if (!CheckLoginUser())
            {
                return RedirectToAction("MostrarOpciones", "Operador", new { error = "Por favor corrobore su usuario" });
            }
            return View();
        }
        public IActionResult Index()
        {
            List<Seleccion> selecciones = new List<Seleccion>();
            selecciones = Instancia.GetSelecciones();
            selecciones = Instancia.OrdenarSelecciones();
            return View(selecciones);
        }

        
        
        
        public IActionResult Jugadores(string name)
        {
            List<Jugador> jugadores = new List<Jugador>();
            foreach (Jugador j in Instancia.GetJugadores())
            {
                if (j.Pais.Nombre == name)
                {
                    jugadores.Add(j);
                }
            }

            return View(jugadores);

        }

        public IActionResult Permiso()
        {
            return View();
        }
    }
}
