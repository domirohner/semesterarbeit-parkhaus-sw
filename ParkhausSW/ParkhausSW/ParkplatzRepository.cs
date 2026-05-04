using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParkhausSW
{
    public class ParkplatzRepository
    {
        // Sucht den besten freien Parkplatz
        public static int? HoleFreienParkplatz()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                // ALGORITHMUS:
                // Window-Function (OVER PARTITION BY) nutzen, um die freien Plaetze pro Stockwerk zu zählen.
                // Danach absteigend (DESC) nach dieser Anzahl sortieren 
                // So wird das Auto immer in das Stockwerk geschickt, das am leersten ist
                string query = @"
                    SELECT TOP 1 parkplatz_id 
                    FROM (
                        SELECT p.parkplatz_id, p.stockwerk_id, p.nummer,
                               COUNT(*) OVER(PARTITION BY p.stockwerk_id) AS FreiePlaetzeImStockwerk
                        FROM PARKPLATZ p
                        WHERE p.status = 'frei' AND p.dauermieter_id IS NULL
                    ) AS FreiePlaetze
                    ORDER BY FreiePlaetzeImStockwerk DESC, stockwerk_id, nummer";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler bei der Parkplatzsuche: {ex.Message}");
                    }
                }
            }
            return null;
        }

        // Wandelt die ID in einen Text um, damit der Kunde weiss, wo sein Platz ist
        public static string HoleParkplatzBezeichnung(int parkplatzId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = @"SELECT s.bezeichnung, p.nummer 
                                 FROM PARKPLATZ p 
                                 INNER JOIN STOCKWERK s ON p.stockwerk_id = s.stockwerk_id 
                                 WHERE p.parkplatz_id = @pId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@pId", parkplatzId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return $"{reader["bezeichnung"]}, Platz Nr. {reader["nummer"]}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return "Freier Platz";
        }

        // Holt eine Liste aller freien Parkplätze
        public static DataTable HoleFreiePlaetzeFuerDropdown()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = @"SELECT p.parkplatz_id, s.bezeichnung + ' - Platz ' + CAST(p.nummer AS VARCHAR) AS anzeige
                                 FROM PARKPLATZ p
                                 INNER JOIN STOCKWERK s ON p.stockwerk_id = s.stockwerk_id
                                 WHERE p.status = 'frei' AND p.dauermieter_id IS NULL";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return dt;
        }
    }
}