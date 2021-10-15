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

    private enum UserStateSet //���� ������ ���¸� �����ϴ� enum
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
    //�������� �޾ƿ� �����͸� �����ϴ� ���� +
    //������ Ŭ���̾�Ʈ�� �����ϴ� ��ũ��Ʈ�� ���� �ۼ��Ѵ�


    private void Reference()
    {
        userData = new Dictionary<string, string>();
    }

}
