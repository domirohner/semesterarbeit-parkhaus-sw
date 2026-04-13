using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParkhausSW
{
    public class DatabaseConnection
    {
        // Verbindung zu DB
        public static string ConnectionString = @"Data Source=LAPTOP-QEUETPR0\SQLEXPRESS;Database=ParkhausSW;Trusted_Connection=True;";

        // Testet die Verbindung
        public static bool TesteVerbindung()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler bei der Datenbankverbindung:\n{ex.Message}",
                                    "Datenbank-Fehler",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}