using System;
using System.IO;
using System.Web;

namespace WebApplication1.Controllers
{
    public class Download : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
            string file = context.Request.QueryString["file"];

            if (!string.IsNullOrEmpty(file) && File.Exists(context.Server.MapPath(file)))
            {
                context.Response.Clear();
                context.Response.ContentType = "application/octet-stream";
                context.Response.AddHeader("content-disposition", "attachment;filename=" + Path.GetFileName(file));
                context.Response.WriteFile(context.Server.MapPath(file));
                // This would be the ideal spot to collect some download statistics and / or tracking  
                // also, you could implement other requests, such as delete the file after download  
                context.Response.End();

            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("File not be found!");


            }
        }

        #endregion
    }
}
