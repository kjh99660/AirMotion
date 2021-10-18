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

    private enum UserStateSet //현재 유저의 상태를 관리하는 enum
    {
        
    }
    public void AddUserData(string key, string value)
    {
        userData.Add(key, value);
    }
    public string GetUserDate(string key)
    {
        string temp;
        userData.TryGetValue(key, out temp);
        return temp;
    }
    //서버에서 받아온 데이터를 가공하는 내용 +
    //서버와 클라이언트를 연결하는 스크립트는 따로 작성한다


    private void Reference()
    {
        userData = new Dictionary<string, string>();
    }

}
