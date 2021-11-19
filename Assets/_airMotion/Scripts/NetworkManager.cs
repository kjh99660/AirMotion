using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class CameraData
{
    public string gc_no; //ID of club
    public string course_no; //course number
    public int camera_no; //camera number
    public string t_time; //tea time _ yyyyMMddHHmm
    public string user_no; //check in number
    public string caddie_no; //캐디번호 or 카트번호
    public string phone; //number
}
[Serializable]
public class CheckGPS
{
    public string gc_no; //GPS number
    public string course_no;
    public int hole_no;
    public int distance;
}
[Serializable]
public class Spot
{
    public string spot_id; //uniqueItems: true
    public string club_id;
    public string course_id;
    public int hole_num;
    public string group_id;
    public DateTime reg_date;
    public DateTime upd_date;
}
[Serializable]
public class Video
{
    public string video_id; //uniqueItems: true
    public string video_type;
    public string video_fps;
    public string video_width;
    public string video_height;
    public string file_size;
    public string org_size;
    public string url;
    public string thumnail;
    public string thumnails;
    public string nasmo_url;
    public string nasmo_img_url;
    public string state;
    public string club_id;
    public string course_id;
    public string hole_num;
    public string user_no;
    public string t_time;
    public string spot_id;
    public DateTime reg_date; //registe
    public DateTime upd_date; //update
}
[Serializable]
public class Code
{
    public string code_id; //uniqueItems: true
    public Dictionary<string, string> data; //자바 map 형식
    public DateTime reg_date;
    public DateTime upd_date;
}
[Serializable]
public class Locker
{
    public string club_id;
    public string visit_date;
    public string loocker_no;
    public string cert_no;
    public string phone;
}
[Serializable]
public class IDs
{
    //data
}
[Serializable]
public class Result
{
    public string result;
    public string message;
    public Dictionary<string, string> data;
}
[Serializable]
public class Serialization<T>
{
    [SerializeField]List<T> target;
    public List<T> ToList() { return target; }
    public Serialization(List<T> target)
    {
        this.target = target;
    }
}

public class NetworkManager : MonoBehaviour
{
    private static NetworkManager instance = null;
    private string jsonResult;
    public List<Result> result = new List<Result>();
    public IDs ids = new IDs();
    public Locker locker = new Locker();
    public Code code = new Code();
    [SerializeField]
    public List<Video> video = new List<Video>();
    public Spot spot = new Spot();
    public CheckGPS checkGPS = new CheckGPS();
    public CameraData cameraData = new CameraData();

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
    //비디오 관련 메서드
    public void GetBestVideoYear(int year)
    {

    }

    //url 주소를 입력하면 정보를 받아오는 코루틴
    IEnumerator LoadData(string URL, int Type)
    {
        string GetDataUrl = "dev.airmotiongolf.com:3337" + URL;
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
                    jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);                    
                    Debug.Log(jsonResult);
                    switch (Type)
                    {
                        case 1://CameraData
                            cameraData = JsonUtility.FromJson<CameraData>(jsonResult);
                            Debug.Log(cameraData.course_no);
                            break;
                        case 4://Video
                            video = JsonUtility.FromJson<Serialization<Video>>(jsonResult).ToList();//JsonUtility.FromJson<List<Video>>(jsonResult);
                            Debug.Log(video);
                            Debug.Log(video[0].file_size);
                            break;
                    }
                    
                    //LoadJson(jsonResult);
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
        //DataCommonClub LoadData = JsonUtility.FromJson<DataCommonClub>(jsonResult);
        //var LoadData = JsonUtility.FromJson<DataCommunitySend>(jsonResult);
        //DataCommonClub.Dr = LoadData.Dr;
        //Debug.Log(DataCommonClub.Dr);

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
        //test
        
    }
    private void Update()
    {
        //test
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(LoadData("/video/best/yearly/2019",4));
            //.Log(video.club_id);
            //Debug.Log(video.course_id);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //StartCoroutine(LoadData("/common/json/result.ajax"));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //StartCoroutine(LoadData("/common/json/setting.ajax"));
        }
    }
}
