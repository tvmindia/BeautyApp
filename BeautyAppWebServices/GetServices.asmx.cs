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
using System.Collections;


namespace BeautyAppWebServices
{
 
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
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("OfferImage");
                imgFileNameCols.Add("ImageName");
                return getDbDataAsJSON(cmd, imgColNames, imgFileNameCols);

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
        public string GetNotifications(string notIDs)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetNotifications", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Notification_ID", notIDs);

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
        public string GetSearchResults(string ServiceCode, string sTypeCode, string user)
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
                cmd.Parameters.AddWithValue("@user", user);
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("StyleImg");
                imgFileNameCols.Add("StyleImageName");
                return getDbDataAsJSON(cmd, imgColNames, imgFileNameCols);


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
        public string AddToFavorites(string user, string sTypeCode, string providerCode,string addORremove)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("AddFavorites", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);
                cmd.Parameters.AddWithValue("@provider", providerCode);
                cmd.Parameters.AddWithValue("@addORremove", addORremove);
                cmd.ExecuteNonQuery();
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
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("ProviderImage");
                imgFileNameCols.Add("ProviderImageName");
                imgColNames.Add("StyleImg");
                imgFileNameCols.Add("StyleImageName");
                return getDbDataAsJSON(cmd, imgColNames,imgFileNameCols);  //passing col names of image and imagefilename
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
        public string GetDetailsOfItems(string ProviderCode, string serviceCode, string sTypeCode)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetDetailsOfItems", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProviderCode", ProviderCode);
                cmd.Parameters.AddWithValue("@serviceCode", serviceCode);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("StyleImg");
                imgFileNameCols.Add("StyleImageName");
                return getDbDataAsJSON(cmd, imgColNames, imgFileNameCols);  //passing col names of image and imagefilename
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


        public String getDbDataAsJSON(SqlCommand cmd, ArrayList imgColName, ArrayList imgFileNameCol)
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
                    //adding data in JSON
                    foreach (DataColumn col in dt.Columns)
                    {
                        if ( !imgColName.Contains(col.ColumnName))                  
                       {
                         if( !imgFileNameCol.Contains(col.ColumnName))                           
                             row.Add(col.ColumnName, dr[col]);
                        }
                    }
                    //adding image details in JSON
                    for (int i = 0; i < imgColName.Count; i++)
                    {
                        if (dr[imgColName[i]as string] != DBNull.Value)
                        {
                            String fileURL = filePath + DateTime.Now.ToString("ddHHmmssfff") + dr[imgFileNameCol[i] as string];
                            if (!System.IO.File.Exists(fileURL))
                            {
                                byte[] buffer = (byte[])dr[imgColName[i] as string];
                                System.IO.File.WriteAllBytes(fileURL, buffer);
                            }
                            row.Add(imgColName[i] as string, fileURL);
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