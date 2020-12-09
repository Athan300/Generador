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


    }
}
