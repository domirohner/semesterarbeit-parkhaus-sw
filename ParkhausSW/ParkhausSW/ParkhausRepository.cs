using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParkhausSW
{
    // Hilfsklasse für die Stickwerke
    public class StockwerkDaten
    {
        public int StockwerkId { get; set; }
        public string Bezeichnung { get; set; }
        public List<ParkplatzDaten> Plaetze { get; set; } = new List<ParkplatzDaten>();
    }

    // Hilfsklasse für den einzelnen Parkplatz
    public class ParkplatzDaten
    {
        public int Nummer { get; set; }
        public string Status { get; set; }
        public int? DauermieterId { get; set; }
    }

    public class ParkhausRepository
    {
        // Generiert die komplette Struktur des Parkhauses
        public static void KonfiguriereParkhaus(int anzahlStockwerke, int plaetzeProStockwerk)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    new SqlCommand("DELETE FROM TICKET", connection).ExecuteNonQuery();
                    new SqlCommand("DELETE FROM PARKPLATZ", connection).ExecuteNonQuery();
                    new SqlCommand("DELETE FROM STOCKWERK", connection).ExecuteNonQuery();

                    for (int i = 0; i < anzahlStockwerke; i++)
                    {
                        string ebeneName = (i == 0) ? "Erdgeschoss" : $"{i}. Obergeschoss";

                        string stockwerkQuery = "INSERT INTO STOCKWERK (parkhaus_id, ebene_nummer, bezeichnung, kapazitaet_ebene) OUTPUT INSERTED.stockwerk_id VALUES (1, @ebene, @bez, @kapazitaet)";
                        int neuesStockwerkId;

                        using (SqlCommand cmd = new SqlCommand(stockwerkQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@ebene", i);
                            cmd.Parameters.AddWithValue("@bez", ebeneName);
                            cmd.Parameters.AddWithValue("@kapazitaet", plaetzeProStockwerk);
                            neuesStockwerkId = (int)cmd.ExecuteScalar();
                        }

                        for (int p = 1; p <= plaetzeProStockwerk; p++)
                        {
                            string platzQuery = "INSERT INTO PARKPLATZ (stockwerk_id, nummer, status) VALUES (@sId, @nummer, 'frei')";
                            using (SqlCommand pCmd = new SqlCommand(platzQuery, connection))
                            {
                                pCmd.Parameters.AddWithValue("@sId", neuesStockwerkId);
                                pCmd.Parameters.AddWithValue("@nummer", p);
                                pCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show($"Parkhaus erfolgreich konfiguriert!\n{anzahlStockwerke} Stockwerke mit je {plaetzeProStockwerk} Plätzen wurden erstellt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler bei der Konfiguration: {ex.Message}", "Datenbank-Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Holt alle Stockwerke und deren Parkplätze für das Dashboard
        public static List<StockwerkDaten> HoleDashboardDaten()
        {
            List<StockwerkDaten> stockwerke = new List<StockwerkDaten>();

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                // Ein JOIN über Stockwerk und Parkplatz
                string query = @"SELECT s.stockwerk_id, s.bezeichnung, p.nummer, p.status, p.dauermieter_id 
                                 FROM STOCKWERK s 
                                 INNER JOIN PARKPLATZ p ON s.stockwerk_id = p.stockwerk_id 
                                 ORDER BY s.ebene_nummer, p.nummer";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StockwerkDaten aktuellesStockwerk = null;
                            int letzteStockwerkId = -1;

                            while (reader.Read())
                            {
                                int stockwerkId = Convert.ToInt32(reader["stockwerk_id"]);

                                // Wenn ein neues Stockwerk beginnt, neues Objekt erstellen
                                if (stockwerkId != letzteStockwerkId)
                                {
                                    aktuellesStockwerk = new StockwerkDaten
                                    {
                                        StockwerkId = stockwerkId,
                                        Bezeichnung = reader["bezeichnung"].ToString()
                                    };
                                    stockwerke.Add(aktuellesStockwerk);
                                    letzteStockwerkId = stockwerkId;
                                }

                                // Den Parkplatz zum aktuellen Stockwerk hinzufügen
                                aktuellesStockwerk.Plaetze.Add(new ParkplatzDaten
                                {
                                    Nummer = Convert.ToInt32(reader["nummer"]),
                                    Status = reader["status"].ToString(),
                                    DauermieterId = reader["dauermieter_id"] != DBNull.Value ? (int?)Convert.ToInt32(reader["dauermieter_id"]) : null
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Laden des Dashboards: {ex.Message}");
                    }
                }
            }
            return stockwerke;
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

        // Liest die aktuelle Anzahl an Stockwerken und Plätzen aus der DB
        public static (int stockwerke, int plaetze) HoleAktuelleKonfiguration()
        {
            int anzahlStockwerke = 0;
            int anzahlPlaetze = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Zählen, wie viele Stockwerke es gibt
                    string stockwerkQuery = "SELECT COUNT(*) FROM STOCKWERK";
                    using (SqlCommand cmd1 = new SqlCommand(stockwerkQuery, connection))
                    {
                        anzahlStockwerke = (int)cmd1.ExecuteScalar();
                    }

                    // Wenn es Stockwerke gibt, die Kapazität des ersten Stockwerks auslesen
                    if (anzahlStockwerke > 0)
                    {
                        string platzQuery = "SELECT TOP 1 kapazitaet_ebene FROM STOCKWERK";
                        using (SqlCommand cmd2 = new SqlCommand(platzQuery, connection))
                        {
                            object result = cmd2.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                anzahlPlaetze = Convert.ToInt32(result);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return (anzahlStockwerke, anzahlPlaetze);
        }

        // Prüfen ob Häckchen für Feiertag gesetzt ist
        public static bool HoleFeiertagsStatus()
        {
            bool istFeiertag = false;
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                string query = "SELECT ist_heute_feiertag FROM PARKHAUS WHERE parkhaus_id = 1";
                using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        istFeiertag = Convert.ToBoolean(result);
                    }
                }
            }
            return istFeiertag;
        }
    }
}