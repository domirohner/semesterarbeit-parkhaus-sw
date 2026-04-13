using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParkhausSW
{
    public class TarifRepository
    {
        // Holt die aktuellen Preise aus der Datenbank beim Programmstart
        public static (double preis15, double pauschale) HoleAktuellenTarif()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = "SELECT preis_pro_15min, tagespauschale_max FROM TARIF WHERE tarif_id = 1";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (Convert.ToDouble(reader["preis_pro_15min"]), Convert.ToDouble(reader["tagespauschale_max"]));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Laden der Tarife: {ex.Message}");
                    }
                }
            }
            return (1.00, 35.00); // Fallback, falls die DB leer ist
        }

        public static decimal HoleSpezialTarif(string bezeichnung)
        {
            decimal preis = 0;
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                // Holt gezielt den 15-Min-Preis für 'Nacht' oder 'Wochenende'
                string query = "SELECT preis_pro_15min FROM TARIF WHERE bezeichnung = @bezeichnung";
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bezeichnung", bezeichnung);
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        preis = Convert.ToDecimal(result);
                    }
                }
            }
            return preis;
        }

        // Speichert die im GUI geänderten Werte
        public static void AktualisiereTarif(double preis15Min, double tagespauschale)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = "UPDATE TARIF SET preis_pro_15min = @p15, tagespauschale_max = @pauschale WHERE tarif_id = 1";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@p15", preis15Min);
                    cmd.Parameters.AddWithValue("@pauschale", tagespauschale);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tarife erfolgreich in der Datenbank gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Speichern des Tarifs: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}