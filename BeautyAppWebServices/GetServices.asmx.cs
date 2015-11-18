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
        public string GetOffers()
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetOffers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                return getDbDataAsJSON(cmd, "OfferImage","ImageName");

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
        public string GetNotifications(string notIDs, string expiryDate)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetNotifications", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Notification_ID", notIDs);
                cmd.Parameters.AddWithValue("@Expiry_Date", expiryDate);

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

        [WebMethod]
        public string GetSearchResults(string ServiceCode, string sTypeCode)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetSearchResults", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCode", ServiceCode);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);

                return getDbDataAsJSON(cmd, "StyleImg", "StyleImageName");


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
        public string GetServiceProviderDetails(string ProviderCode, string sTypeCode)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetServiceProviderDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProviderCode", ProviderCode);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);

                return getDbDataAsJSON(cmd, "ProviderImage", "ProviderImageName");  //passing col names of image and imagefilename


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


        public String getDbDataAsJSON(SqlCommand cmd, String imgColName="", String imgFileNameCol="")
        {
            try
            {
                DataSet ds = null;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);

                DataTable dt = ds.Tables[0];
                String filePath = Server.MapPath("~/tempImages/");      //temporary folder to store images

                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (imgColName == col.ColumnName)                   //checking is that the coloumn contain binary image
                        {
                            if (dr[col] != DBNull.Value)                    //checking for no image uploaded(null)
                            {
                                String fileURL = filePath + DateTime.Now.ToString("ddHHmmssfff") + dr[imgFileNameCol];//timestamping imagefilename
                                if (!System.IO.File.Exists(fileURL))         
                                {
                                    byte[] buffer = (byte[])dr[col];                                
                                    System.IO.File.WriteAllBytes(fileURL, buffer); //writing file with image name from coloumn imgFileNameCol
                                }                                        
                            row.Add("url", fileURL);                        //giving url in JSON
                            }
                        }                                       
                        else                                                              //JSON adding each item
                        {if(col.ColumnName != imgFileNameCol)                           //skipping imageFileName in JSON 
                            row.Add(col.ColumnName, dr[col]);
                        }
                    }
                    rows.Add(row);
                }

                this.Context.Response.ContentType = "";
                
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