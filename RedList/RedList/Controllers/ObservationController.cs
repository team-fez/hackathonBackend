using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using RedList.Models;

namespace RedList.Controllers
{
    public class ObservationController : ApiController
    {

        public IHttpActionResult Get(string name, string county)
        {
            var observations = new List<Observation>();
            using (
                var conn =
                    new SqlConnection(
                        @"Data Source=localhost\SQLEXPRESS;Initial Catalog=RedList;Integrated Security=SSPI;"))
            {
                var parsedCounty = county.Replace("_", "-").ToLower();


                conn.Open();
                observations =
                    conn.Query<Observation>(
                        string.Format("select * from Observation where name like '{1}' ", parsedCounty,
                            name)).ToList();

            }

            return Ok(observations);
        }
    }
}
