using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generador_de_Documentos_Sanitarios.Models
{
    public class Documento
    {
        public int Id_Documento {get;set;} 

        public string Tipo_Documento { get; set; }

        public int Id_Region { get; set; }
        
        public int Id_Comuna { get; set; }
        
        public string Dv_Usuario { get; set; }
        
        public int Run_Usuario { get; set; }
        
        public DateTime Fecha_Creacion { get; set; }


    }
}
