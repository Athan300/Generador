using Generador_de_Documentos_Sanitarios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Generador_de_Documentos_Sanitarios.Asure
{
    public class FuncionarioAsure
    {
        static string connectionString = @"Server=DESKTOP-BNMQKTE\ATHAN\SQLEXPRESS;Database=Generador;Trusted_Connection=True;";

        private static List<Funcionario> funcionarios;


        #region Obtener Funcionario Id
        public static Funcionario ObtenerFuncionarioPorRun(int Run_Funcionario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = $"select * from Funcionario where Run_Funcionario = {Run_Funcionario}";

                var comando = ConsultaSqlFuncionario(connection, consultaSql);

                var dataTable = LlenarDataTable(comando);

                return CreacionFuncionario(dataTable);
            }
        }
        #endregion

        #region Obtener Funcionarios

        public static List<Funcionario> ObtenerFuncionarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = "select * from Documento";

                var comando = ConsultaSqlFuncionario(connection, consultaSql);

                var dataTablePlantas = LlenarDataTable(comando);

                return LLenadoFuncionarios(dataTablePlantas);
            }
        }
        #endregion

        #region AgregarFuncionario
        public static int AgregarFuncionario(Funcionario funcionario)

        {

            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Insert into Documento (Run_Funcionario,Dv_Funcionario,Nombre_Funcionario,Apellido_Paterno_Funcionario,Apellido_Materno_Funcionario) values (@Run_Funcionario,@Dv_Funcionario,@)Nombre_Funcionario,@Apellido_Paterno_Funcionario,@Apellido_Materno_Funcionario";
                sqlCommand.Parameters.AddWithValue("@Tipo_Documento", funcionario.Dv_Funcionario);
                sqlCommand.Parameters.AddWithValue("@Id_Region", funcionario.Run_Funcionario);
                sqlCommand.Parameters.AddWithValue("@Id_Comuna", funcionario.Nombre_Funcionario);
                sqlCommand.Parameters.AddWithValue("@Id_Dv_Usuario", funcionario.Apellido_Paterno_Funcionario);
                sqlCommand.Parameters.AddWithValue("@Id_Run_Usuario", funcionario.Apellido_Materno_Funcionario);

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

        #region Eliminar Funcionario Run
        public static int EliminarDocumentoPorRunFuncionario(int Run_Funcionario)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Delete from Funcionario where Run_Funcionario = @Run_Funcionario";
                sqlCommand.Parameters.AddWithValue("@Run_Funcionario", Run_Funcionario);

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

        #region ActualizarFuncionario

        public static int ActualizarFuncionario(Funcionario funcionario)
        {
            int update = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand("UPDATE Funcionario SET DV_FUNCIONARIO = @Dv_Funcionario, RUN_FUNCIONARIO = @Run_Funcionario, NOMBRE_FUNCIONARIO = @Nombre_Funcionario,APELLIDO_PATERNO_FUNCIONARIO = @Apellido_Paterno_Funcionario WHERE RUN_CLIENTE = @run_cliente", connection);
                    sqlCommand.Parameters.AddWithValue("@Dv_Funcionario", funcionario.Dv_Funcionario);
                    sqlCommand.Parameters.AddWithValue("@Run_Funcionario", funcionario.Run_Funcionario);
                    sqlCommand.Parameters.AddWithValue("@Nombre_Funcionario", funcionario.Nombre_Funcionario);
                    sqlCommand.Parameters.AddWithValue("@Apellido_Paterno_Funcionario", funcionario.Apellido_Paterno_Funcionario);
                    sqlCommand.Parameters.AddWithValue("@Apellido_Materno_Funcionario", funcionario.Apellido_Materno_Funcionario);

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

        #region Cosulta Funcionario

        private static SqlCommand ConsultaSqlFuncionario(SqlConnection connection, string consulta)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = consulta;
            connection.Open();
            return sqlCommand;
        }
        #endregion

        #region Crear Funcionario
        private static Funcionario CreacionFuncionario(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Dv_Funcionario = dataTable.Rows[0]["Dv_Funcionario"].ToString();
                funcionario.Run_Funcionario = int.Parse(dataTable.Rows[0]["Run_Funcionario"].ToString());
                funcionario.Nombre_Funcionario = dataTable.Rows[0]["Nombre_Funcionario"].ToString();
                funcionario.Apellido_Paterno_Funcionario = dataTable.Rows[0]["Apellido_Paterno_Funcionario"].ToString();
                funcionario.Apellido_Materno_Funcionario = dataTable.Rows[0]["Apellido_Materno_Funcionario"].ToString();

                return funcionario;
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

        #region LLenado Funcionario
        private static List<Funcionario> LLenadoFuncionarios(DataTable dataTable)
        {
            funcionarios = new List<Funcionario>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Dv_Funcionario = dataTable.Rows[i]["Dv_Funcionario"].ToString();
                funcionario.Run_Funcionario = int.Parse(dataTable.Rows[i]["Run_Funcionario"].ToString());
                funcionario.Nombre_Funcionario = dataTable.Rows[i]["Nombre_Funcionario"].ToString();
                funcionario.Apellido_Paterno_Funcionario = dataTable.Rows[i]["Apellido_Paterno_Funcionario"].ToString();
                funcionario.Apellido_Materno_Funcionario = dataTable.Rows[i]["Apellido_Materno_Funcionario"].ToString();


                funcionarios.Add(funcionario);
            }
            return funcionarios;
        }
        #endregion



    }
}
