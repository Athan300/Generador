using System;
using Xunit;
using System.Linq;
using Generador_de_Documentos_Sanitarios.Asure;
using Generador_de_Documentos_Sanitarios.Models;
using System.Numerics;

namespace XUnitTestDocumento
{
    public class UnitTestFuncionario
    {
        [Fact]
        public void TestObtenerDocumentos()
        {
            //Arrange
            bool vieneConDatos = false;

            //Act
            var resultado = FuncionarioAsure.ObtenerFuncionarios();
            vieneConDatos = resultado.Any();

            //Assert 
            Assert.True(vieneConDatos);
        }

        [Fact]
        public void TestObtenerFuncionariosPorRun()
        {
            //Arrange
            int runProbar = 11111111;
            Funcionario FuncionarioRetornado;
            int resultadoEsperado = 1;
            //Act
            FuncionarioRetornado = FuncionarioAsure.ObtenerFuncionarioPorRun(runProbar);

            //Assert 
            Assert.Equal(resultadoEsperado, FuncionarioRetornado.Run_Funcionario);
        }
    }
}