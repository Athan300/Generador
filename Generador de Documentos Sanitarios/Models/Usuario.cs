using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generador_de_Documentos_Sanitarios.Models
{
    public class Usuario
    {
        public string Dv_Usuario { get; set; }

        public int Run_Usuario { get; set; }

        public string Nombre_Usuario { get; set; }

        public string Apellido_Paterno_Usuaio { get; set; }

        public string Apellido_Materno_Usuario { get; set; }

        public int Numero_Serie { get; set; }

        public int Edad { get; set; }

        public int IdComuna { get; set; }

        public int IdRegion { get; set; }


    }
}
