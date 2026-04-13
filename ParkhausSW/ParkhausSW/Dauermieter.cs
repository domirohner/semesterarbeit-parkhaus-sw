using System;

namespace ParkhausSW
{
    public class Dauermieter
    {
        public int DauermieterId { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Zugangscode { get; set; }
        public bool MieteBezahlt { get; set; }
        public DateTime? Vertragsende { get; set; }
    }
}