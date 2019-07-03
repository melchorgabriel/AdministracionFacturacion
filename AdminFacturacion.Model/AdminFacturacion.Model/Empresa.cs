using System;
using System.Collections.Generic;
using System.Text;

namespace AdminFacturacion.Model
{
    public class Empresa

    {

        private string _Password;

        public int IdEmpresa { get; set; }
        public int RFC { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { set {_Password= value; } }
        public bool Estatus  { get; set; }

        public DatosFicales DatosFicales;

    }


}
