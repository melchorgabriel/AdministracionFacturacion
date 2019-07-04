using AdminFacturacion.Data;
using AdminFacturacion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminFacturacion.API.Controllers
{
    public class EmpresasController : ApiController
    {


        EmpresaAD empresasAd;

        public IEnumerable<Empresa> Get()
        {
            empresasAd = new EmpresaAD();
            return  empresasAd.ListeEmpresas();
        }

        // GET: api/Empresas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empresas
        public string Post([FromBody]Empresa value)
        {
            empresasAd = new EmpresaAD();
            empresasAd.Guardar(value);

            return empresasAd.Mensaje;

        }

    }
}
