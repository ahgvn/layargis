using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
public static class Helper
{
	static Helper()
	{
		ReadXML();
	}

    public static string ServiceURL
    {
        get
        {
            return "http://services.arcgis.com/zmBQLV64TsFvEpV0/arcgis/rest/services/LayarPOIs/FeatureServer/0";
        }
    }

    public static void ReadXML()
    {
        // read xml
        
    }
}