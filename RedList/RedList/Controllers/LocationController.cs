
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Dapper;
using RedList.Models;

namespace RedList.Controllers
{
    public class LocationController : ApiController
    {
        readonly Specie _specie = new Specie{ Id=1,Name = "Hei"};
        
        public IHttpActionResult Get()
        {
             using (var conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RedList;Integrated Security=SSPI;")) {
                    conn.Open();
                 var lol = conn.Query<Specie>("select * from Species");
                 var bah = "sdf";
             }
            return Ok(_specie);
        }
        public IHttpActionResult GetSpecies()
        {
            var species = new List<Specie>();
            using (var conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RedList;Integrated Security=SSPI;"))
            {
                conn.Open();
                species = conn.Query<Specie>("select * from Species").ToList();
                var images = conn.Query<Image>("select * from Images").ToList();
                foreach (var specie in species)
                {
                    specie.Images = images.Where(x => x.SpecieId == specie.Id).ToList();
                }
                
            }
            return Ok(species);
        }
        public IHttpActionResult GetSpeciesByCounty(string county)
        {
            var species = new List<Specie>();
            var selected = new List<Specie>();
            using (var conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RedList;Integrated Security=SSPI;"))
            {
                conn.Open();
                species = conn.Query<Specie>("select * from Species").ToList();
                var images = conn.Query<Image>("select * from Images").ToList();
               

                switch (county)
                {
                    case "Østfold" :
                        selected = species.Where(x => (x.Ostfold == "Kjent" || x.Ostfold == "Antatt")).ToList();
                        break;
                    case "Akershus" :
                        selected = species.Where(x => (x.Akershus == "Kjent" || x.Akershus == "Antatt")).ToList();
                        break;
                    case "Oslo":
                        selected = species.Where(x => (x.Oslo == "Kjent" || x.Oslo == "Antatt")).ToList();
                        break;
                    case "Hedmark" :
                        selected = species.Where(x => (x.Hedmark == "Kjent" || x.Hedmark == "Antatt")).ToList();
                        break;
                    case "Oppland" :
                        selected = species.Where(x => (x.Oppland == "Kjent" || x.Oppland == "Antatt")).ToList();
                        break;
                    case "Buskerud" :
                        selected = species.Where(x => (x.Buskerud == "Kjent" || x.Buskerud == "Antatt")).ToList();
                        break;
                    case "Vestfold" :
                        selected = species.Where(x => (x.Vestfold == "Kjent" || x.Vestfold == "Antatt")).ToList();
                        break;
                    case "Telemark" :
                        selected = species.Where(x => (x.Telemark == "Kjent" || x.Telemark == "Antatt")).ToList();
                        break;
                    case "Aust_Agder" :
                        selected = species.Where(x => (x.AustAgder == "Kjent" || x.AustAgder == "Antatt")).ToList();
                        break;
                    case "Vest_Agder" :
                        selected = species.Where(x => (x.VestAgder == "Kjent" || x.VestAgder == "Antatt")).ToList();
                        break;
                    case "Rogaland" :
                        selected = species.Where(x => (x.Rogaland == "Kjent" || x.Rogaland == "Antatt")).ToList();
                        break;
                    case "Hordaland" :
                        selected = species.Where(x => (x.Hordaland == "Kjent" || x.Hordaland == "Antatt")).ToList();
                        break;
                    case "Sogn_og_Fjordane" :
                        selected = species.Where(x => (x.SognogFjordane == "Kjent" || x.SognogFjordane == "Antatt")).ToList();
                        break;
                    case "Møre_og_Romsdal" :
                        selected = species.Where(x => (x.MoreogRomsdal == "Kjent" || x.MoreogRomsdal == "Antatt")).ToList();
                        break;
                    case "Sør_Trøndelag" :
                        selected = species.Where(x => (x.SorTrondelag == "Kjent" || x.SorTrondelag == "Antatt")).ToList();
                        break;
                    case "Nord_Trøndelag" :
                        selected = species.Where(x => (x.NordTrondelag == "Kjent" || x.NordTrondelag == "Antatt")).ToList();
                        break;
                    case "Nordland" :
                        selected = species.Where(x => (x.Nordland == "Kjent" || x.Nordland == "Antatt")).ToList();
                        break;
                    case "Troms" :
                        selected = species.Where(x => (x.Troms == "Kjent" || x.Troms == "Antatt")).ToList();
                        break;
                    case "Finnmark":
                        selected = species.Where(x => (x.Finnmark == "Kjent" || x.Finnmark == "Antatt")).ToList();
                        break;
                }
                foreach (var specie in selected)
                {
                    specie.Images = images.Where(x => x.SpecieId == specie.Id).ToList();
                }
            }
            return Ok(selected);
        }
        public IHttpActionResult GetCountOnLocation()
        {
            var locationCount = new LocationCount();
            var species = new List<Specie>();
            using (var conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RedList;Integrated Security=SSPI;"))
            {
                
                conn.Open();
                species = conn.Query<Specie>("select * from Species where category not like 'LC'").ToList();
                
                foreach (var specie in species)
                {
                    if (!string.IsNullOrWhiteSpace(specie.Hordaland) || !string.IsNullOrWhiteSpace(specie.Hordaland))
                        locationCount.Hordaland++;
                    if (!string.IsNullOrWhiteSpace(specie.Akershus) || !string.IsNullOrWhiteSpace(specie.Akershus))
                        locationCount.Akershus++;
                    if (!string.IsNullOrWhiteSpace(specie.AustAgder) || !string.IsNullOrWhiteSpace(specie.AustAgder))
                        locationCount.Aust_Agder++;
                    if (!string.IsNullOrWhiteSpace(specie.Buskerud) || !string.IsNullOrWhiteSpace(specie.Buskerud))
                        locationCount.Buskerud++;
                    if (!string.IsNullOrWhiteSpace(specie.Finnmark) || !string.IsNullOrWhiteSpace(specie.Finnmark))
                        locationCount.Finnmark++;
                    if (!string.IsNullOrWhiteSpace(specie.Hedmark) || !string.IsNullOrWhiteSpace(specie.Hedmark))
                        locationCount.Hedmark++;
                    if (!string.IsNullOrWhiteSpace(specie.MoreogRomsdal) || !string.IsNullOrWhiteSpace(specie.MoreogRomsdal))
                        locationCount.Møre_og_Romsdal++;
                    if (!string.IsNullOrWhiteSpace(specie.NordTrondelag) || !string.IsNullOrWhiteSpace(specie.NordTrondelag))
                        locationCount.Nord_Trøndelag++;
                    if (!string.IsNullOrWhiteSpace(specie.Nordland) || !string.IsNullOrWhiteSpace(specie.Nordland))
                        locationCount.Nordland++;
                    if (!string.IsNullOrWhiteSpace(specie.Oppland) || !string.IsNullOrWhiteSpace(specie.Oppland))
                        locationCount.Oppland++;
                    if (!string.IsNullOrWhiteSpace(specie.Oslo) || !string.IsNullOrWhiteSpace(specie.Oslo))
                        locationCount.Oslo++;
                    if (!string.IsNullOrWhiteSpace(specie.Ostfold) || !string.IsNullOrWhiteSpace(specie.Ostfold))
                        locationCount.Østfold++;
                    if (!string.IsNullOrWhiteSpace(specie.Rogaland) || !string.IsNullOrWhiteSpace(specie.Rogaland))
                        locationCount.Rogaland++;
                    if (!string.IsNullOrWhiteSpace(specie.SognogFjordane) || !string.IsNullOrWhiteSpace(specie.SognogFjordane))
                        locationCount.Sogn_og_Fjordane++;
                    if (!string.IsNullOrWhiteSpace(specie.SorTrondelag) || !string.IsNullOrWhiteSpace(specie.SorTrondelag))
                        locationCount.Sør_Trøndelag++;
                    if (!string.IsNullOrWhiteSpace(specie.Telemark) || !string.IsNullOrWhiteSpace(specie.Telemark))
                        locationCount.Telemark++;
                    if (!string.IsNullOrWhiteSpace(specie.Troms) || !string.IsNullOrWhiteSpace(specie.Troms))
                        locationCount.Troms++;
                    if (!string.IsNullOrWhiteSpace(specie.VestAgder) || !string.IsNullOrWhiteSpace(specie.VestAgder))
                        locationCount.Vest_Agder++;
                    if (!string.IsNullOrWhiteSpace(specie.Vestfold) || !string.IsNullOrWhiteSpace(specie.Vestfold))
                        locationCount.Vestfold++;
                }

                
            }
            return Ok(locationCount);
        }

    }

   
}
