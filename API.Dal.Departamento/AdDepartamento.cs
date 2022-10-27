using API.Bll.Departamento.Interfaces;
using API.Dal.General;
using API.Dto.Departamento.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Departamento
{
    public class AdDepartamento : IAdDepartamento
    {
        private ConexionManager manager;



        public AdDepartamento(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }



        public Dto.Departamento.Salida.VerTodosDepartamentos VerTodosDepartamentos()
        {
            IDbConnection oConexion = null;
            API.Dto.Departamento.Salida.VerTodosDepartamentos resultado = new API.Dto.Departamento.Salida.VerTodosDepartamentos();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Departamentos");



                DatosDepartamento dato;



                while (objDr.Read())
                {
                    dato = new DatosDepartamento();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.NombreDepartamento = objDr["NombreDepartamento"].ToString();
                    dato.DescripcionDepartamento = objDr["DescripcionDepartamento"].ToString();
                    dato.DirectorDepartamento = objDr["DirectorDepartamento"].ToString();
                    dato.Telefono = objDr["Telefono"].ToString();



                    resultado.ListaDepartamentos.Add(dato);
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



        public Dto.Departamento.Salida.VerDetalleDepartamento VerDetalleDepartamento(Dto.Departamento.Entrada.VerDetalleDepartamento pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Departamento.Salida.VerDetalleDepartamento resultado = new API.Dto.Departamento.Salida.VerDetalleDepartamento();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Departamento");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreDepartamento = objDr["NombreDepartamento"].ToString();
                    resultado.DescripcionDepartamento = objDr["DescipcionDepartamento"].ToString();
                    resultado.DirectorDepartamento = objDr["DirectorDepartamento"].ToString();
                    resultado.Telefono = objDr["Telefono"].ToString();
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
        public Dto.Departamento.Salida.AgregarDepartamento AgregarDepartamento(Dto.Departamento.Entrada.AgregarDepartamento pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Departamento.Salida.AgregarDepartamento resultado = new Dto.Departamento.Salida.AgregarDepartamento();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@NombreDepartamento", pInformacion.NombreDepartamento)); oComando.Parameters.Add(manager.GetParametro("@DescripcionDepartamento", pInformacion.DescripcionDepartamento)); oComando.Parameters.Add(manager.GetParametro("@DirectorDepartamento", pInformacion.DirectorDepartamento)); oComando.Parameters.Add(manager.GetParametro("@Telefono", pInformacion.Telefono));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Departamento");

                if (objDr.Read()) resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());

            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }
        public Dto.Departamento.Salida.EditarDepartamento EditarDepartamento(Dto.Departamento.Entrada.EditarDepartamento pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Departamento.Salida.EditarDepartamento resultado = new Dto.Departamento.Salida.EditarDepartamento();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@NombreDepartamento", pInformacion.NombreDepartamento));
                oComando.Parameters.Add(manager.GetParametro("@DescripcionDepartamento", pInformacion.DescripcionDepartamento));
                oComando.Parameters.Add(manager.GetParametro("@DirectorDepartamento", pInformacion.DirectorDepartamento));
                oComando.Parameters.Add(manager.GetParametro("@Telefono", pInformacion.Telefono));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Departamento");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreDepartamento = objDr["NombreDepartamento"].ToString();
                    resultado.DescripcionDepartamento = objDr["DescripcionDepartamento"].ToString();
                    resultado.DirectorDepartamento = objDr["DirectorDepartamento"].ToString();
                    resultado.Telefono = objDr["Telefono"].ToString();
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

        public Dto.Departamento.Salida.EliminarDepartamento EliminarDepartamento(Dto.Departamento.Entrada.EliminarDepartamento pInformacion)
        {
            IDbConnection oConexion = null; IDbCommand oComando = manager.GetComando(); Dto.Departamento.Salida.EliminarDepartamento resultado = new Dto.Departamento.Salida.EliminarDepartamento();

            try
            {
                oConexion = manager.GetConexion(); oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Departamento");
            }
            catch (Exception ex) { resultado.DetalleRespuesta = ex.Message; manager.CerrarConexion(oConexion); }
            finally { manager.CerrarConexion(oConexion); }

            return resultado;
        }
    }
}