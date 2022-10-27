﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Contenido.Entrada
{
    public class EditarContenido:General.EntradaAPI
    {    
        public int Codigo { get; set; }
        public string NombreArchivo { get; set; }
        public string Ruta { get; set; }
        public string CodigoCarpeta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}