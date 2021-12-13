using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//로그인 관련 API
[Serializable]
public class Login //맴버 로그인 관련 정보
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public List<LoginDetail> data;
}
[Serializable]
public class LoginDetail //로그인 관련 세부 정보
{
    public long createdAt;
    public string createdBy;
    public string updatedAt;
    public string updatedBy;

    public string memberId;
    public string memberEmailAddr;
    public string memberName;
    public string memberFirstName;
    public string memberLastName;
    public string memberBirth;

    public string memberStateCd;
    public string memberHpNo;
    public string memberPs;
    public string memberPuchYnCd;
    public string memberJoinPathNm;
    public string memberJoinDate;
    public string memberLastConnectDate;
    public string memberMenuGrpCd;
    public string memberPsUpdateDate;
    public string memberIp;
    public string memberRemark;
    public string memberGenderCd;
    public string memberHandDrctCd;
    public string memberHandicapCd;
    public string memberGrSerialNo;
    public string memberGpSerialNo;
    public string memberAdd1SerialNo;
    public string memberShotDataMemo;
    public string memberRegionCd;
    public string memberAgeeCd;
    public string memberHandiCd;
    public string memberRegDeviceCd;
    public string memberRegOsCd;
    public string memberUsePolicyYn;
    public string memberPsnInfoClctUseYn;
    public string memberLocationUsePolicyYn;
    public string memberMarketingReceptYn;
    public string memberPushReceptYn;
    public string memberPushMarketingYn;
    public string memberChangePolicyYn;
    public string memberHumanDate;
    public string memberOutDate;
    public string memberDeviceRadarConntYn;
    public string memberDevicePutterConntYn;
    public string memberDeviceWatchConntYn;
    public string memberEmailCertValidDate;
    public string memberEmailCertNo;
    public string memberLoginTokenNo;
    public string memberLoginTokenValidDate;
    public string memberSocialLoginCertNo;
    public string memberSocialLoginCertDate;
    public string memberSocialLoginDivCd;
    public string memberAutoLoginYn;
    public string mgmtMemberId;
    public string mgmtMemberRegDate;
    public string useYn;
    public string userStatus;
    public string ip;
    public string locale;
    public string menuGrpCd;
    public string menuGrpNm;

    public string userCorpInfo;
    public string userUserInfo;

    public string delYn;
    public int rn;
    public string id;
    public string dataStatus;

    public bool __deleted__;
    public bool __created__;
    public bool __modified__;
}

//회원 가입 관련 API
[Serializable]
public class SignIn //회원가입 관련 정보
{
    public bool __created__;
    public bool __deleted__;
    public bool __modified__;

    public string createdAt;
    public string createdBy;

    public string dataStatus;

    public string memberAdd1SerialNo; //회원_ADD1_시리얼_번호
    public string memberAgeeCd;       //회원_연령_코드
    public string memberAutoLoginYn;  //회원_자동_로그인_여부
    public string memberBirth;        //회원_생년월일
    public string memberChangePolicyYn; //회원_변경_약관_여부

    public string memberDevicePutterConntYn; //회원_기기_PUTTER_연결_여부
    public string memberDeviceRadarConntYn; //회원_기기_RADAR_연결_여부
    public string memberDeviceWatchConntYn; //회원_기기_WATCH_연결_여부

    public string memberEmailAddr;          //회원_이메일_주소 >>
    public string memberEmailCertNo;        //회원_이메일_인증_번호
    public string memberEmailCertValidDate; //회원_이메일_인증_유효_일자

    public string memberFirstName;          //회원_FIRST_이름 >>
    public string memberGenderCd;           //회원_성별_코드
    public string memberGpSerialNo;         //회원_GP_시리얼_번호
    public string memberGrSerialNo;         //회원_GR_시리얼_번호
    public string memberHandDrctCd;         //회원_손_방향_코드
    public string memberHandiCd;            //회원_핸디_코드
    public string memberHandicapCd;         //회원_핸디캡_코드

    public string memberHpNo;               //회원_핸드폰_번호
    public string memberHumanDate;          //회원_휴먼_일자
    public string memberId;                 //회원_ID
    public string memberIp;                 //회원_IP
    public string memberJoinDate;           //회원_가입_일자
    public string memberJoinPathNm;         //회원_가입_경로_명
    public string memberLastConnectDate;    //회원_마지막_접속_일자
    public string memberLastName;           //회원_LAST_이름 >>
    public string memberLocationUsePolicyYn;//회원_위치_이용_약관_여부
    public string memberLoginTokenNo;       //회원_로그인_토큰_번호
    public string memberLoginTokenValidDate;//회원_로그인_토큰_유효_일자
    public string memberMarketingReceptYn;  //회원_마케팅_수신_여부 >>
    public string memberMenuGrpCd;          //회원_메뉴_그룹_코드
    public string memberName;               //회원_이름
    public string memberOutDate;            //회원_탈퇴_일자
    public string memberPs;                 //회원_패스워드 >>
    public string memberPsUpdateDate;       //회원_패스워드_수정_일자
    public string memberPsnInfoClctUseYn;   //회원_개인_정보_수집_이용_여부
    public string memberPuchYnCd;           //회원_구매_여부_코드
    public string memberPushMarketingYn;    //회원_푸시_마케팅_여부
    public string memberPushReceptYn;       //회원_푸시_수신_여부
    public string memberRegDeviceCd;        //회원_등록_기기_코드
    public string memberRegOsCd;            //회원_등록_OS_코드
    public string memberRegionCd;           //회원_권역_코드
    public string memberRemark;             //회원_비고
    public string memberShotDataMemo;       //회원_샷_데이터_메모
    public string memberSocialLoginCertDate;//회원_소셜_로그인_인증_일자
    public string memberSocialLoginCertNo;  //회원_소셜_로그인_인증_번호
    public string memberSocialLoginDivCd;   //회원_소셜_로그인_구분_코드
    public string memberStateCd;            //회원_상태_코드
    public string memberUsePolicyYn;        //회원_이용_약관_여부 >>
    public string mgmtMemberId;             //관리_회원_ID
    public string mgmtMemberRegDate;        //관리_회원_등록_일자
    public string updatedAt;                //2021-12-13T10:56:03.707Z
    public string updatedBy;                //string
    public string useYn;                    //사용_여부
}

//이용약관 조회 관련 API
[Serializable]
public class Policy //이용약관 조회
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public List<PolicyData> data;
}
[Serializable]
public class PolicyData //이용약관 내용
{
    public string policyTitle;
    public string policyContent;
}
//OS 별 버전 체크하기
[Serializable]
public class VersionCheck //OS별 버전 체크하기
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public List<OS> data;
}
[Serializable]
public class OS //OS 세부 정보
{
    public string verReleaseUrlAddr;
    public string verNo;
    public string verStateCd;
    public string verOsCd;
    public string verMgmtAppNm;
    public string varFile;
    public string verReleaseDt;
}
//팝업 목록 조회하기
[Serializable]
public class PopUp //팝업 목록 조회하기
{
    public int timestamp;
    public int status;
    public string error;
    public string message;
    public string path;
    public int errorCode;
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
    public Login Login = new Login();

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


    }

    //url 주소를 입력하면 정보를 받아오는 코루틴
    private IEnumerator LoadData(string URL, int Type)
    {
        string jsonResult = "";
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
                    jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);                    
                    Debug.Log(jsonResult);
                    switch (Type)
                    {
                        case 0://Login
                            Login = JsonUtility.FromJson<Login>(jsonResult);
                            break;
                    }
                }
            }
        }
        yield return jsonResult;
    }
    IEnumerator SendData(string URL, string json)
    {
        string GetDataUrl = "http://211.33.44.93:8091" + URL;
        using (UnityWebRequest www = UnityWebRequest.Post(GetDataUrl, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

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
    private string MakeJson(object Data)//이미 데이터가 저장된 객체를 전달해야한다
    {
        string save = JsonUtility.ToJson(Data, prettyPrint: true);
        Debug.Log(save);
        return save;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            GetLoginData("kdh4021200@naver.com", "kjh99660");
        }
    }

    public void GetLoginData(string ID, string password)
    {
        string path = "/gzfx/login/login.ajax?memberId=" + ID + "&memberPs=" + password;
        StartCoroutine(LoadData(path, 0));
    }
    public void SignIn()
    {
        string path = "/gzfx/member/member/join.ajax";
        SignIn signIn = new SignIn();
        //로그인 대이터를 넣는 내용 >> 로그인 대이터가 있는 곳으로 메서드를 옮겨야 한다
        StartCoroutine(SendData(path, MakeJson(signIn)));
        
    }
}
