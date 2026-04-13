using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParkhausSW
{
    public class ReportRepository
    {
        // Rechnet den gesamten Umsatz für einen bestimmten Monat zusammen
        public static double GeneriereMonatsUmsatz(int monat, int jahr)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                // Alle Tickets, die bereits bezahlt oder entwertet wurden, zusammenzählen
                string query = @"SELECT SUM(betrag) FROM TICKET 
                                 WHERE (status = 'bezahlt' OR status = 'entwertet') 
                                 AND MONTH(bezahlzeit) = @monat 
                                 AND YEAR(bezahlzeit) = @jahr";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@monat", monat);
                    cmd.Parameters.AddWithValue("@jahr", jahr);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();

                        // Wenn es in diesem Monat Einnahmen gab, zurückgeben
                        if (result != DBNull.Value && result != null)
                        {
                            return Convert.ToDouble(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler bei der Umsatzberechnung: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return 0.00; // Wenn noch nichts eingenommen wurde
        }
    }
}