using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class DataCommon
{
    public double CIMA;
    public bool CIMO;
    public bool CIMSfa;
    public bool CIMSpa;
    public bool CIMSfn;
    public bool CIMSpn;
    public double CFASp;
    public double CPASp;
    public double CFASa;
    public double CPASa;
    public double CFASn;
    public double CPASn;
    public double CHSV;
    public double CBSV;
    public double CBFV;
    public double CBPV;
    public double CDf;
    public double CPGV;
    public double CDFf;
    public double CDFp;
    public double CDFr;
    public bool CSFf;
    public double CSFr;
    public double CSBr;
}
[System.Serializable]
public class DataCommunitySave
{
    public bool __created__ = true;
    public bool __deleted__ = true;
    public bool __modified__ = true;
    public string brdId;
    public string brdType;
    public string ccCode;
    public string contentData;
    public string createdAt;
    public string createdBy;
    public string dataStatus;
    public string eventImg;
    public string id;
    public string[] imgList;
    public string isView;
    public string noticeType;
    public string postingdate;
    public int readCount;
    public string remark;
    public int rn;
    public string tittle;
    public string updatedAt;
    public string updatedBy;
    public string writeDate;
    public string writeNm;
}
[System.Serializable]
public class DataCommonClub
{   
    public ClubInf Dr;
    public ClubInf W3;
    public ClubInf W5;
    public ClubInf W7;
    public ClubInf I4;
    public ClubInf I5;
    public ClubInf I6;
    public ClubInf I7;
    public ClubInf I8;
    public ClubInf I9;
    public ClubInf PW;
    public ClubInf GW;
    public ClubInf SW;
    public ClubInf LW;
    public ClubInf PT;
}
[System.Serializable]
public class ClubInf
{
    public string Name;
    public string GV;
    public string AD;
    public string AH;
    public string AB;
    public string BSV;
    public string SBS;
    public string SLA;
    public string SLAA;
    public string AA;
    public string SLO;
    public string MD;
    public string TD;
    public string TDM;
    public string TRM;
}

public class NetworkManager : MonoBehaviour
{
    private static NetworkManager instance = null;
    private string jsonResult;
    private int port;
    private bool isOnloading;
    DataCommon DataCommon = new DataCommon();
    DataCommunitySave DataCommunitySave = new DataCommunitySave();
    DataCommonClub DataCommonClub = new DataCommonClub();

    public static NetworkManager Instance
    {
        get
        {
            if (!instance)
            {
                GameObject.Find("NetworkManager").GetComponent<NetworkManager>().Awake();
            }
            return instance;
        }
    }
    IEnumerator LoadData(string URL)
    {
        string GetDataUrl = "http://211.33.44.93:8091" + URL;
        using (UnityWebRequest www = UnityWebRequest.Get(GetDataUrl))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if(www.isDone)
                {
                    isOnloading = false;
                    jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);                    
                    Debug.Log(jsonResult);
                    LoadJson(jsonResult);
                }
            }
        }
    }
    IEnumerator SendData(string URL, string json)
    {
        string GetDataUrl = "http://211.33.44.93:8091" + URL;
        using (UnityWebRequest www = UnityWebRequest.Post(GetDataUrl, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            //www.SetRequestHeader()

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    //test
    private void LoadJson(string jsonResult)
    {
        //var LoadData = JsonUtility.FromJson<DataCommon>(jsonResult);
        DataCommonClub LoadData = JsonUtility.FromJson<DataCommonClub>(jsonResult);
        Debug.Log(LoadData.Dr.Name);
        DataCommonClub.Dr = LoadData.Dr;
        Debug.Log(DataCommonClub.Dr);

        //SaveData.CIMSfa = LoadData.CIMSfa;

    }
    //test
    private string MakeJson(object Data)//이미 데이터가 저장된 객체를 전달해야한다
    {
        string save = JsonUtility.ToJson(Data, prettyPrint: true);
        Debug.Log(save);
        return save;
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
    private void Reference()
    {
        isOnloading = true;
        //test
        
    }
    private void Update()
    {
        //test
        if(Input.GetKeyDown(KeyCode.A))
        {            
            StartCoroutine(SendData(("/system/community/board/save.ajax"), MakeJson(DataCommunitySave)));
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(LoadData("/common/json/clubdata.ajax"));
        }
    }
}
