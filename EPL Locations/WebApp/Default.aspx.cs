using EPLAccessPoint;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateLibraryData();
            }
        }

        private void PopulateLibraryData()
        {
            // From https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(BranchData.QueryUrl(null, null));
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.  
            reader.Close();
            response.Close();


            // From https://stackoverflow.com/a/39902334
            var doc = new XmlDocument();
            doc.LoadXml(responseFromServer); //or XDocument.Load(path)
            string jsonText = JsonConvert.SerializeXmlNode(doc.LastChild, Newtonsoft.Json.Formatting.Indented, true);
            var dyn = JsonConvert.DeserializeObject<EPLBranches>(jsonText);

            // Bind to display
            //EPLBranchView.DataSource = dyn.BranchesInfo
            //EPLBranchView.DataBind();
        }
    }
}