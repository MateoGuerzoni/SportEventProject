using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Operador: Usuario,IValidacion
    {
        
        
       
        public DateTime Ingreso { get; set; }

        public Operador(string unNombre, string unApellido,  string unPassword, string unEmail, DateTime ingreso) :base(unNombre, unApellido, unPassword, unEmail)
        {
        
            this.Nombre = unNombre;
            this.Apellido = unApellido;
            this.Email = unEmail;
            this.Password = unPassword;
            this.Ingreso = ingreso;
        }

        public Operador() : base()
        {
           
        }
        public virtual void EsValido()
        {
            if (Nombre.Equals(""))
            {
                throw new Exception("El nombre no puede ser vacio");

            }
            if (Apellido.Equals(""))
            {
                throw new Exception("El apellido no puede ser vacio");

            }

            if (!EmailEsValido())
            {
                throw new Exception("El email es invalido");

            }
            if (!PasswordEsValida())
            {
                throw new Exception("La contraseña es invalida");
            }
            if (Ingreso.Equals(""))
            {
                throw new Exception("El ingreso no puede ser vacio");
            }
        }

        private bool EmailEsValido()
        {
            bool cumple = true;
            if (Email.LastIndexOf("@") == Email.Length - 1 || Email.IndexOf("@") == 0 || Email.IndexOf("@") == -1)
            {
                cumple = false;

            }

            return cumple;
        }

        private bool PasswordEsValida()
        {
            bool cumple = true;
            if (Password.Length < 8)
            {
                cumple = false;
            }
            return cumple;
        }
    }
}
