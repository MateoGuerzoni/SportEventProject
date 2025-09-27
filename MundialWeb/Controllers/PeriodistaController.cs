using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace MundialWeb.Controllers
{
    public class PeriodistaController : Controller
    {
        Sistema Instancia = Sistema.GetInstance();

        private bool CheckLoginPeriodista()
        {

            string rol = HttpContext.Session.GetString("TipoUsuario");
            if (rol == "Periodista")
            {
                return true;
            }

            return false;
        }

        
        
        public IActionResult InicioPeriodista()
        {
            if (!CheckLoginPeriodista())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            return View();
        } 

        public IActionResult VerOpcionesPeriodista()
        {
            if (!CheckLoginPeriodista())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            return View();
        }

        public IActionResult VistaPartidosFinalizados()
        {
            if (!CheckLoginPeriodista())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            return View(Instancia.GetPartidos());
        }
        public IActionResult HacerReseña(int id, string error, string alta)
        {
            if (!CheckLoginPeriodista())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }

            ViewBag.error = error;
            ViewBag.Alta = alta;
            @ViewBag.IdPartido = id;
            return View(new Reseña());
        }
        [HttpPost]
        public IActionResult HacerReseña(Reseña unaReseña, int id)
        {
            if (!CheckLoginPeriodista())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            string email = HttpContext.Session.GetString("loggedname");
            Periodista unPeriodista = Instancia.GetPeriodistaPorEmail(email);
            Partido unPartido = Instancia.GetPartidoById(id);
            unaReseña.Partido = unPartido;
            unaReseña.Periodista = unPeriodista;
            unaReseña.Fecha = DateTime.Now;
            try
            {
                if (Instancia.ExisteReseña(unaReseña) == false)
                {
                    ViewBag.error = "Ya existe una reseña de este partido";
                }else if (unaReseña.Titulo == null || unaReseña.Contenido == null)
                {
                    ViewBag.error = "Reseña no puedo tener campos vacios";
                }else
                {
                    Instancia.AgregarReseña(unaReseña);
                    
                    return RedirectToAction("HacerReseña", "Periodista", new { alta = "Reseña exitosa"});
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Periodista", "HacerReseña", new {error = "Datos incorrectos de reseña"});
            }
            return View(/*"VerOpcionesPeriodista"*/);
        }

        public IActionResult FiltrarReseña()
        {
            if (!CheckLoginPeriodista())
            {
                return RedirectToAction("Permiso", "Usuario", new { error = "Por favor corrobore su usuario" });
            }
            string email = HttpContext.Session.GetString("loggedname");
            Usuario unPeriodista = Instancia.GetPeriodistaPorEmail(email);
            
            return View(Instancia.GetReseñaPorEmail(unPeriodista.Email));
        }
    }
}
