namespace MVVMFirma.Models.EntitiesForView
{
    public class StanMagazynowyForAllView
    {
        public int IdStanu { get; set; }
        public string TowarNazwa { get; set; }
        public string MagazynNazwa { get; set; }
        public int Ilosc { get; set; }            
        public int? MinimalnyPoziom { get; set; } 
        public int? MaxymalnyPoziom { get; set; }  
    }
}