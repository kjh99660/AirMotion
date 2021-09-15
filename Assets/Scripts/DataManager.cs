using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance = null;
    private Dictionary<string, string> userData;

    public static DataManager Instance
    { 
        get
        {
            if (!instance)
            {
                GameObject.Find("DataManager").GetComponent<DataManager>().Awake();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

        Reference();
    }

    enum DataSet
    {

    }


    private void Reference()
    {
        userData = new Dictionary<string, string>();
    }

}
