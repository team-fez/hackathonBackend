using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.UI.WebControls;
using Dapper;
using RedList.Models;

namespace RedList.Controllers
{
    public class ImportController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RedList;Integrated Security=SSPI;"))
            {
                conn.Open();
                var file = new StreamReader(@"C:\Users\Ruben\Desktop\DataExportFraArtskart1.txt");
                //var test = file.ReadToEnd();
                //var objects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<wikiStuff>>(test);

                //foreach (var specie in objects)
                //{
                   
                //   var summary = specie.summary.Replace("'", "''");
                //    if (summary.Length > 3999)
                //    {
                //        summary =summary.Substring(0, 3999);
                //    }
                //    conn.Execute(string.Format("update species set Wikiurl='{1}', summary ='{2}' where id= {0}", specie.Id, specie.wikipediaUrl, summary));
                //}
                while (!file.EndOfStream)
                {  
                    var line = file.ReadLine();


                    double longitude;
                    double latidude;
                        
                    var sl = line.Replace("'","").Replace('"',' ').Split(';');
                    if (sl.Length > 68 && double.TryParse(sl[38],out longitude) && Double.TryParse(sl[39], out latidude))
                    {
                        conn.Execute(
                       String.Format("insert into Observation (Name,Longitude,Latitude,County) values('{0}','{1}','{2}','{3}')", sl[7], sl[38], sl[39], sl[35]));    
                    }
                    
                    //var zomg =
                    //    String.Format(
                    //        @"update Species set ostfold ='{0}', akershus = '{1}', oslo = '{1}', hedmark = '{2}', oppland = '{3}', buskerud = '{4}', vestfold= '{5}',telemark = '{6}',austagder='{7}',vestagder ='{8}',rogaland='{9}',hordaland='{10}',Sogn_og_Fjordane = '{11}', moreogromsdal='{12}',sortrondelag = '{13}', nordtrondelag = '{14}', nordland = '{15}',troms ='{16}', finnmark ='{17}'  where Name like '{18}'",
                    //        sl[6], sl[7], sl[8], sl[9], sl[10], sl[11], sl[12], sl[13], sl[14], sl[15], sl[16], sl[17],
                    //        sl[18], sl[19], sl[20], sl[21], sl[22], sl[23],sl[0]);

                    //conn.Execute(
                    //    String.Format(@zomg));
                }
            }


            
            


            return Ok("");
        }
    }
}
