﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Contenido.Entrada
{
    public class AgregarContenido:General.EntradaAPI
    {
        public string NombreArchivo { get; set; }
        public string Contenido { get; set; }
        public int CodigoCarpeta { get; set; }
        public DateTime FechaCreacion { get; set;  }
    }
}
