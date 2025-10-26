using Microsoft.Data.SqlClient;

namespace ATM_Simulator_WPF.Model.DataAccess
{
    public class SqlDataAccess
    {
        // En la implementación real, la cadena de conexión se leerá del archivo App.config o Secrets
        private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ATM_DB;User ID=ATM_User_SQL;Password=ContrasenaSegura1234;TrustServerCertificate=True;";
        public CuentaModel? AutenticarCuenta(string numeroCuenta, string pin)
        {
            CuentaModel? cuenta = null;
            string sql = "SELECT ID, NumeroCuenta, Saldo FROM Cuentas WHERE NumeroCuenta = @Cuenta AND PIN = @PIN";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Cuenta", numeroCuenta);
                    cmd.Parameters.AddWithValue("@PIN", pin);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cuenta = new CuentaModel
                            {
                                ID = reader.GetInt32(0),
                                NumeroCuenta = reader.GetString(1),
                                Saldo = reader.GetDecimal(2)
                            };
                        }
                    }
                }
            }
            return cuenta;
        }

        public bool ActualizarSaldo(int cuentaId, decimal nuevoSaldo)
        {
            string sql = "UPDATE Cuentas SET Saldo = @Saldo WHERE ID = @ID";
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Saldo", nuevoSaldo);
                    cmd.Parameters.AddWithValue("@ID", cuentaId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
