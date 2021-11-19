using MinsaitWebApi.Models;
using MinsaitWebApi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinsaitWebApi.DAL
{
    public static class ClientesDAL
    {
        public static ClientesVM ObtenerCliente(ClientesVM _VM)
        {
            try
            {
                if (_VM != null)
                {
                    using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                    {
                        var lstCliente = (from c in dataBaseContext.Clientes
                                          where c.NombreCliente == _VM.NombreCliente &&
                                                c.IdPais == _VM.IdPais &&
                                                c.IdMercado == _VM.IdMercado &&
                                                c.IdentificadorFiscal == _VM.IdentificadorFiscal &&
                                                c.Email == _VM.Email
                                          select new ClientesVM
                                          {
                                              IdCliente = c.IdCliente,
                                              IdPais = c.IdPais,
                                              IdMercado = c.IdMercado,
                                              NombreCliente = c.NombreCliente,
                                              IdentificadorFiscal = c.IdentificadorFiscal,
                                              Email = c.Email
                                          }).ToList<ClientesVM>();
                        if (lstCliente.Count == 1)
                        {
                            foreach (var item in lstCliente)
                            {
                                var cliente = new ClientesVM()
                                {
                                    IdCliente = item.IdCliente,
                                    IdPais = item.IdPais,
                                    IdMercado = item.IdMercado,
                                    NombreCliente = item.NombreCliente,
                                    IdentificadorFiscal = item.IdentificadorFiscal,
                                    Email = item.Email
                                };
                                return cliente;
                            }
                        }
                    }
                }
                return new ClientesVM();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //--------------------------------------------------------------------------------------------
        public static ClientesVM ObtenerClientexId(int IdCliente)
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    var cliente = (from c in dataBaseContext.Clientes
                                   where c.IdCliente == IdCliente
                                   select new ClientesVM
                                   {
                                       IdCliente = c.IdCliente,
                                       IdPais = c.IdPais,
                                       IdMercado = c.IdMercado,
                                       NombreCliente = c.NombreCliente,
                                       IdentificadorFiscal = c.IdentificadorFiscal,
                                       Email = c.Email
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
        public static List<ClientesVM> ObtenerCarteraClientes()
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    var lstcliente = (from c in dataBaseContext.Clientes
                                      join p in dataBaseContext.CatPais on c.IdPais equals p.IdPais
                                      join m in dataBaseContext.CatMercado on c.IdMercado equals m.IdMercado
                                      select new ClientesVM
                                      {
                                          IdCliente = c.IdCliente,
                                          IdPais = c.IdPais,
                                          IdMercado = c.IdMercado,
                                          NombreCliente = c.NombreCliente,
                                          IdentificadorFiscal = c.IdentificadorFiscal,
                                          Email = c.Email,
                                          NombrePais = p.NombrePais,
                                          NombreMercado = m.NombreMercado
                                      }).ToList<ClientesVM>();

                    return lstcliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //--------------------------------------------------------------------------------------------
        public static List<CatPaisesVM> ObtenerPaises()
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    var lstcliente = (from p in dataBaseContext.CatPais
                                      select new CatPaisesVM
                                      {
                                          IdPais = p.IdPais,
                                          NombrePais = p.NombrePais
                                      }).ToList<CatPaisesVM>();

                    return lstcliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //--------------------------------------------------------------------------------------------
        public static List<CatMercadosVM> ObtenerMercados()
        {
            try
            {
                using (MinsaitEntities dataBaseContext = new MinsaitEntities())
                {
                    var lstcliente = (from m in dataBaseContext.CatMercado
                                      select new CatMercadosVM
                                      {
                                          IdMercado = m.IdMercado,
                                          NombreMercado = m.NombreMercado
                                      }).ToList<CatMercadosVM>();

                    return lstcliente;
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