using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using System;

namespace MundialWeb.Controllers
{
    public class LoginController : Controller
    {
        
        Sistema Instancia = Sistema.GetInstance();

        private bool CheckLogin()
        {
            return !String.IsNullOrWhiteSpace(HttpContext.Session.GetString("loggedname"));
        }


        public IActionResult Login(string error)
        {
            ViewBag.error = error;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (CheckLogin())
            {
                return RedirectToAction("Login", "Login", new { error = "Por favor inicie sesion." });
            }

            Usuario logueado = Instancia.Login(email ,password);
            if (Instancia.Login(email, password) != null)
            {
                HttpContext.Session.SetString("loggedname", email);
                HttpContext.Session.SetString("TipoUsuario", logueado.GetType().Name);
                if(logueado.GetType().Name == "Periodista")
                {
                    return RedirectToAction("VerOpcionesPeriodista", "Periodista");

                }
                else
                {
                    return RedirectToAction("MostrarOpciones", "Operador");
                }
                
            }
            return RedirectToAction("Login", new { error = "Datos incorrectos" });
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("loggedname", "");
            HttpContext.Session.SetString("TipoUsuario", "");
            return RedirectToAction("Login");

        }

        public IActionResult Register(string error, string alta)
        {
           
            ViewBag.Error = error;
            ViewBag.Alta = alta;
            return View(new Periodista());
        }

        [HttpPost]
        public IActionResult Register(Periodista p)
        {
            //hola
            try
            {
                Instancia.AgregarP(p);
                return RedirectToAction("Register", new { alta = "Registro Correcto" } );
            }
            catch (Exception e)
            {
                return RedirectToAction("Register", new { error = "Registro incorrecto" });
            }
        }

        

    }
}
