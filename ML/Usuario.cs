﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string EstadoNacimiento { get; set; }

        //public ML.EstadoNacimiento EstadoNacimiento { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string CURP { get; set; }

        public List<object> Usuarios { get; set; }
    }
}