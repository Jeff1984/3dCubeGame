using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System;
public class leveCreater : MonoBehaviour {

    private ArrayList aL=new ArrayList();

    private ArrayList mapData = new ArrayList();

    private List<GameObject> objList =new List<GameObject>();

    List<List<char>> mData = new List<List<char>>(); 
    //int [,]levelData = new int[,20];

	// Use this for initialization
	void Start () {
	    //TODO load xml

        parseAndSaveLevel();
        

        //parseXML

        //makeMap
        createLevel();
        //Instantiate(Resources.Load("levelUnitBrick"));
        //GameObject objPrefab = Resources.Load("Prefab/level/levelUnitBrick") as GameObject;
       // MonoBehaviour.Instantiate(objPrefab);
	}
        
	// Update is called once per frame
	void Update () {
        
	}

    #region parseAndSave DATA
    //parse and save xml data to array
    private void parseAndSaveLevel()
    {
        XmlDocument xml = new XmlDocument();
        string url = Application.dataPath + "/Data/levelData.xml";
        xml.Load(url);

        XmlNode _levelString = xml.SelectSingleNode("Levels");

        string _levelData = string.Empty;

        int _levelId = 0;

        foreach (XmlNode level in _levelString)
        {
            XmlElement _level = (XmlElement)level;

            _levelData = _level.GetAttribute("data");
            _levelId = Convert.ToInt16(_level.GetAttribute("id"));
            Debug.Log(_levelData);            
        }
        mData = parseStringToList(_levelData);

        Debug.Log(mData);     
    }

    //parseString to array
    private List<List<char>> parseStringToList(string pStr)
    {
        char[] _chars = pStr.ToCharArray();
        List<char> _list;//= new List<char>();
        List<List<char>> _data = new List<List<char>>();
        _list = new List<char>();
        for (int i = 0; i < _chars.Length; i++)
        {

            if (_chars[i] != ',')
            {
                if (_chars[i] == ';')
                {
                    _data.Add(_list);
                    _list = new List<char>();
                }
                else if (isNum(_chars[i]))
                {
                    _list.Add(_chars[i]);
                }
            }
        }
        return _data;        
    }

    private bool isNum(char ch)
    {
        if(ch == '0'
            ||ch == '1'
            ||ch == '2'
            ||ch == '3')
        {
            return true;

        }        

        return false;

    }
    #endregion

    #region CreateMap according to data
    private void createLevel()
    {
        /*foreach (List<Char> rowList in mData)
        {
            foreach (Char c in rowList)
            {
                Debug.Log(c);
            }
        }*/
        int k = 0;
        GameObject objPrefab ;//= Resources.Load("Prefab/level/levelUnitBrick") as GameObject;
        // MonoBehaviour.Instantiate(objPrefab);
        Vector3 brickPos;
        for (int i = 0; i < mData.Count; i++)
        {
            for (int j = 0; j < mData[i].Count; j++)
            {
                //Debug.Log(i);
                if (mData[i][j] == '1')
                {
                    objPrefab = Resources.Load("Prefab/level/levelUnitBrick") as GameObject;
                    brickPos = new Vector3(i, 0, j);
                    Quaternion t = new Quaternion(0, 0, 0, 0);
                    MonoBehaviour.Instantiate(objPrefab, brickPos, t);
                    // Debug.Log(j);
                    Debug.Log(mData[i][j]);
                }
                //k++;
                //Console.
            }
        }
        Debug.Log(k);
    }
    #endregion
}
