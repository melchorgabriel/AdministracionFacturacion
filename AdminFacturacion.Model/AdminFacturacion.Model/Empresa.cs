using System;
using System.Collections.Generic;
using System.Text;

namespace AdminFacturacion.Model
{
    public class Empresa

    {

        private string _Password;

        public int IdEmpresa { get; set; }
        public string RFC { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public bool Estatus  { get; set; }

    }


}
