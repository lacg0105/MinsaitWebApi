using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinsaitWebApi.Models;
using MinsaitWebApi.Models.ViewModel;

namespace MinsaitWebApi.DAL
{
    public class ContactoClientesDAL
    {
        public static List<ContactoClientesVM> ObtenerContactoClientes()
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    var lstcliente = (from cc in dataBaseContext.ContactosCliente
                                      join c in dataBaseContext.Clientes on cc.IdCliente equals c.IdCliente
                                      select new ContactoClientesVM
                                      {
                                          IdContactoCliente = cc.IdContactoCliente,
                                          IdCliente = cc.IdCliente,
                                          NombreCliente = c.NombreCliente,
                                          NumeroContacto = cc.NumeroContacto,
                                          PuestoContacto = cc.PuestoContacto,
                                          CorreoContacto = cc.CorreoContacto,
                                          NombreContacto = cc.NombreContacto
                                      }).ToList<ContactoClientesVM>();

                    return lstcliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //--------------------------------------------------------------------------------------------
        public static ContactoClientesVM ObtenerContactoClientexId(int intIdContactoCliente)
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    var cliente = (from c in dataBaseContext.ContactosCliente
                                   where c.IdContactoCliente == intIdContactoCliente
                                   select new ContactoClientesVM
                                   {
                                       IdContactoCliente = c.IdContactoCliente,
                                       IdCliente = c.IdCliente,
                                       NumeroContacto = c.NumeroContacto,
                                       PuestoContacto = c.PuestoContacto,
                                       CorreoContacto = c.CorreoContacto,
                                       NombreContacto = c.NombreContacto
                                   }).FirstOrDefault();

                    return cliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //--------------------------------------------------------------------------------------------
    }
}