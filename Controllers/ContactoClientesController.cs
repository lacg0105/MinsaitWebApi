using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinsaitWebApi.DAL;
using System.Web.Http;
using MinsaitWebApi.Models.ViewModel;
using MinsaitWebApi.Models;

namespace MinsaitWebApi.Controllers
{
    public class ContactoClientesController : ApiController
    {
        [Route("Api/ContactoClientes/ObtenerContactoClientes")]
        [HttpGet]
        public IHttpActionResult ObtenerContactoClientes()
        {
            var lstContacto = ContactoClientesDAL.ObtenerContactoClientes();

            if (lstContacto.Count == 0)
                return Ok("No hay clientes registrados");
            else
                return Ok(lstContacto);

        }
        //--------------------------------------------------------------------------------------------
        [Route("Api/ContactoClientes/ObtenerContactoClientexId")]
        [HttpPost]
        public IHttpActionResult ObtenerContactoClientexId(string IdContactoCliente)
        {
            int intIdContactoCliente = Convert.ToInt32(IdContactoCliente);
            var Contacto = ContactoClientesDAL.ObtenerContactoClientexId(intIdContactoCliente);

            if (Contacto == null)
                return Ok("El cliente no está registrado.");
            else
                return Ok(Contacto);

        }
        //--------------------------------------------------------------------------------------------
        [Route("Api/ContactoClientes/AddContacto")]
        [HttpPost]
        public IHttpActionResult AddContacto(ContactoClientesVM _VM)
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    if (_VM.IdCliente > 0)
                    {
                        ContactosCliente NuevoContacto = new ContactosCliente()
                        {
                            IdCliente = _VM.IdCliente,
                            NombreContacto = _VM.NombreContacto,
                            PuestoContacto = _VM.PuestoContacto,
                            CorreoContacto = _VM.CorreoContacto,
                            NumeroContacto = _VM.NumeroContacto,
                        };
                        dataBaseContext.ContactosCliente.Add(NuevoContacto);
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
        [Route("Api/ContactoClientes/ModificarContactoCliente")]
        [HttpPut]
        public IHttpActionResult ModificarContactoCliente(ContactoClientesVM _VM)
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    //var Cliente = ClientesDAL.ObtenerClientexId(_VM.IdCliente);
                    var ContactoCliente = dataBaseContext.ContactosCliente.Where(x => x.IdContactoCliente == _VM.IdContactoCliente).FirstOrDefault();

                    if (ContactoCliente != null)
                    {

                        ContactoCliente.IdCliente = _VM.IdCliente;
                        ContactoCliente.NombreContacto = _VM.NombreContacto;
                        ContactoCliente.PuestoContacto = _VM.PuestoContacto;
                        ContactoCliente.CorreoContacto = _VM.CorreoContacto;
                        ContactoCliente.NumeroContacto = _VM.NumeroContacto;
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