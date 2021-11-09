using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class DataCommunitySend
{

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
[System.Serializable]
public class DataCommonresult//35
{
    public string TotalDistance;
    public string Carry;
    public string ClubSpeed;
    public string BallSpeed;
    public string Smash;
    public string LaunchAngle;
    public string LaunchDirection;
    public string ShotType;
    public string BackSpin;
    public string SideSpin;
    public string SpinRate;
    public string SpinAxis;
    public string AttackAngle;
    public string DynamicLoft;
    public string HeightAPEX;
    public string DeviationDist;
    public string CurveDist;
    public string LandingAngle;
    public string Roll;
    public string FlighTime;
    public string FaceToPath;
    public string FaceAnglel;
    public string ClubPath;
    public string ImpactPositon;
    public string Tempo;
    public string ClubFacePosition;
    public string ClubFaceRotation;
    public string SpotLocation;
    public string ShaftPivot;
    public string ZoneSpeedRate;
    public string FollowRate;
    public string Add1;
    public string Add2;
    public string TargetSuccess;
    public string Others;
}
[System.Serializable]
public class DataCommonSetting
{
    public double ClubID;
    public double DeviceVerticalAngle;
    public double DeviceHorizontalAngle;
    public double DeviceDistance;
    public string DevicePassword;
    public string DeviceName;
    public string DeviceName_Putter;
    public bool GPutterConnection;
    public double SessionTime;
    public double ShotDataNo;
    public double VideoDataNo;
    public double PuttingSuccessRateDev;
    public double PuttingDistanceDevH;
    public double PuttingDistanceDevM;
    public double PuttingDistanceDevL;
    public double PuttingDirectionDevH;
    public double PuttingDirectionDevM;
    public double PuttingDirectionDevL;
    public double GreenSpeedMax;
    public double GreenSpeedInterval;
    public string GreenSpeedUnit;
    public bool LandingAreaOption;
    public bool PreviousShotOption;
    public bool PreviousShotNumber;
    public bool VideoPlayOption;
    public bool TargetPracticeOption;
    public string InitialMode;
    public string InitialModeTracking;
    //"DataBlockNo":{"Item":"Setting","dataType":"Double","Min":"1","Max":"30","Unit":"ea","Default":"12","Desc":"데이터블럭갯수"},
    //"ShotPosition":{"Item":"Setting","dataType":"String","Min":"1","Max":"3","Unit":"","Default":"1","Desc":"샷위치"},
    //"UnitDistance":{"Item":"Setting","dataType":"String","Min":"1","Max":"2","Unit":"","Default":"2","Desc":"거리단위"},
    //"UnitSpeed":{"Item":"Setting","dataType":"String","Min":"1","Max":"2","Unit":"","Default":"2","Desc":"속도단위"},
    //"Handle":{"Item":"Setting","dataType":"String","Min":"1","Max":"2","Unit":"","Default":"1","Desc":"손잡이"},
    //"CameraSetting":{"Item":"Setting","dataType":"Double","Min":"","Max":"","Unit":"","Default":"FALSE","Desc":"카메라ON설정"},
    //"VideoPlayTime":{"Item":"Setting","dataType":"Double","Min":"2.0","Max":"6.0","Unit":"m","Default":"3.0","Desc":"트리거영상길이"},
    //"VideoTriggerTime":{"Item":"Setting","dataType":"Double","Min":"0.8","Max":"3.0","Unit":"m","Default":"1.5","Desc":"트리거임팩트길이"},
    //"TtsOption":{"Item":"Setting","dataType":"Boolean","Min":"","Max":"","Unit":"","Default":"TRUE","Desc":"TTS옵션"},
    //"VoiceSettings":{"Item":"Setting","dataType":"String","Min":"1","Max":"30","Unit":"m","Default":"1","Desc":"음성설정"},
    //"VideoServerURL":{"Item":"Setting","dataType":"String","Min":"","Max":"","Unit":"","Default":"flexcdn.golfzon.com","Desc":"영상전송서버URL"},
    //"QaServerURL":{"Item":"Setting","dataType":"String","Min":"","Max":"","Unit":"","Default":"qaflex.golfzon.com","Desc":"테스트서버URL"},
    //"QaServerIP":{"Item":"Setting","dataType":"String","Min":"","Max":"","Unit":"","Default":"129.0.2","Desc":"테스트서버IP"},
    //"QaServerPort":{"Item":"Setting","dataType":"String","Min":"","Max":"","Unit":"","Default":"9090","Desc":"테스트서버포트"},
    //"RealServerURL":{"Item":"Setting","dataType":"String","Min":"","Max":"","Unit":"","Default":"flex.golfzon.com","Desc":"상용서버URL"},
    //"RealServerIP":{"Item":"Setting","dataType":"String","Min":"","Max":"","Unit":"","Default":"129.0.1","Desc":"상용서버IP"},
    //"RealServerPort":{"Item":"Setting","dataType":"String","Min":"","Max":"","Unit":"","Default":"9090","Desc":"상용서버포트"}}
}


public class NetworkManager : MonoBehaviour
{
    private static NetworkManager instance = null;
    private string jsonResult;
    private bool isOnloading;
    DataCommunitySave DataCommunitySave = new DataCommunitySave();


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
        var LoadData = JsonUtility.FromJson<DataCommunitySend>(jsonResult);
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
            StartCoroutine(LoadData("/system/community/board/list.ajax"));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(LoadData("/common/json/result.ajax"));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(LoadData("/common/json/setting.ajax"));
        }
    }
}
