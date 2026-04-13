using System;

namespace ParkhausSW
{
    public class TicketDaten
    {
        public int ParkplatzId { get; set; }
        public DateTime Einfahrtszeit { get; set; }
        public DateTime? Bezahlzeit { get; set; }
        public string Status { get; set; }
        public double PreisPro15Min { get; set; }
        public double Tagespauschale { get; set; }
    }
}