using System;

namespace ParkhausSW
{
    public class Ticket
    {
        public string TicketNummer { get; private set; }
        public DateTime EinfahrtsZeit { get; private set; }
        public DateTime? BezahlZeit { get; private set; }
        public double Betrag { get; private set; }
        public bool IstBezahlt { get; private set; }

        public Ticket(string nummer)
        {
            TicketNummer = nummer;
            // Startzeitpunkt wird auf die exakte Systemzeit gesetzt
            EinfahrtsZeit = DateTime.Now;
            IstBezahlt = false;
            Betrag = 0.0;
        }

        // Methode zur Bezahlvorgangs
        public void TicketBezahlen(double berechneterBetrag)
        {
            Betrag = berechneterBetrag;
            IstBezahlt = true;
            // Zeitpunkt der Zahlung festhalten, um die 15-Minuten-Zeit zu prüfen.
            BezahlZeit = DateTime.Now;
        }

        // Überprüfung der Gültigkeit
        public bool IstGueltigFuerAusfahrt()
        {
            // Ticket muss zwingend bezahlt sein, ansonsten keine Ausfahrt
            if (!IstBezahlt || BezahlZeit == null)
            {
                return false;
            }

            // Prüfung der 15-Minuten-Zeit
            TimeSpan zeitSeitBezahlung = DateTime.Now - BezahlZeit.Value;
            if (zeitSeitBezahlung.TotalMinutes > 15)
            {
                return false;
            }

            return true;
        }

        // Dies sorgt dafür, dass in der Dropdown-Liste lesbarer Text (z.B. "Ticket #001") angezeigt wird
        public override string ToString()
        {
            return $"Ticket #{TicketNummer}";
        }
    }
}