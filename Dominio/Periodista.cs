using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Periodista : Usuario, IValidacion, IComparable<Periodista>
    {

        public Periodista(string unNombre, string unApellido, string unPassword, string unEmail) : base(unNombre, unApellido, unPassword, unEmail)
        {


            this.Nombre = unNombre;
            this.Apellido = unApellido;
            this.Password = unPassword;
            this.Email = unEmail;
        }

        public Periodista() : base()
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
                throw new Exception("EmailInvalido");

            }
            if (!PasswordEsValida())
            {
                throw new Exception("ContraseñaInvalida");
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

        public override bool Equals(object obj)
        {
            var unPeriodista = obj as Periodista;
            return unPeriodista != null && Email == unPeriodista.Email;
        }

        public override string ToString()
        {
            return $"{Nombre}-{Email}";
        }

        public int CompareTo(Periodista other)
        {
            if (Apellido.CompareTo(other.Apellido) > 0)
            {
                return 1;
            }
            else if (Apellido.CompareTo(other.Apellido) < 0)
            {
                return -1;
            }
            else
            {
                if (Nombre.CompareTo(other.Nombre) < 0)
                {
                    return -1;
                }
                else if (Nombre.CompareTo(other.Nombre) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

}
