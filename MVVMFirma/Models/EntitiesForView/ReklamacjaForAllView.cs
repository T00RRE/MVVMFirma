namespace MVVMFirma.Models.EntitiesForView
{
    public class ReklamacjaForAllView
    {
        public int IdReklamacji { get; set; }
        public string Status { get; set; }
        public System.DateTime? DataReklamacji { get; set; }
        public string OpisReklamacji { get; set; }
        
        public string PracownikImie { get; set; }
        public string PracownikNazwisko { get; set; }
        public string Decyzja { get; set; }
    }
}