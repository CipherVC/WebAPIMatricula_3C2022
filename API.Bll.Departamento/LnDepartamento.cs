using API.Bll.Departamento.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Departamento
{
    public class LnDepartamento
    {
        private IAdDepartamento adDepartamento;



        public LnDepartamento(IAdDepartamento accesoDatosDepartamento)
        {
            this.adDepartamento = accesoDatosDepartamento;
        }



        public API.Dto.Departamento.Salida.VerTodosDepartamentos VerTodosDepartamentos(Dto.Departamento.Entrada.VerTodosDepartamentos pInformacion)
        {
            API.Dto.Departamento.Salida.VerTodosDepartamentos respuesta = new API.Dto.Departamento.Salida.VerTodosDepartamentos();



            try
            {
                respuesta = adDepartamento.VerTodosDepartamentos();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Departamento.Salida.VerDetalleDepartamento VerDetalleDepartamento(Dto.Departamento.Entrada.VerDetalleDepartamento pInformacion)
        {
            API.Dto.Departamento.Salida.VerDetalleDepartamento respuesta = new Dto.Departamento.Salida.VerDetalleDepartamento();



            try
            {
                respuesta = adDepartamento.VerDetalleDepartamento(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Departamento.Salida.AgregarDepartamento AgregarDepartamento(Dto.Departamento.Entrada.AgregarDepartamento pInformacion)
        {
            API.Dto.Departamento.Salida.AgregarDepartamento respuesta = new API.Dto.Departamento.Salida.AgregarDepartamento();



            try
            {
                respuesta = adDepartamento.AgregarDepartamento(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Departamento.Salida.EditarDepartamento EditarDepartamento(Dto.Departamento.Entrada.EditarDepartamento pInformacion)
        {
            API.Dto.Departamento.Salida.EditarDepartamento respuesta = new API.Dto.Departamento.Salida.EditarDepartamento();



            try
            {
                API.Dto.Departamento.Entrada.VerDetalleDepartamento entradaVerDetalleDepartamento = new API.Dto.Departamento.Entrada.VerDetalleDepartamento();
                entradaVerDetalleDepartamento.Codigo = pInformacion.Codigo;
                API.Dto.Departamento.Salida.VerDetalleDepartamento detalleTrader = adDepartamento.VerDetalleDepartamento(entradaVerDetalleDepartamento);



                respuesta = adDepartamento.EditarDepartamento(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Departamento.Salida.EliminarDepartamento EliminarDepartamento(Dto.Departamento.Entrada.EliminarDepartamento pInformacion)
        {
            API.Dto.Departamento.Salida.EliminarDepartamento respuesta = new Dto.Departamento.Salida.EliminarDepartamento();



            try
            {
                respuesta = adDepartamento.EliminarDepartamento(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
    }
}