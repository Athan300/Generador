using Generador_de_Documentos_Sanitarios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Generador_de_Documentos_Sanitarios.Asure
{
    public class DocumentoAsure
    {
        static string connectionString = @"Server=DESKTOP-BNMQKTE\ATHAN\SQLEXPRESS;Database=Genrador;Trusted_Connection=True;";

        private static List<Documento> documentos;


        #region Obtener Documentos

        public static List<Documento> ObtenerDocumentos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = "select * from Documento";

                var comando = ConsultaSqlDocumento(connection, consultaSql);

                var dataTablePlantas = LlenarDataTable(comando);

                return LLenadoDocumentos(dataTablePlantas);
            }
        }
        #endregion

        #region Obtener Documento Id
        public static Documento ObtenerDocumentoPorId(int idPlanta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = $"select * from Planta where idPlanta = {idPlanta}";

                var comando = ConsultaSqlDocumento(connection, consultaSql);

                var dataTable = LlenarDataTable(comando);

                return CreacionDocumento(dataTable);
            }
        }
        #endregion

        #region Obtener Todos los documentos
        public static List<Documento> ObtnerDocumentos()
        {
            var dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "select * from Documento";

                sqlConnection.Open();

                var dataAdapter = new SqlDataAdapter(sqlCommand);

                dataAdapter.Fill(dataTable);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Documento documento = new Documento();
                    documento.Id_Documento = int.Parse(dataTable.Rows[i]["Id_Documento"].ToString());
                    documento.Tipo_Documento = dataTable.Rows[i]["Tipo_Documemto"].ToString();
                    documento.Id_Region = int.Parse(dataTable.Rows[i]["Id_Region"].ToString());
                    documento.Id_Comuna = int.Parse(dataTable.Rows[i]["Id_Comuna"].ToString());
                    documento.Run_Usuario = int.Parse(dataTable.Rows[i]["Dv_Usuario"].ToString());
                    documento.Dv_Usuario = dataTable.Rows[i]["Run_Usuario"].ToString();
                    documento.Fecha_Creacion = DateTime.Parse(dataTable.Rows[i]["Fecha_Creacion"].ToString());

                    documentos.Add(documento);


                }

            }

            return documentos;




        }

        #endregion

        #region Agregar 
        public static int AgregarDcocumento(Documento documento)

        {

            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Insert into Documento (TipoDocumento,Id_region,Id_comuna,Dv_Usuario,Run_Usuario,Fecha_Creacion) values (@Tipo_Documento,@Id_region,@)Id_Comuna,@Dv_Usuario,@Run_Usuario,@Fecha_Creacion";
                sqlCommand.Parameters.AddWithValue("@Tipo_Documento", documento.Tipo_Documento);
                sqlCommand.Parameters.AddWithValue("@Id_Region", documento.Id_Region);
                sqlCommand.Parameters.AddWithValue("@Id_Comuna", documento.Id_Comuna);
                sqlCommand.Parameters.AddWithValue("@Id_Dv_Usuario", documento.Dv_Usuario);
                sqlCommand.Parameters.AddWithValue("@Id_Run_Usuario", documento.Run_Usuario);
                sqlCommand.Parameters.AddWithValue("@Fecha_Creacion", documento.Fecha_Creacion);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return resultado;
        }

#endregion

        #region Eliminar
        public static int EliminarDocumentoPorRunUsuario(int Run_Usuario)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Delete from Documento where Run_Usuario = @Run_Usuario";
                sqlCommand.Parameters.AddWithValue("@Run_Funcionario", Run_Usuario);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return resultado;
            }
        }
        #endregion

        #region Actualizar

        public static int ActualizarDocumento(Documento documento)
        {
            int update = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand("UPDATE Documento SET ID_DOCUMENTO = @Id_Documento, TIPO_DOCUMENTO = @Tipo_Documento, ID_REGION = @Id_Region, ID_COMUNA = @Id_Comuna, Dv_Usuario = @Dv_Usuario, RUN_USUARIO = @Run_Usuario, FECHA_CREACION = @Fecha_Creacion WHERE RUT_USUARIO = @Rut_Usuario", connection);
                    sqlCommand.Parameters.AddWithValue("@Id_Documento", documento.Id_Documento);
                    sqlCommand.Parameters.AddWithValue("@Tipo_Documento", documento.Tipo_Documento);
                    sqlCommand.Parameters.AddWithValue("@Id_Region", documento.Id_Region);
                    sqlCommand.Parameters.AddWithValue("@Id_Comuna", documento.Id_Comuna);
                    sqlCommand.Parameters.AddWithValue("@Dv_Usuario", documento.Dv_Usuario);
                    sqlCommand.Parameters.AddWithValue("@Run_Usuario", documento.Run_Usuario);
                    sqlCommand.Parameters.AddWithValue("@Fecha_Creacion", documento.Fecha_Creacion);

                    update = sqlCommand.ExecuteNonQuery();

                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(">>>>>>>>" + ex.GetType());
                    Console.WriteLine(">>>>>>>>" + ex.Message);

                }
            }
            return update;

        }
        #endregion

        #region Cosulta Documento

        private static SqlCommand ConsultaSqlDocumento(SqlConnection connection, string consulta)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = consulta;
            connection.Open();
            return sqlCommand;
        }
        #endregion

        #region Crear Documento
        private static Documento CreacionDocumento(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Documento documento = new Documento();
                documento.Id_Documento = int.Parse(dataTable.Rows[0]["Id_Documento"].ToString());
                documento.Tipo_Documento = dataTable.Rows[0]["Tipo_Documemto"].ToString();
                documento.Id_Region = int.Parse(dataTable.Rows[0]["Id_Region"].ToString());
                documento.Id_Comuna = int.Parse(dataTable.Rows[0]["Id_Comuna"].ToString());
                documento.Run_Usuario = int.Parse(dataTable.Rows[0]["Dv_Usuario"].ToString());
                documento.Dv_Usuario = dataTable.Rows[0]["Run_Usuario"].ToString();
                documento.Fecha_Creacion = DateTime.Parse(dataTable.Rows[0]["Fecha_Creacion"].ToString());
                return documento;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region LLenar Tabla
        private static DataTable LlenarDataTable(SqlCommand comando)
        {
            //2. llenamos el dataTable(conversion)
            var dataTable = new DataTable();
            var dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        #endregion

        #region LLenado Documado
        private static List<Documento> LLenadoDocumentos(DataTable dataTable)
        {
            documentos = new List<Documento>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Documento documento = new Documento();
                documento.Id_Documento = int.Parse(dataTable.Rows[i]["Id_Documento"].ToString());
                documento.Tipo_Documento = dataTable.Rows[i]["Tipo_Documemto"].ToString();
                documento.Id_Region = int.Parse(dataTable.Rows[i]["Id_Region"].ToString());
                documento.Id_Comuna = int.Parse(dataTable.Rows[i]["Id_Comuna"].ToString());
                documento.Run_Usuario = int.Parse(dataTable.Rows[i]["Dv_Usuario"].ToString());
                documento.Dv_Usuario = dataTable.Rows[i]["Run_Usuario"].ToString();
                documento.Fecha_Creacion = DateTime.Parse(dataTable.Rows[i]["Fecha_Creacion"].ToString());

                documentos.Add(documento);
            }
            return documentos;
        }
        #endregion







    }
}
