using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{

    public abstract class Usuario : IValidacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public static int UltimoId { get; set; }


        public Usuario(string unNombre, string unApellido, string unPassword,string unEmail)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = unNombre;
            this.Apellido = unApellido;
            this.Password = unPassword;
            this.Email = unEmail;
        }

        public Usuario() : base()
        {
            this.Id = UltimoId;
            UltimoId++;
        }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
