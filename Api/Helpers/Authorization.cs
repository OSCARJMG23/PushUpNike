using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class Authorization
    {
         public enum Roles
        {
            Administrador,
            Cliente
        }
        public const Roles rol_default = Roles.Cliente;
    }
}