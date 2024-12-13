using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    //ta Klasa jest wzorowana na klasie faktura tylko zamiast kluczy obcych ma czytelne dla klienta pola (klucze obce będą zastąpione czytelnymi dla zwykłego śmiertelnika danymi)
    public class FakturaForAllView
    {
        public string Numer { get; set; }
        public bool CzyZatwierdzona { get; set; }
        public DateTime DataWystawienia { get; set; }
        //nip i nazwa będzie zamiast klucza obcego idKontrahenta
        public string KontrahentNIP { get; set; }
        public string KontrahentNazwa {  get; set; }
        public DateTime TerminPlatosci {  get; set; }
        // to jest pole zamiast klucza obcego idSposobuPlatnosci
        public string SposobuPlatnosciNazwa { get; set; }
    }
}
