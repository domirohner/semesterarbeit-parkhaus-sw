using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParkhausSW
{
    public class TicketRepository
    {
        // Erstellt ein Ticket und gibt die generierte ID zurück
        public static string ErstelleTicket(int parkplatzId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Parkplatz auf besetzt setzen
                    string updateQuery = "UPDATE PARKPLATZ SET status = 'besetzt' WHERE parkplatz_id = @pId";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@pId", parkplatzId);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Ticket erstellen
                    string insertQuery = "INSERT INTO TICKET (parkplatz_id, tarif_id, einfahrtszeit, status) OUTPUT INSERTED.ticket_id VALUES (@pId, 1, @zeit, 'aktiv')";
                    int neueTicketId;

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@pId", parkplatzId);
                        insertCmd.Parameters.AddWithValue("@zeit", DateTime.Now);

                        neueTicketId = (int)insertCmd.ExecuteScalar();
                    }

                    // ID als Text zuzurück, damit sie in die Dropdown-Liste passt
                    return neueTicketId.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler bei der Ticketerstellung: {ex.Message}");
                    return null;
                }
            }
        }

        public static TicketDaten HoleTicketInfos(string ticketIdString)
        {
            // Text aus dem Dropdown wieder in eine echte Zahl umwandeln
            int ticketId = int.Parse(ticketIdString);

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = @"SELECT t.parkplatz_id, t.einfahrtszeit, t.bezahlzeit, t.status, 
                                        ta.preis_pro_15min, ta.tagespauschale_max 
                                 FROM TICKET t 
                                 INNER JOIN TARIF ta ON t.tarif_id = ta.tarif_id 
                                 WHERE t.ticket_id = @tId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tId", ticketId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TicketDaten
                                {
                                    ParkplatzId = Convert.ToInt32(reader["parkplatz_id"]),
                                    Einfahrtszeit = Convert.ToDateTime(reader["einfahrtszeit"]),
                                    Bezahlzeit = reader["bezahlzeit"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["bezahlzeit"]) : null,
                                    Status = reader["status"].ToString(),
                                    PreisPro15Min = Convert.ToDouble(reader["preis_pro_15min"]),
                                    Tagespauschale = Convert.ToDouble(reader["tagespauschale_max"])
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Lesen des Tickets: {ex.Message}");
                    }
                }
            }
            return null;
        }

        public static bool TicketBezahlen(string ticketIdString, double betrag)
        {
            int ticketId = int.Parse(ticketIdString);

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = "UPDATE TICKET SET status = 'bezahlt', betrag = @betrag, bezahlzeit = @zeit WHERE ticket_id = @tId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@betrag", betrag);
                    command.Parameters.AddWithValue("@zeit", DateTime.Now);
                    command.Parameters.AddWithValue("@tId", ticketId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Offline-Zwischenspeicherung bei Ausfall
                        try
                        {
                            // Die Zahlung in eine lokale Textdatei schreiben
                            string offlineData = $"{DateTime.Now} | TicketID: {ticketId} | Betrag: {betrag} CHF | Status: OFFLINE_BEZAHLT\n";
                            System.IO.File.AppendAllText("Offline_Zahlungen.txt", offlineData);

                            MessageBox.Show("Sie können ausfahren.", "Offline-Modus", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return true;
                        }
                        catch
                        {
                            // Falls das Schreiben der Textdatei fehlschlägt
                            MessageBox.Show($"Kritischer Systemfehler beim Bezahlen: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
        }

        public static void TicketEntwertenUndPlatzFreigeben(string ticketIdString, int parkplatzId)
        {
            int ticketId = int.Parse(ticketIdString);

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Ticket entwerten
                    string ticketQuery = "UPDATE TICKET SET status = 'entwertet', ausfahrtszeit = @zeit WHERE ticket_id = @tId";
                    using (SqlCommand cmd1 = new SqlCommand(ticketQuery, connection))
                    {
                        cmd1.Parameters.AddWithValue("@zeit", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@tId", ticketId);
                        cmd1.ExecuteNonQuery();
                    }

                    // Parkplatz wieder freigeben
                    string platzQuery = "UPDATE PARKPLATZ SET status = 'frei' WHERE parkplatz_id = @pId";
                    using (SqlCommand cmd2 = new SqlCommand(platzQuery, connection))
                    {
                        cmd2.Parameters.AddWithValue("@pId", parkplatzId);
                        cmd2.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler bei der Ausfahrt: {ex.Message}");
                }
            }
        }

        public static List<string> HoleTicketsNachStatus(string status)
        {
            List<string> tickets = new List<string>();

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                string query = "SELECT ticket_id FROM TICKET WHERE status = @status";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@status", status);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tickets.Add(reader["ticket_id"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Laden der Ticketliste: {ex.Message}");
                    }
                }
            }
            return tickets;
        }
    }
}