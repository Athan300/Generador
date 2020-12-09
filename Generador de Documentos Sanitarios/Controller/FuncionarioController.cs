using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generador_de_Documentos_Sanitarios.Asure;
using Generador_de_Documentos_Sanitarios.Models;
using Microsoft.AspNetCore.Mvc;


namespace Generador_de_Documentos_Sanitarios.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariorController : ControllerBase
    {

        // GET: api/<PlantaController>/all
        [HttpGet("all")]
        public JsonResult ObtenerFuncionarios()
        {
            var FuncionariosResividos = FuncionarioAsure.ObtenerFuncionarios();
            return new JsonResult(FuncionariosResividos);
        }

    }
}
