using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using Sistemas.Librerias.Utilerias;
using AdminFacturacion.Model;
using System.Data;

namespace AdminFacturacion.Data
{
    public class EmpresaAD
    {

        private Acceso_A_Datos ad;
        private List<parametro_sql> parametros;
        public string Mensaje { get; set; }
        public EmpresaAD()
        {
            ad = new Acceso_A_Datos(ConfigurationManager.ConnectionStrings["Facturacion"].ToString());
        }

        public void Guardar(Empresa obj)
        {
     
            DataTable tabla = new DataTable();
            parametros = new List<parametro_sql>();
            parametros.Add(new parametro_sql("id", obj.IdEmpresa));
            parametros.Add(new parametro_sql("rfc", obj.RFC));

            parametros.Add(new parametro_sql("nombre", obj.Nombre));
            parametros.Add(new parametro_sql("correo", obj.Correo));

            parametros.Add(new parametro_sql("contraseña", obj.Contraseña));
            parametros.Add(new parametro_sql("estatus", obj.Estatus));
          
                
            ad.Procedimiento_Almacenado("Sp_Guardar_Empresa", parametros, false);
            if (ad.Numero_error != 0)
            {
                Mensaje = ad.Descripcion_error;
            }
            
        }

        public List<Empresa> ListeEmpresas()
        {
            List<Empresa> resultado = new List<Empresa>();
            DataTable tabla = new DataTable();
            tabla = ad.Consultas("select * from empresa",true);

            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Empresa
                {
                    IdEmpresa= int.Parse( row["IdEmpresa"].ToString()),
                    RFC = row["RFC"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Correo = row["Correo"].ToString(),
                    Estatus = bool.Parse(row["Estatus"].ToString()),

                });
            }

            return resultado;
        }


    }
}
