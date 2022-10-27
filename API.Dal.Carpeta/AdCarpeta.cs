using API.Bll.Carpeta.Interfaces;
using API.Dal.General;
using API.Dto.Carpeta.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Carpeta
{
    public class AdCarpeta:IAdCarpeta
    {
        private ConexionManager manager;



        public AdCarpeta(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }



        public Dto.Carpeta.Salida.VerTodosCarpeta VerTodosCarpeta()
        {
            IDbConnection oConexion = null;
            API.Dto.Carpeta.Salida.VerTodosCarpeta resultado = new API.Dto.Carpeta.Salida.VerTodosCarpeta();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Carpetas");



                DatosCarpeta dato;



                while (objDr.Read())
                {
                    dato = new DatosCarpeta();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Nombre = objDr["Nombre"].ToString();
                    dato.FechaCreacion = DateTime.Parse(objDr["FechaCreacion"].ToString());
                    dato.VisibleEstudiantes = objDr["VisibleEstudiantes"].ToString();
                    dato.CodigoCurso = Int32.Parse(objDr["CodigoCurso"].ToString());



                    resultado.ListaCarpeta.Add(dato);
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



        public Dto.Carpeta.Salida.VerDetalleCarpeta VerDetalleCarpeta(Dto.Carpeta.Entrada.VerDetalleCarpeta pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Carpeta.Salida.VerDetalleCarpeta resultado = new API.Dto.Carpeta.Salida.VerDetalleCarpeta();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Carpeta");



                if (objDr.Read())
                {
                    
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.FechaCreacion = DateTime.Parse(objDr["FechaCreacion"].ToString());
                    resultado.VisibleEstudiantes = objDr["VisibleEstudiantes"].ToString();
                    resultado.CodigoCurso = Int32.Parse(objDr["CodigoCurso"].ToString());
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
        public Dto.Carpeta.Salida.AgregarCarpeta AgregarCarpeta(Dto.Carpeta.Entrada.AgregarCarpeta pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Carpeta.Salida.AgregarCarpeta resultado = new Dto.Carpeta.Salida.AgregarCarpeta();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso)); 
                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre)); 
                oComando.Parameters.Add(manager.GetParametro("@FechaCreacion", pInformacion.FechaCreacion)); 
                oComando.Parameters.Add(manager.GetParametro("@VisibleEstudiantes", pInformacion.VisibleEstudiantes));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Carpeta");

                if (objDr.Read()) resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());

            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }
        public Dto.Carpeta.Salida.EditarCarpeta EditarCarpeta(Dto.Carpeta.Entrada.EditarCarpeta pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Carpeta.Salida.EditarCarpeta resultado = new Dto.Carpeta.Salida.EditarCarpeta();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();





                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@FechaCreacion", pInformacion.FechaCreacion));
                oComando.Parameters.Add(manager.GetParametro("@VisibleEstudiantes", pInformacion.VisibleEstudiantes));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Carpeta");



                if (objDr.Read())
                {





                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.FechaCreacion = DateTime.Parse(objDr["FechaCreacion"].ToString());
                    resultado.VisibleEstudiantes = objDr["VisibleEstudiantes"].ToString();
                    resultado.CodigoCurso = Int32.Parse(objDr["CodigoCurso"].ToString());
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

        public Dto.Carpeta.Salida.EliminarCarpeta EliminarCarpeta(Dto.Carpeta.Entrada.EliminarCarpeta pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Carpeta.Salida.EliminarCarpeta resultado = new Dto.Carpeta.Salida.EliminarCarpeta();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Carpeta");
            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }
    }
}
