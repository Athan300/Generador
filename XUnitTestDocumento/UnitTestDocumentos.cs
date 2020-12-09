using Generador_de_Documentos_Sanitarios.Asure;
using Generador_de_Documentos_Sanitarios.Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestDocumento
{
    public class UnitTestDocumentoAsure
    {
        [Fact]
        public void TestObtenerDocumentos()
        {
            //Arrange
            bool vieneConDatos = false;

            //Act
            var resultado = DocumentoAsure.ObtenerDocumentos();
            vieneConDatos = resultado.Any();

            //Assert 
            Assert.True(vieneConDatos);
        }


        [Fact]
        public void TestObtenerDocumentoPorId()
        {
            //Arrange
            int idProbar = 1;
            Documento DocumentoRetornado;
            int resultadoEsperado = 1;
            //Act
            DocumentoRetornado = DocumentoAsure.ObtenerDocumentoPorId(idProbar);

            //Assert 
            Assert.Equal(resultadoEsperado, DocumentoRetornado.Id_Documento);
        }

        [Fact]
        public void TestAgregarDcocumento()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            Documento documento = new Documento();
            documento.Tipo_Documento = "Transporte";
            documento.Id_Region = 2;
            documento.Id_Comuna = 5;
            documento.Dv_Usuario = "4";
            documento.Run_Usuario = 200026441;
            documento.Fecha_Creacion = 03 / 20 / 2020;

            //Act
            resultadoObtenido = DocumentoAsure.AgregarDcocumento(documento);

            //Assert 
            Assert.Equal(resultadoEsperado, resultadoObtenido);


        }

        [Fact]
        public void TestActualizarDocumento()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            Documento documento = new Documento();
            documento.Id_Documento = 1;
            documento.Tipo_Documento = "Transporte";
            documento.Id_Region = 5;
            documento.Id_Comuna = 3;
            documento.Dv_Usuario = "1";
            documento.Run_Usuario = 20002646;
            documento.Fecha_Creacion = ;

            //Act
            resultadoObtenido = DocumentoAsure.ActualizarDocumento(documento);


            DocumentoAsure.ActualizarDocumento(documento);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }

        [Fact]
        public void EliminarDocumentoPorRunUsuario()
        {
            //Arrange         
            Documento documento = new Documento();
            documento.Id_Documento = 3;


            int IdDocumentoEliminar = 3;


            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            DocumentoAsure.EliminarDocumentoPorIdDocumento(IdDocumentoEliminar);

            //Act
            resultadoObtenido = DocumentoAsure.EliminarDocumentoPorIdDocumento(IdDocumentoEliminar);

            //Assert 
            Assert.Equal(resultadoEsperado, resultadoObtenido);

        }

    }
}
