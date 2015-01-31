using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedList.Models
{
    public class wikiStuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NorwegianName { get; set; }
        public string Category { get; set; }
        public string SpeciesGroup { get; set; }
        public string wikipediaUrl { get; set; }
        public string summary { get; set; }
        public List<string> images { get; set; } 
    }
}