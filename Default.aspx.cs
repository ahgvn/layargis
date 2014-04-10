using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;
using RoyalHaskoning.rhLogger;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    // private readonly static string ServiceUrl = ConfigurationManager.AppSettings["ags"] + "/query?geometryType=esriGeometryPoint&where=id+>+-1&returnCountOnly=false&returnIdsOnly=false&returnGeometry=true&outFields=*&f=pjson";
    private clsLogger logger;

    protected void Page_Load(object sender, EventArgs e)
    {

        logger = new clsLogger(ConfigurationManager.AppSettings["logpath"]);
        
        // querystring en een paar andere gegevens loggen
        logger.rhAddlog(Page.Request.Url + "; IP=" + Page.Request.UserHostAddress);

        try
        {
            // a small change
            // Querystring ophalen, http://localhost:1867/LayarPOI/?lat=51.824732&lon=5.82530&radius=3000
            decimal lat = 0;
            decimal lon = 0;
            int radius = 2500;  // default

            if (Page.Request.QueryString["lat"] != null && Page.Request.QueryString["lon"] != null)
            {
                if (!decimal.TryParse(Page.Request.QueryString["lat"], out lat))
                {
                    throw new ArgumentException("lat argument is not formatted correctly...");
                }
                if (!decimal.TryParse(Page.Request.QueryString["lon"], out lon))
                {
                    throw new ArgumentException("lon argument is not formatted correctly...");
                }
                if (Page.Request.QueryString["radius"] != null)
                {
                    if (!int.TryParse(Page.Request.QueryString["radius"], out radius))
                    {
                        throw new ArgumentException("radius argument is not formatted correctly...");
                    }
                }
            }

            // REST ophalen

            string json = GetREST();
            AGSpoint punt = JsonConvert.DeserializeObject<AGSpoint>(json);

            // van AGSpunt naar POI

            POI myPOI = punt.ConvertToPOI(lon, lat, radius);

            // POI naar JSON

            string jsonString = JsonConvert.SerializeObject(myPOI, Formatting.Indented);

            // workaround to replace Object with object
            jsonString = jsonString.Replace("Object", "object");

            Response.Clear();
            Response.Write(jsonString);

        } catch (Exception err){
            logger.rhAddlog(err.Message);
        }
    }

    
    public static string GetREST()
    {
        string formattedUri = String.Format(CultureInfo.InvariantCulture,
                              Helper.ServiceURL + "/query?geometryType=esriGeometryPoint&where=id+>+-1&returnCountOnly=false&returnIdsOnly=false&returnGeometry=true&outFields=*&f=pjson");

        HttpWebRequest webRequest = GetWebRequest(formattedUri);
        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
        string jsonResponse = string.Empty;
        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
        {
            jsonResponse = sr.ReadToEnd();
        }
        return jsonResponse;
    }

    private static HttpWebRequest GetWebRequest(string formattedUri)
    {
        // Create the request’s URI.
        Uri serviceUri = new Uri(formattedUri, UriKind.Absolute);

        // Return the HttpWebRequest.
        return (HttpWebRequest)System.Net.WebRequest.Create(serviceUri);
    }
}
