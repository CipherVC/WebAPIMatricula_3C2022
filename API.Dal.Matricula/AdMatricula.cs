using API.Bll.Matricula.Interfaces;
using API.Dal.General;
using API.Dto.Matricula.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Dal.Matricula
{
    public class AdMatricula : IAdMatricula
    {
        private ConexionManager manager;



        public AdMatricula(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }



        public Dto.Matricula.Salida.VerTodasMatriculas VerTodasMatriculas()
        {
            IDbConnection oConexion = null;
            API.Dto.Matricula.Salida.VerTodasMatriculas resultado = new API.Dto.Matricula.Salida.VerTodasMatriculas();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todas_Matriculas");



                DatosMatricula dato;



                while (objDr.Read())
                {
                    dato = new DatosMatricula();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.CodigoUsuario = Convert.ToInt32(objDr["CodigoUsuario"].ToString());
                    dato.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    dato.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    dato.FechaHora = Convert.ToDateTime(objDr["FechaHora"].ToString());



                    resultado.ListaMatriculas.Add(dato);
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



        public Dto.Matricula.Salida.VerDetalleMatricula VerDetalleMatricula(Dto.Matricula.Entrada.VerDetalleMatricula pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Matricula.Salida.VerDetalleMatricula resultado = new API.Dto.Matricula.Salida.VerDetalleMatricula();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Matricula");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.CodigoUsuario = Convert.ToInt32(objDr["CodigoUsuario"].ToString());
                    resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    resultado.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    resultado.FechaHora = Convert.ToDateTime(objDr["FechaHora"].ToString());
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
        public Dto.Matricula.Salida.AgregarMatricula AgregarMatricula(Dto.Matricula.Entrada.AgregarMatricula pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Matricula.Salida.AgregarMatricula resultado = new Dto.Matricula.Salida.AgregarMatricula();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@CodigoUsuario", pInformacion.CodigoUsuario));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
                oComando.Parameters.Add(manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
                oComando.Parameters.Add(manager.GetParametro("@FechaHora", pInformacion.FechaHora));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Matricula");

                if (objDr.Read()) resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());

            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }
        public Dto.Matricula.Salida.EditarMatricula EditarMatricula(Dto.Matricula.Entrada.EditarMatricula pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Matricula.Salida.EditarMatricula resultado = new Dto.Matricula.Salida.EditarMatricula();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@CodigoUsuario", pInformacion.CodigoUsuario));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
                oComando.Parameters.Add(manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
                oComando.Parameters.Add(manager.GetParametro("@FechaHora", pInformacion.FechaHora));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Matricula");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.CodigoUsuario = Convert.ToInt32(objDr["CodigoUsuario"].ToString());
                    resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    resultado.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    resultado.FechaHora = Convert.ToDateTime(objDr["FechaHora"].ToString());
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

        public Dto.Matricula.Salida.EliminarMatricula EliminarMatricula(Dto.Matricula.Entrada.EliminarMatricula pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Matricula.Salida.EliminarMatricula resultado = new Dto.Matricula.Salida.EliminarMatricula();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Matricula");
            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }
    }
}