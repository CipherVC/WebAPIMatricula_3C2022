using API.Bll.Contenido.Interfaces;
using API.Dal.General;
using API.Dto.Contenido.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Contenido
{
    internal class AdContenido : IAdContenido
    {
        private ConexionManager manager;

        public AdContenido(IOptions<AppSettings> oConfiguraciones) {
            manager=new ConexionManager(oConfiguraciones);
        }
        public Dto.Contenido.Salida.VerTodosContenidos VerTodosContenidos(){
            IDbConnection oConexion = null;
            API.Dto.Contenido.Salida.VerTodosContenidos resultado = new API.Dto.Contenido.Salida.VerTodosContenidos();
            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();
            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Cursos");



                DatosContenido dato;



                while (objDr.Read())
                {
                    dato = new DatosContenido();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.NombreArchivo = objDr["NombreArchivo"].ToString();
                    dato.Ruta = objDr["Ruta"].ToString();
                    dato.CodigoCarpeta = Convert.ToInt32(objDr["CodigoCarpeta"].ToString());
                    dato.FechaCreacion = DateTime.Parse(objDr["FechaCreacion"].ToString());
                    resultado.ListaContenido.Add(dato);
                }
            }
            catch (Exception)
            {
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }



            return resultado;

        }

        public Dto.Contenido.Salida.VerDetalleContenido VerDetalleContenido(Dto.Contenido.Entrada.VerDetalleContenido pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Contenido.Salida.VerDetalleContenido resultado = new API.Dto.Contenido.Salida.VerDetalleContenido();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Curso");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreArchivo = objDr["NombreArchivo"].ToString();
                    resultado.Ruta = objDr["Ruta"].ToString();
                    resultado.CodigoCarpeta = Convert.ToInt32(objDr["CodigoCarpeta"].ToString());
                    resultado.FechaCreacion = DateTime.Parse(objDr["FechaCreacion"].ToString());

                }
            }
            catch (Exception)
            {
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }



            return resultado;
        }



        public Dto.Contenido.Salida.AgregarContenido AgregarContenido(Dto.Contenido.Entrada.AgregarContenido pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Contenido.Salida.AgregarContenido resultado = new Dto.Contenido.Salida.AgregarContenido();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();




                oComando.Parameters.Add(manager.GetParametro("@NombreArchivo", pInformacion.NombreArchivo));
                oComando.Parameters.Add(manager.GetParametro("@Ruta", pInformacion.Ruta));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCarpeta", pInformacion.CodigoCarpeta));
                oComando.Parameters.Add(manager.GetParametro("@FechaCreacion", pInformacion.FechaCreacion));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Contenido");

                if (objDr.Read()) resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());

            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }


        public Dto.Contenido.Salida.EditarContenido EditarContenido(Dto.Contenido.Entrada.EditarContenido pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Contenido.Salida.EditarContenido resultado = new Dto.Contenido.Salida.EditarContenido();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@NombreArchivo", pInformacion.NombreArchivo));
                oComando.Parameters.Add(manager.GetParametro("@Ruta", pInformacion.Ruta));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCarpeta", pInformacion.CodigoCarpeta));
                oComando.Parameters.Add(manager.GetParametro("@FechaCreacion", pInformacion.FechaCreacion));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Contenido");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreArchivo = objDr["NombreArchivo"].ToString();
                    resultado.Ruta = objDr["Ruta"].ToString();
                    resultado.CodigoCarpeta = Convert.ToInt32(objDr["CodigoCarpeta"].ToString());
                    resultado.FechaCreacion = DateTime.Parse(objDr["FechaCreacion"].ToString());
                }



            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }



            return resultado;
        }



        public Dto.Contenido.Salida.EliminarContenido EliminarContenido(Dto.Contenido.Entrada.EliminarContenido pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Contenido.Salida.EliminarContenido resultado = new Dto.Contenido.Salida.EliminarContenido();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Contenido");
            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }



    }
}
