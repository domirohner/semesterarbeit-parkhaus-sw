using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ParkhausSW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Verknüpfung der Dropdown-Listen mit den Events zum Laden der aktuellen Tickets
            kassenautomat_tickets_cb.DropDown += Kassenautomat_tickets_cb_DropDown;
            ausfahrt_tickets_cb.DropDown += Ausfahrt_tickets_cb_DropDown;

            // Testet die Verbindung zur Datenbank beim Start
            DatabaseConnection.TesteVerbindung();

            InitialisiereHardwareUI();

            // Aktuelle Parkhaus-Konfiguration laden
            var konfig = ParkhausRepository.HoleAktuelleKonfiguration();
            if (konfig.stockwerke > 0 && konfig.plaetze > 0)
            {
                // Die Werte in den Eingabefeldern auf den aktuellen Datenbank-Stand
                parkhauskonfiguration_stockwerke_nud.Value = konfig.stockwerke;
                parkhauskonfiguration_plaetze_nud.Value = konfig.plaetze;
            }

            // Lade die aktuellen Tarife
            var tarif = TarifRepository.HoleAktuellenTarif();
            tarif_preis_15_min_nud.Value = (decimal)tarif.preis15;
            tagespauschale_preis_nud.Value = (decimal)tarif.pauschale;
            nachttarif_preis_15_min_nud.Value = TarifRepository.HoleSpezialTarif("Nacht");
            tarif_wochenende_nud.Value = TarifRepository.HoleSpezialTarif("Wochenende");
            feiertag_aktiv_cb.Checked = ParkhausRepository.HoleFeiertagsStatus();

            LadeDashboard();
            LadeDauermieterUI();
        }

        private void InitialisiereHardwareUI()
        {
            einfahrt_ausgabe_tb.Text = "Willkommen!\r\nBitte Knopf drücken oder Code eingeben";
            kassenautomat_ausgabe_tb.Text = "Kassenautomat bereit.\r\nBitte Ticket wählen.";
            ausfahrt_ausgabe_tb.Text = "Ausfahrt bereit.\r\nBitte Ticket scannen oder Code eingeben";

            // ComboBox für die Statistik mit den letzten 6 Monaten füllen
            umsatz_monat_jahr_cb.Items.Clear();
            for (int i = 0; i < 6; i++)
            {
                DateTime datum = DateTime.Now.AddMonths(-i);
                umsatz_monat_jahr_cb.Items.Add(datum.ToString("MM.yyyy"));
            }
            umsatz_monat_jahr_cb.SelectedIndex = 0; // Aktuellen Monat auswählen
        }

        // EINFAHRT

        private void einfahrt_ticket_ziehen_btn_Click(object sender, EventArgs e)
        {
            int? freierPlatzId = ParkplatzRepository.HoleFreienParkplatz();

            if (freierPlatzId == null)
            {
                einfahrt_ausgabe_tb.Text = "Parkhaus besetzt!\r\nLeider sind keine regulären Plätze frei.";
                return;
            }

            string neueTicketId = TicketRepository.ErstelleTicket(freierPlatzId.Value);

            if (neueTicketId != null)
            {
                string zugewiesenerPlatz = ParkplatzRepository.HoleParkplatzBezeichnung(freierPlatzId.Value);

                einfahrt_ausgabe_tb.Text = $"Ticket #{neueTicketId} gedruckt...\r\nZUGENWIESENER PLATZ:\r\n{zugewiesenerPlatz}\r\n\r\nSchranke öffnet sich.";

                LadeDashboard();
            }
        }

        private void einfahrt_code_eingeben_btn_Click(object sender, EventArgs e)
        {
            string code = einfahrt_code_tb.Text;

            if (string.IsNullOrWhiteSpace(code))
            {
                einfahrt_ausgabe_tb.Text = "Fehler: Bitte einen Code eingeben!";
                return;
            }

            Dauermieter mieter = DauermieterRepository.PruefeDauermieter(code);

            if (mieter == null)
            {
                einfahrt_ausgabe_tb.Text = "Fehler: Code ungültig!";
            }
            else
            {
                // Sperrung erfolgt nur, wenn nicht bezahlt wurde und wir den 15. oder später haben
                if (mieter.MieteBezahlt == false && DateTime.Now.Day >= 15)
                {
                    einfahrt_ausgabe_tb.Text = $"Hallo {mieter.Vorname} {mieter.Name}.\r\nZugang gesperrt:\r\nMiete nicht bezahlt (Sperrung ab 15.)!";
                }
                else
                {
                    // Entweder hat er bezahlt oder es ist noch vor dem 15.
                    einfahrt_ausgabe_tb.Text = $"Hallo {mieter.Vorname} {mieter.Name}.\r\nZugang gewährt.\r\nSchranke offen";
                }
            }

            einfahrt_code_tb.Clear();
        }

        // KASSENAUTOMAT

        private void Kassenautomat_tickets_cb_DropDown(object sender, EventArgs e)
        {
            kassenautomat_tickets_cb.Items.Clear();
            List<string> aktiveTickets = TicketRepository.HoleTicketsNachStatus("aktiv");

            foreach (string ticketId in aktiveTickets)
            {
                // Wir ergaenzen das "Ticket #" fuer eine schoenere Anzeige in der Box
                kassenautomat_tickets_cb.Items.Add("Ticket #" + ticketId);
            }
        }

        private void kassenautomat_ticket_bezahlen_btn_Click(object sender, EventArgs e)
        {
            if (kassenautomat_tickets_cb.SelectedItem == null)
            {
                kassenautomat_ausgabe_tb.Text = "Bitte zuerst ein Ticket aus der Liste wählen.";
                return;
            }

            // Wir holen den Text (z.B. "Ticket #2") und entfernen das "Ticket #", um nur die reine ID "2" fuer die DB zu haben
            string selectedText = kassenautomat_tickets_cb.SelectedItem.ToString();
            string ticketId = selectedText.Replace("Ticket #", "");

            TicketDaten daten = TicketRepository.HoleTicketInfos(ticketId);

            if (daten == null)
            {
                kassenautomat_ausgabe_tb.Text = "Fehler: Ticket im System nicht gefunden!";
                return;
            }

            if (daten.Status == "bezahlt")
            {
                kassenautomat_ausgabe_tb.Text = "Dieses Ticket ist bereits bezahlt.\r\nSie können zur Ausfahrt fahren.";
                return;
            }

            TimeSpan parkdauer = DateTime.Now - daten.Einfahrtszeit;
            double minutenGesamt = parkdauer.TotalMinutes;

            int bloecke = (int)Math.Ceiling(minutenGesamt / 15.0);
            if (bloecke == 0) bloecke = 1;

            double betrag = bloecke * daten.PreisPro15Min;

            if (betrag > daten.Tagespauschale)
            {
                betrag = daten.Tagespauschale;
            }

            bool erfolgreich = TicketRepository.TicketBezahlen(ticketId, betrag);

            if (erfolgreich)
            {
                kassenautomat_ausgabe_tb.Text = $"Parkdauer: {Math.Round(minutenGesamt)} Min.\r\nBetrag: {betrag:0.00} CHF\r\n\r\nZahlung erfolgreich! Sie haben 15 Minuten Zeit für die Ausfahrt.";
            }
        }

        // --- BEREICH: AUSFAHRT ---

        private void Ausfahrt_tickets_cb_DropDown(object sender, EventArgs e)
        {
            ausfahrt_tickets_cb.Items.Clear();
            List<string> bezahlteTickets = TicketRepository.HoleTicketsNachStatus("bezahlt");

            foreach (string ticketId in bezahlteTickets)
            {
                // Auch hier ergaenzen wir das "Ticket #" fuer die Anzeige
                ausfahrt_tickets_cb.Items.Add("Ticket #" + ticketId);
            }
        }

        private void ticket_scannen_btn_Click(object sender, EventArgs e)
        {
            if (ausfahrt_tickets_cb.SelectedItem == null)
            {
                ausfahrt_ausgabe_tb.Text = "Bitte ein entwertetes Ticket wählen.";
                return;
            }

            string selectedText = ausfahrt_tickets_cb.SelectedItem.ToString();
            string ticketId = selectedText.Replace("Ticket #", "");

            TicketDaten daten = TicketRepository.HoleTicketInfos(ticketId);

            if (daten == null || daten.Status == "entwertet")
            {
                ausfahrt_ausgabe_tb.Text = "Ticket ungültig oder bereits benutzt.";
                return;
            }

            if (daten.Status == "aktiv")
            {
                ausfahrt_ausgabe_tb.Text = "Ticket noch nicht bezahlt!\r\nBitte gehen Sie zum Kassenautomaten.";
                return;
            }

            if (daten.Bezahlzeit.HasValue)
            {
                TimeSpan zeitSeitBezahlung = DateTime.Now - daten.Bezahlzeit.Value;
                if (zeitSeitBezahlung.TotalMinutes > 15)
                {
                    ausfahrt_ausgabe_tb.Text = "Karenzzeit (15 Min) abgelaufen.\r\nBitte am Automaten nachzahlen.";
                    return;
                }
            }

            // Ausfahrt erfolgreich: Parkplatz freigeben
            TicketRepository.TicketEntwertenUndPlatzFreigeben(ticketId, daten.ParkplatzId);

            ausfahrt_ausgabe_tb.Text = "Gute Fahrt!\r\nSchranke öffnet sich.";

            ausfahrt_tickets_cb.Items.Remove(selectedText);
            kassenautomat_tickets_cb.Items.Remove(selectedText);

            // NEU: Dashboard sofort aktualisieren! Der rote Platz wird wieder gruen.
            LadeDashboard();
        }

        private void ausfahrt_code_eingeben_btn_Click(object sender, EventArgs e)
        {
            string code = ausfahrt_code_tb.Text;

            if (string.IsNullOrWhiteSpace(code))
            {
                ausfahrt_ausgabe_tb.Text = "Fehler: Bitte Code eingeben!";
                return;
            }

            Dauermieter mieter = DauermieterRepository.PruefeDauermieter(code);

            if (mieter != null)
            {
                if (mieter.MieteBezahlt == false && DateTime.Now.Day >= 15)
                {
                    ausfahrt_ausgabe_tb.Text = "Code gesperrt (Miete ausstehend).";
                }
                else
                {
                    ausfahrt_ausgabe_tb.Text = $"Auf Wiedersehen, {mieter.Vorname}.\r\nSchranke öffnet sich.";
                }
            }
            else
            {
                ausfahrt_ausgabe_tb.Text = "Code ungültig!";
            }

            ausfahrt_code_tb.Clear();
        }

        // --- BEREICH: ADMINISTRATION ---

        private void tarif_verwalten_speichern_btn_Click(object sender, EventArgs e)
        {
            // Wir lesen die Werte aus den NumericUpDown-Feldern (und wandeln sie in double um)
            double preis = (double)tarif_preis_15_min_nud.Value;
            double pauschale = (double)tagespauschale_preis_nud.Value;

            TarifRepository.AktualisiereTarif(preis, pauschale);
        }

        // --- BEREICH: DASHBOARD ---

        public void LadeDashboard()
        {
            // 1. Zuerst leeren wir das Panel komplett (wichtig, falls wir es neu laden)
            dashboard_flp.Controls.Clear();

            int totalPlaetzeGesamt = 0;
            int besetztePlaetzeGesamt = 0;

            // 2. Wir holen die strukturierte Liste aus der Datenbank
            List<StockwerkDaten> stockwerke = ParkhausRepository.HoleDashboardDaten();

            // 3. Für jedes Stockwerk bauen wir einen Kasten (GroupBox)
            foreach (var stockwerk in stockwerke)
            {
                GroupBox gb = new GroupBox();
                gb.Width = dashboard_flp.Width - 30;
                gb.AutoSize = true;
                gb.Margin = new Padding(10, 10, 10, 20);
                // NEU: Innerer Abstand. 30 Pixel oben schützt den Text vor dem Überlappen!
                gb.Padding = new Padding(10, 30, 10, 10);

                FlowLayoutPanel plaetze_flp = new FlowLayoutPanel();
                plaetze_flp.Dock = DockStyle.Fill;
                plaetze_flp.AutoSize = true;

                int stockwerkTotal = 0;
                int stockwerkBesetzt = 0;

                // 4. Wir generieren die bunten Knöpfe für dieses Stockwerk
                foreach (var platz in stockwerk.Plaetze)
                {
                    Button btn = new Button();
                    btn.Size = new Size(50, 50);
                    btn.Text = platz.Nummer.ToString();
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font(btn.Font, FontStyle.Bold);

                    if (platz.DauermieterId != null)
                    {
                        btn.BackColor = Color.RoyalBlue;
                        stockwerkBesetzt++;
                        besetztePlaetzeGesamt++;
                    }
                    else if (platz.Status == "besetzt")
                    {
                        btn.BackColor = Color.Firebrick;
                        stockwerkBesetzt++;
                        besetztePlaetzeGesamt++;
                    }
                    else
                    {
                        btn.BackColor = Color.ForestGreen;
                    }

                    plaetze_flp.Controls.Add(btn);
                    stockwerkTotal++;
                    totalPlaetzeGesamt++;
                }

                double auslastung = stockwerkTotal > 0 ? ((double)stockwerkBesetzt / stockwerkTotal) * 100 : 0;
                gb.Text = $"{stockwerk.Bezeichnung} - Auslastung: {Math.Round(auslastung)}%";

                gb.Controls.Add(plaetze_flp);
                dashboard_flp.Controls.Add(gb);
            }

            // 6. Gesamtauslastung aktualisieren
            double gesamtAuslastung = totalPlaetzeGesamt > 0 ? ((double)besetztePlaetzeGesamt / totalPlaetzeGesamt) * 100 : 0;
            gesamtauslastung_lbl.Text = $"Gesamtauslastung: {Math.Round(gesamtAuslastung)}%";
        }

        private void parkhauskonfiguration_speichern_btn_Click(object sender, EventArgs e)
        {
            int stockwerke = (int)parkhauskonfiguration_stockwerke_nud.Value;
            int plaetze = (int)parkhauskonfiguration_plaetze_nud.Value;

            if (stockwerke == 0 || plaetze == 0)
            {
                MessageBox.Show("Bitte gueltige Werte groesser als 0 eingeben.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Achtung: Dies loescht alle aktuellen Parkplaetze und aktiven Tickets unwiderruflich!\n\nMoechten Sie wirklich fortfahren?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ParkhausRepository.KonfiguriereParkhaus(stockwerke, plaetze);

                // Dashboard neu zeichnen
                LadeDashboard();

                // GANZ WICHTIG: Hier laden wir nun auch das Dropdown fuer die Dauermieter neu!
                LadeDauermieterUI();
            }
        }

        private void report_generieren_btn_Click(object sender, EventArgs e)
        {
            if (umsatz_monat_jahr_cb.SelectedItem == null) return;

            // Wir lesen den gewaehlten Text aus (z.B. "03.2026") und splitten ihn am Punkt auf
            string auswahl = umsatz_monat_jahr_cb.SelectedItem.ToString();
            string[] teile = auswahl.Split('.');

            if (teile.Length == 2)
            {
                int monat = int.Parse(teile[0]);
                int jahr = int.Parse(teile[1]);

                // Abfrage an die Datenbank
                double gesamtUmsatz = ReportRepository.GeneriereMonatsUmsatz(monat, jahr);

                // Ergebnis als Info-Box anzeigen
                MessageBox.Show($"Umsatz-Report für {auswahl}:\r\n\nTotal Einnahmen: {gesamtUmsatz:0.00} CHF", "Monatsabschluss", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dauermieter_anzeigen_btn_Click(object sender, EventArgs e)
        {
            // Holt die Daten aus der Datenbank und bindet sie an dein DataGridView
            dauermieter_anzeigen_dgv.DataSource = DauermieterRepository.HoleAlleDauermieter();

            // Ein kleiner Design-Trick: Passt die Spaltenbreite automatisch an, damit das Raster komplett ausgefüllt wird
            if (dauermieter_anzeigen_dgv.Columns.Count > 0)
            {
                dauermieter_anzeigen_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // Aktualisiert das Dropdown und die Tabelle im Dauermieter-Bereich
        private void LadeDauermieterUI()
        {
            // 1. Tabelle fuellen (Name korrigiert auf dauermieter_anzeigen_dgv)
            if (dauermieter_anzeigen_dgv != null)
            {
                dauermieter_anzeigen_dgv.DataSource = DauermieterRepository.HoleAlleDauermieter();
            }

            // 2. Dropdown mit freien Plaetzen fuellen
            if (dauermieter_parkplatz_cb != null)
            {
                dauermieter_parkplatz_cb.DataSource = ParkplatzRepository.HoleFreiePlaetzeFuerDropdown();
                dauermieter_parkplatz_cb.DisplayMember = "anzeige"; // Was der Benutzer sieht
                dauermieter_parkplatz_cb.ValueMember = "parkplatz_id"; // Die versteckte ID für die Datenbank
            }

            // 3. Dropdown für das Löschen füllen
            if (dauermieter_loeschen_cb != null)
            {
                dauermieter_loeschen_cb.DataSource = DauermieterRepository.HoleAlleDauermieterFuerDropdown();
                dauermieter_loeschen_cb.DisplayMember = "anzeige";
                dauermieter_loeschen_cb.ValueMember = "dauermieter_id";
            }
        }

        // Klick-Event für den Button "Dauermieter anlegen"
        private void dauermieter_anlegen_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dauermieter_name_tb.Text) ||
                string.IsNullOrWhiteSpace(dauermieter_zugangscode_tb.Text) ||
                dauermieter_parkplatz_cb.SelectedValue == null)
            {
                MessageBox.Show("Bitte füllen Sie Name, Code und einen Parkplatz aus.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int parkplatzId = (int)dauermieter_parkplatz_cb.SelectedValue;

            bool erfolg = DauermieterRepository.LegeDauermieterAn(
                dauermieter_name_tb.Text,
                dauermieter_vorname_tb.Text,
                dauermieter_zugangscode_tb.Text,
                dauermieter_bezahlt_cb.Checked,
                dauermieter_vertragsende_dtp.Value,
                parkplatzId
            );

            if (erfolg)
            {
                MessageBox.Show("Dauermieter erfolgreich angelegt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Felder wieder leeren
                dauermieter_name_tb.Clear();
                dauermieter_vorname_tb.Clear();
                dauermieter_zugangscode_tb.Clear();
                dauermieter_bezahlt_cb.Checked = false;

                // UI aktualisieren (Tabelle lädt neu, belegter Platz verschwindet aus Dropdown)
                LadeDauermieterUI();

                // Das Wichtigste: Dashboard aktualisieren, damit der Platz BLAU wird!
                LadeDashboard();
            }
        }

        private void dauermieter_loeschen_btn_Click(object sender, EventArgs e)
        {
            if (dauermieter_loeschen_cb.SelectedValue == null)
            {
                MessageBox.Show("Bitte wählen Sie einen Dauermieter zum Löschen aus.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sicherheitsabfrage, damit man niemanden aus Versehen löscht
            DialogResult result = MessageBox.Show("Möchten Sie diesen Dauermieter wirklich unwiderruflich löschen?\nSein Parkplatz wird dadurch sofort wieder freigegeben.", "Dauermieter löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int mieterId = (int)dauermieter_loeschen_cb.SelectedValue;

                bool erfolg = DauermieterRepository.LoescheDauermieter(mieterId);

                if (erfolg)
                {
                    MessageBox.Show("Dauermieter erfolgreich gelöscht!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Alles aktualisieren (Tabelle, Dropdowns und das Dashboard!)
                    LadeDauermieterUI();
                    LadeDashboard();
                }
            }
        }
    }
}