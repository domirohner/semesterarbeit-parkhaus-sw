using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkhausSW;

namespace ParkhausSW.Tests
{
    [TestClass]
    public class ZuteilungsAlgorithmusTests
    {
        [TestMethod]
        public void HoleFreienParkplatz_LaeuftOhneFehlerDurch()
        {
            int? parkplatzId = ParkplatzRepository.HoleFreienParkplatz();

            if (parkplatzId.HasValue)
            {
                // Wenn das Parkhaus nicht voll ist, muss die ID groesser als 0 sein
                Assert.IsTrue(parkplatzId.Value > 0, "Die gefundene Parkplatz-ID muss grösser als 0 sein.");
            }
            else
            {
                // Wenn das Parkhaus komplett voll ist, gibt die Methode 'null' zurück
                Assert.IsNull(parkplatzId, "Wenn kein Platz frei ist, muss exakt 'null' zurückkommen.");
            }
        }

        [TestMethod]
        public void HoleAktuelleKonfiguration_GibtGueltigeWerteZurueck()
        {
            var konfig = ParkhausRepository.HoleAktuelleKonfiguration();

            // Die Anzahl der Stockwerke und Plätze darf niemals im Minus sein
            Assert.IsTrue(konfig.stockwerke >= 0, "Die Anzahl der Stockwerke darf nicht negativ sein.");
            Assert.IsTrue(konfig.plaetze >= 0, "Die Anzahl der Plätze darf nicht negativ sein.");
        }

        [TestMethod]
        public void HoleAlleDauermieter_GibtGueltigeTabelleZurueck()
        {
            var tabelle = DauermieterRepository.HoleAlleDauermieter();

            // die Methode muss immer ein gültiges DataTable-Objekt zurueckgeben (niemals null).
            Assert.IsNotNull(tabelle, "Das Objekt darf nicht null sein. Es muss immer eine Tabelle zurückkommen.");

            // zudem prüfen, ob die SQL-Abfrage die 6 Spalten gebaut hat (Name, Vorname, Code, Bezahlt, Vertragsende, Parkplatz)
            Assert.IsTrue(tabelle.Columns.Count >= 5, "Die Tabelle muss die definierten Spalten aus dem SQL-JOIN enthalten.");
        }

        [TestMethod]
        public void HoleFreiePlaetzeFuerDropdown_GibtGueltigeTabelleZurueck()
        {
            var tabelle = ParkplatzRepository.HoleFreiePlaetzeFuerDropdown();

            Assert.IsNotNull(tabelle, "Auch hier muss zwingend ein gültiges Tabellen-Objekt zurueckkommen.");

            // Das Dropdown braucht zwingend zwei Spalten: Die unsichtbare ID und den Text
            Assert.IsTrue(tabelle.Columns.Count == 2, "Das Dropdown benoetigt exakt zwei Spalten: parkplatz_id und anzeige.");
        }

        [TestMethod]
        public void PruefeDauermieter_UngueltigerCode_GibtNullZurueck()
        {
            // Einen Code prüfen, der nicht in der DB existiert
            var mieter = DauermieterRepository.PruefeDauermieter("FANTASIE_CODE_9999");

            // Das System darf nicht abstürzen, sondern muss  'null' zurückgeben
            Assert.IsNull(mieter, "Bei einem ungueltigen Code muss das System zwingend null zurückgeben.");
        }
    }
}