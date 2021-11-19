using MinsaitWebApi.DAL;
using MinsaitWebApi.Models;
using MinsaitWebApi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Minsait.Controllers
{
    public class ClientesController : ApiController
    {
        [Route("Api/Clientes/AddCliente")]
        [HttpPost]
        public IHttpActionResult AddCliente(ClientesVM _VM)
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    var Cliente = ClientesDAL.ObtenerCliente(_VM);

                    if (Cliente.IdCliente == 0)
                    {
                        Clientes NuevoCliente = new Clientes()
                        {
                            IdCliente = _VM.IdCliente,
                            IdPais = _VM.IdPais,
                            IdMercado = _VM.IdMercado,
                            NombreCliente = _VM.NombreCliente,
                            IdentificadorFiscal = _VM.IdentificadorFiscal,
                            Email = _VM.Email
                        };
                        dataBaseContext.Clientes.Add(NuevoCliente);
                        dataBaseContext.SaveChanges();
                        return Ok("1");
                    }
                    else
                        return Ok("2");

                }
            }
            catch (Exception ex)
            {
                return Ok("0");
            }
        }
        //--------------------------------------------------------------------------------------------
        [Route("Api/Clientes/ObtenerClientexId")]
        [HttpPost]
        public IHttpActionResult ObtenerClientexId(string IdCliente)
        {
            using (MinsaitEntities dataBaseContext = new MinsaitEntities())
            {
                int intIdCliente = Convert.ToInt32(IdCliente);
                var Cliente = ClientesDAL.ObtenerClientexId(intIdCliente);

                if (Cliente == null)
                    return Ok("El cliente no está registrado.");
                else
                    return Ok(Cliente);

            }
        }
        //--------------------------------------------------------------------------------------------
        [Route("Api/Clientes/ObtenerCarteraClientes")]
        [HttpGet]
        public IHttpActionResult ObtenerCarteraClientes()
        {
            var lstCliente = ClientesDAL.ObtenerCarteraClientes();

            if (lstCliente.Count == 0)
                return Ok("No hay clientes registrados");
            else
                return Ok(lstCliente);


            //return Ok("Ok");
        }
        //--------------------------------------------------------------------------------------------
        [Route("Api/Clientes/GetCliente")]
        [HttpGet]
        public IHttpActionResult GetCliente(ClientesVM _VM)
        {
            var Cliente = ClientesDAL.ObtenerCliente(_VM);
            return Ok(Cliente);


            //return Ok("Ok");
        }
        //--------------------------------------------------------------------------------------------
        [Route("Api/Clientes/ObtenerPaises")]
        [HttpGet]
        public IHttpActionResult ObtenerPaises()
        {
            var Cliente = ClientesDAL.ObtenerPaises();
            return Ok(Cliente);


            //return Ok("Ok");
        }
        //--------------------------------------------------------------------------------------------
        [Route("Api/Clientes/ObtenerMercados")]
        [HttpGet]
        public IHttpActionResult ObtenerMercados()
        {
            var Cliente = ClientesDAL.ObtenerMercados();
            return Ok(Cliente);
        }
        //--------------------------------------------------------------------------------------------
        [Route("Api/Clientes/ModificarCliente")]
        [HttpPut]
        public IHttpActionResult ModificarCliente(ClientesVM _VM)
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    //var Cliente = ClientesDAL.ObtenerClientexId(_VM.IdCliente);
                    var Cliente = dataBaseContext.Clientes.Where(x => x.IdCliente == _VM.IdCliente).FirstOrDefault();

                    if (Cliente != null)
                    {

                        Cliente.IdCliente = _VM.IdCliente;
                        Cliente.IdPais = _VM.IdPais;
                        Cliente.IdMercado = _VM.IdMercado;
                        Cliente.NombreCliente = _VM.NombreCliente;
                        Cliente.IdentificadorFiscal = _VM.IdentificadorFiscal;
                        Cliente.Email = _VM.Email;
                        dataBaseContext.SaveChanges();
                        return Ok("1");
                    }
                    else
                        return Ok("2");

                }
            }
            catch (Exception ex)
            {
                return Ok("0");
            }
        }
        //--------------------------------------------------------------------------------------------
    }
}
