using System.Collections.Generic;

namespace RedList.Models
{
    public class Specie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NorwegianName { get; set; }
        public string Category { get; set; }
        public string SpeciesGroup { get; set; }
        public string WikiUrl { get; set; }
        public string Summary { get; set; }
        public List<Image> Images { get; set; }
        public string Ostfold { get; set; }
        public string Akershus { get; set; }
        public string Oslo { get; set; }
        public string Hedmark { get; set; }
        public string Oppland { get; set; }
        public string Buskerud { get; set; }
        public string Vestfold { get; set; }
        public string Telemark { get; set; }
        public string AustAgder { get; set; }
        public string VestAgder { get; set; }
        public string Rogaland { get; set; }
        public string Hordaland { get; set; }
        public string SognogFjordane { get; set; }
        public string MoreogRomsdal { get; set; }
        public string SorTrondelag { get; set; }
        public string NordTrondelag { get; set; }
        public string Nordland { get; set; }
        public string Troms { get; set; }
        public string Finnmark { get; set; }
    }
}