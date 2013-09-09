using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Collections.Specialized;


/// <summary>
/// Summary description for AGSpunt
/// </summary>
public class AGSpunt
{
    private string _displayFieldName;
    private string _geometryType;
    private Hashtable _fieldAliases;
    private Hashtable _spatialReference;
    private List<AGSfeature> _features;
    private List<AGSfield> _fields;

	public AGSpunt()
	{
        _displayFieldName = "";
        _geometryType = "";
        _spatialReference = new Hashtable();
        _features = new List<AGSfeature>();
        _fields = new List<AGSfield>();
        _fieldAliases = new Hashtable();
	}

    public POI ConvertToPOI(decimal locationx, decimal locationy, int radius)
    {
        POI _poi = new POI();

        _poi.layer = "rhdhvlocations";
        _poi.morePages = false;
        _poi.nextPageKey = "67234fga";

        foreach (AGSfeature feat in _features)
        {
            try
            {
                Hotspot hotspot = new Hotspot();
                if (feat.attributes["id"] != null)
                {
                    hotspot.id = feat.attributes["id"].ToString();
                }
                else { hotspot.id = "1"; }
                hotspot.lat = (int)(feat.geometry.y * 1000000);
                hotspot.lon = (int)(feat.geometry.x * 1000000);

                if (feat.attributes["titel_en"] != null)
                {
                    hotspot.title = feat.attributes["titel_en"].ToString();
                    hotspot.attribution = feat.attributes["titel_en"].ToString();
                }
                else
                {
                    hotspot.title = "unknown";
                    hotspot.attribution = "unknown";
                }

                if (feat.attributes["oms_en"] != null)
                {
                    hotspot.line2 = feat.attributes["oms_en"].ToString();
                }
                if (feat.attributes["soort"] != null)
                {
                    hotspot.line3 = feat.attributes["soort"].ToString();
                }
                if (feat.attributes["url_en"] != null)
                {
                    hotspot.line4 = feat.attributes["url_en"].ToString();
                }
                else
                {
                    if (feat.attributes["url_nl"] != null)
                    {
                        hotspot.line4 = feat.attributes["url_nl"].ToString();
                    }
                }
                if (feat.attributes["figuur"] != null)
                {
                    hotspot.imageURL = feat.attributes["figuur"].ToString();
                }
                hotspot.distance = 0;
                if (locationx != 0 && locationy != 0)
                {
                    hotspot.distance = (decimal)(((Math.Acos(Math.Sin(((double)locationy * Math.PI / 180)) * Math.Sin((feat.geometry.y * Math.PI / 180)) +
                             Math.Cos(((double)locationy * Math.PI / 180)) * Math.Cos((feat.geometry.y * Math.PI / 180)) *
                           Math.Cos(((double)locationx - feat.geometry.x) * Math.PI / 180))
                          ) * 180 / Math.PI) * 60 * 1.1515 * 1.609344 * 1000);
                }
                hotspot.type = 0;

                hotspot.dimension = 1;
                Object3D obj = new Object3D();
                obj.baseURL = "http://dev.geosolutions.nl/LayarPOI/assets/jason/";
                obj.full = "full.l3d";
                obj.size = 10;
                hotspot.Object = null;

                Transform trans = new Transform();
                trans.angle = 0;
                trans.rel = true;
                trans.scale = 1.0m;
                hotspot.transform = null;

                if (radius == 0)
                {
                    _poi.AddHotspot(hotspot);
                }
                else
                {
                    if (hotspot.distance < radius)
                    {
                        _poi.AddHotspot(hotspot);
                    }
                }

            } catch (Exception err){
                // nothing
            }

        }

        return _poi;
    }

    public POI ConvertToPOI()
    {
        return this.ConvertToPOI(0,0,0);
    }

    #region Serializable members

    [System.Runtime.Serialization.DataMemberAttribute]
    public string displayFieldName
    {
        get
        {
            return _displayFieldName;
        }
        set 
        {
            _displayFieldName = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string geometryType
    {
        get
        {
            return _geometryType;
        }
        set 
        {
            _geometryType = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public Hashtable spatialReference
    {
        get
        {
            return _spatialReference;
        }
        set 
        {
            _spatialReference = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public Hashtable fieldAliases
    {
        get
        {
            return _fieldAliases;
        }
        set 
        {
            _fieldAliases = value;
        }
    }


    [System.Runtime.Serialization.DataMemberAttribute]
    public List<AGSfeature> features
    {
        get
        {
            return _features;
        }
        set 
        {
            _features = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public List<AGSfield> fields
    {
        get
        {
            return _fields;
        }
        set 
        {
            _fields = value;
        }
    }

    #endregion
}

public class AGSfeature
{
    private AGSgeometry _geometry;
    private Hashtable _attributes;

    public AGSfeature()
    {
        _geometry = new AGSgeometry();
        _attributes = new Hashtable();
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public AGSgeometry geometry
    {
        get
        {
            return _geometry;
        }
        set 
        {
            _geometry = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public Hashtable attributes
    {
        get
        {
            return _attributes;
        }
        set 
        {
            _attributes = value;
        }
    }

}

public class AGSgeometry
{
    private double _x;
    private double _y;

    public AGSgeometry()
    {
        _x = 0;
        _y = 0;
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public double x
    {
        get
        {
            return _x;
        }
        set 
        {
            _x = value;
        }
    }
    [System.Runtime.Serialization.DataMemberAttribute]
    public double y
    {
        get
        {
            return _y;
        }
        set
        {
            _y = value;
        }
    }
}

public class AGSfield
{
    private string _name;
    private string _type;
    private int _length;
    private string _alias;

    public AGSfield()
    {
        _name = "";
        _type = "";
        _length = 0;
        _alias = "";
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string name
    {
        get
        {
            return _name;
        }
        set 
        {
            _name = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string type
    {
        get
        {
            return _type;
        }
        set 
        {
            _type = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string alias
    {
        get
        {
            return _alias;
        }
        set 
        {
            _alias = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public int length
    {
        get
        {
            return _length;
        }
        set 
        {
            _length = value;
        }
    }
}
