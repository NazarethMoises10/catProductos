using catProductos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace catProductos.Controllers
{
    public class ProductosController : ApiController
    {
        private clsProductos objProductos;
        public ProductosController()
        {
            objProductos = new clsProductos();
        }

        [HttpGet]
        public string Consultar()
        {
            return objProductos.Consultar();
        }

        [HttpGet]
        public string Buscar(string pstrValor)
        {
            return objProductos.Buscar(pstrValor);
        }

        [HttpPost]
        public HttpResponseMessage Agregar(string pstrNombre, string pstrUnidadMedida, float pfloatConsumo, 
            int pintInsumo)
        {
            objProductos.strNombre = pstrNombre;
            objProductos.strUnidadMedida = pstrUnidadMedida;
            objProductos.intInsumo = pintInsumo;
            objProductos.floatConsumo = pfloatConsumo;
            string res = objProductos.Agregar(objProductos);

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [HttpPut]
        public HttpResponseMessage Modificar(int pintId, string pstrNombre, string pstrUnidadMedida, float pfloatConsumo,
            int pintInsumo)
        {
            objProductos.intId = pintId;
            objProductos.strNombre = pstrNombre;
            objProductos.strUnidadMedida = pstrUnidadMedida;
            objProductos.intInsumo = pintInsumo;
            objProductos.floatConsumo = pfloatConsumo;
            string res = objProductos.Modificar(objProductos);

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [HttpPut]
        public HttpResponseMessage Habilitar(int pintId)
        {
            string res = objProductos.Habilitar(pintId);

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [HttpDelete]
        public HttpResponseMessage Inhabilitar(int pintId)
        {
            string res = objProductos.Inhabilitar(pintId);

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}