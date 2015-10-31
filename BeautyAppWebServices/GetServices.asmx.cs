using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;


namespace BeautyAppWebServices
{
    /// <summary>
    /// Summary description for GetServices
    /// </summary>
    [WebService(Namespace = "http://192.168.1.102/Beauty")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GetServices : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]  
        public string GetServicesList()
        {
            SqlConnection con = null;
            DataSet ds = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetServices", con);
                cmd.CommandType = CommandType.StoredProcedure;

                return getDbDataAsJSON(cmd);
             
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string GetServicesList1()
        {
            SqlConnection con = null;
            DataSet ds = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetServices", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);

                DataTable dt = ds.Tables[0];

                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                this.Context.Response.ContentType = "";

                //////////////////



                //////////////////////////


                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string GetServiceTypes(string ServiceCode)
        {
            SqlConnection con = null;
          
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetServiceTypes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCode", ServiceCode);

                return getDbDataAsJSON(cmd);

               
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }


        public String getDbDataAsJSON(SqlCommand cmd)
        {
            try
            {
                DataSet ds = null;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);

                DataTable dt = ds.Tables[0];

                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                this.Context.Response.ContentType = "";

                //////////////////



                //////////////////////////


                return serializer.Serialize(rows);


            }
            catch (Exception)
            {

                return "";
            }
            finally
            {

            }
            
        }


    }
}
