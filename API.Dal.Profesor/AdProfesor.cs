using API.Bll.Profesor.Interfaces;
using API.Dal.General;
using API.Dto.General;
using API.Dto.Profesor.Salida;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Profesor
{
    public class AdProfesor : IAdProfesor
    {
        private ConexionManager manager;



        public AdProfesor(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }



        public Dto.Profesor.Salida.VerTodosProfesores VerTodosProfesores()
        {
            IDbConnection oConexion = null;
            API.Dto.Profesor.Salida.VerTodosProfesores resultado = new API.Dto.Profesor.Salida.VerTodosProfesores();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Profesores");



                DatosProfesor dato;



                while (objDr.Read())
                {
                    dato = new DatosProfesor();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Identificacion = objDr["Identificacion"].ToString();
                    dato.NombreCompleto = objDr["NombreCompleto"].ToString();
                    dato.Especialidad = objDr["Especialidad"].ToString();
                    dato.Telefono = objDr["Telefono"].ToString();
                    dato.Direccion = objDr["Direccion"].ToString();
                    dato.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    dato.CodigoDepartamento = Convert.ToInt32(objDr["CodigoDepartamento"].ToString());



                    resultado.ListaProfesores.Add(dato);
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



        public Dto.Profesor.Salida.VerDetalleProfesor VerDetalleProfesor(Dto.Profesor.Entrada.VerDetalleProfesor pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Profesor.Salida.VerDetalleProfesor resultado = new API.Dto.Profesor.Salida.VerDetalleProfesor();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Profesor");



                if (objDr.Read())
                {

                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Identificacion = objDr["Identificacion"].ToString();
                    resultado.NombreCompleto = objDr["NombreCompleto"].ToString();
                    resultado.Especialidad = objDr["Especialidad"].ToString();
                    resultado.Telefono = objDr["Telefono"].ToString();
                    resultado.Direccion = objDr["Direccion"].ToString();
                    resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    resultado.CodigoDepartamento = Convert.ToInt32(objDr["CodigoDepartamento"].ToString());

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
        public Dto.Profesor.Salida.AgregarProfesor AgregarProfesor(Dto.Profesor.Entrada.AgregarProfesor pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Profesor.Salida.AgregarProfesor resultado = new Dto.Profesor.Salida.AgregarProfesor();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Identificacion", pInformacion.Identificacion)); 
                oComando.Parameters.Add(manager.GetParametro("@NombreCompleto", pInformacion.NombreCompleto)); 
                oComando.Parameters.Add(manager.GetParametro("@Especialidad", pInformacion.Especialidad)); 
                oComando.Parameters.Add(manager.GetParametro("@Telefono", pInformacion.Telefono));
                oComando.Parameters.Add(manager.GetParametro("@Direccion", pInformacion.Direccion));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
                oComando.Parameters.Add(manager.GetParametro("@CodigoDepartamento", pInformacion.CodigoDepartamento));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Profesor");

                if (objDr.Read()) resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());

            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }
        public Dto.Profesor.Salida.EditarProfesor EditarProfesor(Dto.Profesor.Entrada.EditarProfesor pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Profesor.Salida.EditarProfesor resultado = new Dto.Profesor.Salida.EditarProfesor();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Identificacion", pInformacion.Identificacion));
                oComando.Parameters.Add(manager.GetParametro("@NombreCompleto", pInformacion.NombreCompleto));
                oComando.Parameters.Add(manager.GetParametro("@Especialidad", pInformacion.Especialidad));
                oComando.Parameters.Add(manager.GetParametro("@Telefono", pInformacion.Telefono));
                oComando.Parameters.Add(manager.GetParametro("@Direccion", pInformacion.Direccion));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
                oComando.Parameters.Add(manager.GetParametro("@CodigoDepartamento", pInformacion.CodigoDepartamento));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Profesor");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Identificacion = objDr["Identificacion"].ToString();
                    resultado.NombreCompleto = objDr["NombreCompleto"].ToString();
                    resultado.Especialidad = objDr["Especialidad"].ToString();
                    resultado.Telefono = objDr["Telefono"].ToString();
                    resultado.Direccion = objDr["Direccion"].ToString();
                    resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    resultado.CodigoDepartamento = Convert.ToInt32(objDr["CodigoDepartamento"].ToString());
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

        public Dto.Profesor.Salida.EliminarProfesor EliminarProfesor(Dto.Profesor.Entrada.EliminarProfesor pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Profesor.Salida.EliminarProfesor resultado = new Dto.Profesor.Salida.EliminarProfesor();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Profesor");
            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }
    }
}