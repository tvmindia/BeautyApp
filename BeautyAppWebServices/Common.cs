using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BeautyAppWebServices
{
    public class Common
    {

        public void SendMail(string bookORcancel, string activityTime, string bookingID)
        {
            try
            {
                //get mailing details
                SqlConnection con = null;
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetMailingDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookingID", bookingID);
                SqlParameter outMsg1 = cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 30);
                outMsg1.Direction = ParameterDirection.Output;
                SqlParameter outMsg2 = cmd.Parameters.Add("@mobile", SqlDbType.NVarChar, 20);
                outMsg2.Direction = ParameterDirection.Output;
                SqlParameter outMsg3 = cmd.Parameters.Add("@serviceName", SqlDbType.NVarChar, 20);
                outMsg3.Direction = ParameterDirection.Output;
                SqlParameter outMsg4 = cmd.Parameters.Add("@serviceTypeName", SqlDbType.NVarChar, 20);
                outMsg4.Direction = ParameterDirection.Output;
                SqlParameter outMsg5 = cmd.Parameters.Add("@providerName", SqlDbType.NVarChar, 200);
                outMsg5.Direction = ParameterDirection.Output;
                SqlParameter outMsg6 = cmd.Parameters.Add("@providerMail", SqlDbType.NVarChar, 300);
                outMsg6.Direction = ParameterDirection.Output;
                SqlParameter outMsg7 = cmd.Parameters.Add("@userMail", SqlDbType.NVarChar, 300);
                outMsg7.Direction = ParameterDirection.Output;
                SqlParameter outMsg8 = cmd.Parameters.Add("@timing", SqlDbType.SmallDateTime);
                outMsg8.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                String userName = outMsg1.Value.ToString();
                String mobile = outMsg2.Value.ToString();
                String serviceName = outMsg3.Value.ToString();
                String serviceTypeName = outMsg4.Value.ToString();
                String providerName = outMsg5.Value.ToString();
                String providerMail = outMsg6.Value.ToString();
                String userMail = outMsg7.Value.ToString();
                String timing = outMsg8.Value.ToString();




                string MailTo = "sreejith.thrithvam@gmail.com";//change to providerMail
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("jabaajabaaa@gmail.com");
                Msg.To.Add(MailTo);
                string fileName = System.Web.Hosting.HostingEnvironment.MapPath("~/Templates/mailTemplate.html");//HttpContext.Current.Server.MapPath("~/Templates/mailTemplate.html");// System.Web.Hosting.HostingEnvironment.MapPath("/Templates/mailTemplate.html");//"C:/inetpub/wwwroot/Beauty/Templates/mailTemplate.html";//
                string body = fileName;
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(fileName);
                body = objReader.ReadToEnd();
                //replacing contents
                string title = "Error Mail";
                string contentMsg = "This mail is due to server error in mailing system";
                if (bookORcancel.Equals("book"))
                {
                    contentMsg = "There is a new booking for below mensioned service. Please inform the client whether you can provide the specified service on that time.";
                    title = "New Booking";
                    Msg.Subject = "New booking for " + serviceName;
                    body = body.Replace("$bORc$", "Booked at");

                }
                else if (bookORcancel.Equals("cancel"))
                {
                    contentMsg = "There is a cancellation for on a booking for below mensioned service.";
                    title = "Booking Cancellation";
                    Msg.Subject = "A cancellation on " + serviceName;
                    body = body.Replace("$bORc$", "Cancelled at");
                }
                body = body.Replace("$contentMsg$", contentMsg);
                body = body.Replace("$title$", title);
                body = body.Replace("$providerName$", providerName);
                body = body.Replace("$serviceName$", serviceName);
                body = body.Replace("$serviceType$", serviceTypeName);
                body = body.Replace("$timing$", timing);
                body = body.Replace("$bORCtime$", activityTime);
                body = body.Replace("$clientName$", userName);
                body = body.Replace("$clientContact$", userMail);
                body = body.Replace("$clientPhone$", mobile);
                body = body.Replace("$bookingID$", bookingID);


                Msg.Body = body;
                Msg.IsBodyHtml = true;
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("info.thrithvam", "thrithvam@2015");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                Msg = null;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}