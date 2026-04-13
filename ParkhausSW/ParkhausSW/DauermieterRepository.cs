using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParkhausSW
{
    public class DauermieterRepository
    {
        // Prüft Dauermieter bei Schranke
        public static Dauermieter PruefeDauermieter(string code)
        {
            Dauermieter mieter = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = "SELECT dauermieter_id, name, vorname, zugangscode, miete_bezahlt, vertragsende FROM DAUERMIETER WHERE zugangscode = @code";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@code", code);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                mieter = new Dauermieter
                                {
                                    DauermieterId = Convert.ToInt32(reader["dauermieter_id"]),
                                    Name = reader["name"].ToString(),
                                    Vorname = reader["vorname"].ToString(),
                                    Zugangscode = reader["zugangscode"].ToString(),
                                    MieteBezahlt = Convert.ToBoolean(reader["miete_bezahlt"]),
                                    Vertragsende = reader["vertragsende"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["vertragsende"]) : null
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Lesen der Daten: {ex.Message}");
                    }
                }
            }
            return mieter;
        }

        // Dauermieter anlegen und Parkplatz direkt zuweisen
        public static bool LegeDauermieterAn(string name, string vorname, string code, bool bezahlt, DateTime ende, int parkplatzId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Dauermieter eintragen
                    string insertQuery = "INSERT INTO DAUERMIETER (name, vorname, zugangscode, miete_bezahlt, vertragsende) OUTPUT INSERTED.dauermieter_id VALUES (@n, @v, @c, @b, @e)";
                    int neueMieterId;

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@v", vorname);
                        cmd.Parameters.AddWithValue("@c", code);
                        cmd.Parameters.AddWithValue("@b", bezahlt);
                        cmd.Parameters.AddWithValue("@e", ende);
                        neueMieterId = (int)cmd.ExecuteScalar();
                    }

                    // Den Parkplatz für diesen Mieter reservieren
                    string updatePlatzQuery = "UPDATE PARKPLATZ SET dauermieter_id = @mId WHERE parkplatz_id = @pId";
                    using (SqlCommand cmd2 = new SqlCommand(updatePlatzQuery, connection))
                    {
                        cmd2.Parameters.AddWithValue("@mId", neueMieterId);
                        cmd2.Parameters.AddWithValue("@pId", parkplatzId);
                        cmd2.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    // Fehlercode 2627 ist die UNIQUE KEY Verletzung in SQL Server
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Dieser Zugangscode ist bereits vergeben! Bitte wähle einen anderen, eindeutigen Code.", "Code bereits vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Datenbankfehler beim Anlegen: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Allgemeiner Fehler: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Holt alle Dauermieter
        public static DataTable HoleAlleDauermieter()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                // Ein JOIN, um direkt den Namen des Parkplatzes statt nur Nummer anzuzeigen
                string query = @"SELECT d.name AS Name, d.vorname AS Vorname, d.zugangscode AS Code, 
                                        d.miete_bezahlt AS Bezahlt, d.vertragsende AS Vertragsende, 
                                        s.bezeichnung + ' - Platz ' + CAST(p.nummer AS VARCHAR) AS Parkplatz
                                 FROM DAUERMIETER d
                                 LEFT JOIN PARKPLATZ p ON d.dauermieter_id = p.dauermieter_id
                                 LEFT JOIN STOCKWERK s ON p.stockwerk_id = s.stockwerk_id";

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
                        MessageBox.Show($"Fehler beim Laden der Liste: {ex.Message}");
                    }
                }
            }
            return dt;
        }

        // Holt die Dauermieter speziell formatiert für das Löschen-Dropdown
        public static DataTable HoleAlleDauermieterFuerDropdown()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = "SELECT dauermieter_id, name + ' ' + vorname + ' (Code: ' + zugangscode + ')' AS anzeige FROM DAUERMIETER";
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

        // Löscht den Mieter und gibt seinen Parkplatz wieder frei
        public static bool LoescheDauermieter(int dauermieterId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Parkplatz von diesem Mieter löschen
                    string updatePlatzQuery = "UPDATE PARKPLATZ SET dauermieter_id = NULL WHERE dauermieter_id = @id";
                    using (SqlCommand cmd1 = new SqlCommand(updatePlatzQuery, connection))
                    {
                        cmd1.Parameters.AddWithValue("@id", dauermieterId);
                        cmd1.ExecuteNonQuery();
                    }

                    // Mieter endgültig aus dem System löschen
                    string deleteMieterQuery = "DELETE FROM DAUERMIETER WHERE dauermieter_id = @id";
                    using (SqlCommand cmd2 = new SqlCommand(deleteMieterQuery, connection))
                    {
                        cmd2.Parameters.AddWithValue("@id", dauermieterId);
                        cmd2.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Löschen: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}