using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Collections;
using System.Configuration;

/// <summary>
/// Summary description for POIList
/// </summary>
[System.Runtime.Serialization.DataContractAttribute] 
public class POI
{

    private string _layer;
    private string _errorString;
    private bool _morePages;
    private string _errorCode;
    private string _nextPageKey;
    private List<String> _actions;
    private List<Hotspot> _hotspots;

	public POI()
	{
        _layer = "";
        _errorString = "ok";
        _morePages = false;
        _errorCode = "0";
        _nextPageKey = "null";
        _hotspots = new List<Hotspot>();
        _actions = new List<String>();
    }

    #region Serializable members

    [System.Runtime.Serialization.DataMemberAttribute]
    public string layer
    {
        get
        {
            return _layer;
        }
        set 
        {
            _layer = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public List<Hotspot> hotspots
    {
        get 
        {
            return _hotspots; 
        }
        set 
        {
            _hotspots = value;
        }
    }


    [System.Runtime.Serialization.DataMemberAttribute]
    public bool morePages
    {
        get
        {
            return _morePages;
        }
        set 
        {
            _morePages = value;
        }
    }


    [System.Runtime.Serialization.DataMemberAttribute]
    public string errorString
    {
        get
        {
            return _errorString;
        }
        set 
        {
            _errorString = value;
        }
    }


    [System.Runtime.Serialization.DataMemberAttribute]
    public string errorCode
    {
        get
        {
            return _errorCode;
        }
        set 
        {
            _errorCode = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string nextPageKey
    {
        get
        {
            return _nextPageKey;
        }
        set 
        {
            _nextPageKey = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public List<String> actions
    {
        get
        {
            return _actions;
        }
        set 
        {
            _actions = value;
        }
    }

    #endregion

    #region Non-serializable members

    public void AddAction(string actiontext)
    {
        _actions.Add(actiontext);
    }

    public void AddHotspot(Hotspot hotspot)
    {
        _hotspots.Add(hotspot);
    }

    #endregion
}

[System.Runtime.Serialization.DataContractAttribute] 
public class Hotspot
{
    private string _id;
    private decimal _distance;
    private string _title;
    private string _imageURL;
    private int _type;
    private int _lat;
    private int _lon;
    private string _attribution;
    private string _line2;
    private string _line3;
    private string _line4;
    private Object3D _object;
    private Transform _transform;
    private int _dimension;
    private List<String> _actions;

    public Hotspot()
    {
        _id = "";
        _distance = 0;
        _title = "";
        _type = 0;
        _lat = 0;
        _lon = 0;
        _imageURL = "";
        _attribution = "";
        _line2 = "";
        _line3 = "";
        _line4 = "";
        _dimension = 1;
        _object = new Object3D();
        _transform = new Transform();
        _actions = new List<String>();
    }

    #region Serializable members


    [System.Runtime.Serialization.DataMemberAttribute]
    public string line2
    {
        get
        {
            return _line2;
        }
        set
        {
            _line2 = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public Object3D Object
    {
        get
        {
            return _object;
        }
        set
        {
            _object = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public Transform transform
    {
        get
        {
            return _transform;
        }
        set
        {
            _transform = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string line3
    {
        get
        {
            return _line3;
        }
        set
        {
            _line3 = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string line4
    {
        get
        {
            return _line4;
        }
        set
        {
            _line4 = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string attribution
    {
        get
        {
            return _attribution;
        }
        set
        {
            _attribution = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public decimal distance
    {
        get
        {
            return _distance;
        }
        set
        {
            _distance = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }


    [System.Runtime.Serialization.DataMemberAttribute]
    public int dimension
    {
        get
        {
            return _dimension;
        }
        set
        {
            _dimension = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public int type
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
    public int lat
    {
        get
        {
            return _lat;
        }
        set
        {
            _lat = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public int lon
    {
        get
        {
            return _lon;
        }
        set
        {
            _lon = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public List<String> actions
    {
        get
        {
            return _actions;
        }
        set
        {
            _actions = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string imageURL
    {
        get
        {
            return _imageURL;
        }
        set
        {
            _imageURL = value;
        }
    }

    #endregion

    #region Non-serializable members

    public void AddAction(string actiontext)
    {
        _actions.Add(actiontext);
    }

    #endregion
}

[System.Runtime.Serialization.DataContractAttribute] 
public class Object3D
{
    private string _baseURL;
    private string _full;
    private float _size;

    public Object3D()
    {
        _baseURL = "";
        _full = "";
        _size = 1;
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string baseURL
    {
        get
        {
            return _baseURL;
        }
        set
        {
            _baseURL = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public string full
    {
        get
        {
            return _full;
        }
        set
        {
            _full = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public float size
    {
        get
        {
            return _size;
        }
        set
        {
            _size = value;
        }
    }

}

[System.Runtime.Serialization.DataContractAttribute]
public class Transform
{
    private bool _rel;
    private decimal _angle;
    private decimal _scale;

    public Transform()
    {
        _rel = true;
        _angle = 0;
        _scale = 1;
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public bool rel
    {
        get
        {
            return _rel;
        }
        set
        {
            _rel = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public decimal angle
    {
        get
        {
            return _angle;
        }
        set
        {
            _angle = value;
        }
    }

    [System.Runtime.Serialization.DataMemberAttribute]
    public decimal scale
    {
        get
        {
            return _scale;
        }
        set
        {
            _scale = value;
        }
    }

}






