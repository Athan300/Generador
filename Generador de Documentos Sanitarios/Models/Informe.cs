using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generador_de_Documentos_Sanitarios.Models
{
    public class Informe
    {
        public int Id_Informe { get; set; }
        public int Run_funcionario { get; set; }
        public int Id_Documento { get; set; }
        public int Id_Region { get; set; }
        public int Id_Comuna { get; set; }
        public int Edad { get; set; }
    }
}
