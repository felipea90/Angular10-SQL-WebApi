using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DepartamentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select DepartamentId, DepartamentName 
                           from dbo.Departament";

            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Departament dep)
        {
            try
            {
                string query = @"insert into dbo.Departament 
                               values ('"+dep.DepartamentName+ @"')";

                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!";
            }
            catch (Exception)
            {

                return "Failed to Add!";
            }
        }

        public string Put(Departament dep)
        {
            try
            {
                string query = @"update dbo.Departament 
                               set DepartamentName='" + dep.DepartamentName + @"' 
                               where DepartamentId=" + dep.DepartamentId + @" ";

                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!";
            }
            catch (Exception)
            {

                return "Failed to Update!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Departament  
                               where DepartamentId=" + id + @" ";

                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!";
            }
            catch (Exception)
            {

                return "Failed to Delete!";
            }
        }
    }
}
