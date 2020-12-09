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

        [Fact]
        public void TestAgregarFuncionario()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            Funcionario funcionario = new Funcionario();
            funcionario.Dv_Funcionario = "k";
            funcionario.Run_Funcionario = 11111111;
            funcionario.Nombre_Funcionario = "El ";
            funcionario.Apellido_Paterno_Funcionario = "Betox";
            funcionario.Apellido_Materno_Funcionario = "Bellaquito";
            

            //Act
            resultadoObtenido = FuncionarioAsure.AgregarFuncionario(funcionario);

            //Assert 
            Assert.Equal(resultadoEsperado, resultadoObtenido);


        }

        [Fact]
        public void TestActualizarFuncionario()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            Funcionario funcionario = new Funcionario();
            funcionario.Dv_Funcionario = "k";
            funcionario.Run_Funcionario = 11111111;
            funcionario.Nombre_Funcionario = "El ";
            funcionario.Apellido_Paterno_Funcionario = "Betox";
            funcionario.Apellido_Materno_Funcionario = "Bellaquito";

            //Act
            resultadoObtenido = FuncionarioAsure.ActualizarFuncionario(funcionario);

            FuncionarioAsure.ActualizarFuncionario(funcionario);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }

        [Fact]
        public void EliminarFuncionarioPorRun()
        {
            //Arrange         
            Funcionario funcionario = new Funcionario();
            funcionario.Run_Funcionario = 11111111;


            int RunFuncionarioEliminar = 11111111;


            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            FuncionarioAsure.EliminarDocumentoPorRunFuncionario(RunFuncionarioEliminar);

            //Act
            resultadoObtenido = DocumentoAsure.EliminarDocumentoPorIdDocumento(RunFuncionarioEliminar);

            //Assert 
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

    }
}