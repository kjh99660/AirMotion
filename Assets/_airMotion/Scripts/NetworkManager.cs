using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//로그인 관련 API
[Serializable]
public class Login //맴버 로그인 관련 정보 + 회원 정보 조회
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public LoginDetail[] data;
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
public class SignIn //회원가입 관련 정보 + 자동 로그인 설정 + 이용약관 변경 동의 + 푸쉬 수신 동의
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
    public PolicyData data;
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


//배너 관련 조회
[Serializable]
public class Banner //배너 목록 조회
{
    public PagingList paging;
    public Page page;
    public CntMap cnt_map;
    public List<BannerList> list;

    
}
[Serializable]
public class PagingList //배너 페이지 리스트
{
    public List<PageList> pagingList;  
}
[Serializable]
public class PageList //배너 페이지 리스트 세부 정보
{
    public string lastImage;
    public bool firstPage;
    public bool lastPage;
    public bool nextPage;
    public string beforeImage;
    public bool beforePage;
    public string firstImage;
    public string nextImage;
}
[Serializable]
public class Page //배너 전체 페이지 정보
{
    public int pageCount;
    public int totCount;
    public int pageNo;
    public int listCount;
}
[Serializable]
public class CntMap //배너 페이지 전체 정보
{
    public int pageNo;
    public int pageSize;
}
[Serializable]
public class BannerList //배너 게시물 정보
{
    public int banNo;
    public string updatedBy;
    public string banUrl;
    public string isView;
    public string channel;
    public string targetType;
    public string title;
    public string banPoc;
    public long createdAt;
    public string fileNm;
    public string createdBy;
    public string useYn;
    public int sortNum;
    public int rn;
    public long updatedAt;
}


//공통 사항 조회 기능 - 언어 패치
[Serializable]
public class Language //공통 언어 정보 - 추후 추가 가능
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public List<LanguageKind> data;      
}
[Serializable]
public class LanguageKind //언어 세부 정보
{
    public string commCode;
    public string commCodeNm;
    public string groupNm;
    public int sortNum;
    public string groupCd;
}


//공지 사항 관련 기능
[Serializable]
public class Notice //공지사항 받기
{
    public List<PageList> paging;
    public Page page;
    public CntMap cnt_map;
    public List<NoticeList> list;
}
[Serializable]
public class NoticeList //공지사항 리스트
{
    public string noticeWriteNm;
    public string updatedBy;
    public string isView;
    public string noticeDeviceCd;
    public string noticeType;
    public int noticeId;
    public string noticeTitle;
    public int ccCode;
    public string delYn;
    public string noticeBrdTypeCd;
    public long createdAt;
    public string createdBy;
    public string noticeName;
    public string noticeMainIsView;
    public int rn;
    public string noticeLangCd;
    public string status;
}
[Serializable]
public class NoticeSave //공지사항 저장
{
    public bool __created__;
    public bool __deleted__;
    public bool __modified__;
    public int ccCode;
    public string createdBy;
    public string dataStatus;
    public string delYn;
    public int id;
    public string isView;
    public string noticeBrdTypeCd;
    public string noticeDeviceCd;
    public string noticeEnContent;
    public string noticeEnTitle;
    public string noticeEventImgAttcId;
    public int noticeId;
    public string noticeJpContent;
    public string noticeJpTitle;
    public string noticeKrContent;
    public string noticeKrTitle;
    public string noticeLangCd;
    public string noticeMainIsView;
    public string noticePostingDate;
    public string noticeRegDt;
    public string noticeRemark;
    public string noticeTitle;
    public string noticeType;
    public string noticeWriteBy;
    public string noticeWriteDate;
    public string noticeWriteNm;
    public string noticeWritePs;
    public int readCount;
    public int sortNum;
    public string updatedBy;
    public string useYn;
}


//비밀번호 찾기 및 비밀번호 변경 관련 기능
[Serializable]
public class PasswordChange //비밀번호 변경 + 비밀번호 찾기
{
    public long timestamp;
    public int status;
    public string error;
    public string message;
    public string path;
    public int errorCode;
}
[Serializable]
public class PasswordFind //비밀번호 찾기 세부 정보
{
    public long timestamp;
    public int status;
    public string error;
    public string message;
    public string path;
    public int errorCode;
}



/// <summary>
/// 위쪽은 json 파일 파싱에 필요한 자료형 클래스들 아래는 통신과 파싱을 위한 메서드들이 있다
/// </summary>

public class NetworkManager : MonoBehaviour
{
    private static NetworkManager instance = null;

    public bool isLoaded;
    public string jsonResult = "";

    public Policy Policy = new Policy();
    public Login Login = new Login();
    public SignIn SignIn = new SignIn();

    public ArrayList signInAnswer;
    /// <summary>
    /// 
    /// </summary>
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
        isLoaded = false;
        signInAnswer = new ArrayList();
    }
 
    private IEnumerator LoadData(string URL, int Type)//url 주소를 입력하면 정보를 받아오는 코루틴
    {
        isLoaded = false;
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
                        case 1://Policy Data
                            Policy = JsonUtility.FromJson<Policy>(jsonResult);
                            break;

                    }
                }
            }
        }
        isLoaded = true;
        yield return jsonResult;
    }

    IEnumerator SendData(string URL, string json, int mode)//json 관련 정보를 보내는 코루틴
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
                JObject decoded = JObject.Parse(www.downloadHandler.text);
                Debug.Log(decoded);
                switch (mode)
                {
                    case 0://SignIn
                        signInAnswer.Add(decoded["returnCode"]);
                        signInAnswer.Add(decoded["returnMsg"]);
                        signInAnswer.Add(decoded["returnData"]);
                        signInAnswer.Add(decoded["msg"]);
                        signInAnswer.Add(decoded["path"]);                       
                        break;
                }
            }
        }
    }

    private string MakeJson(object Data)//제이슨 형태의 자료형을 제이슨 형태의 스트링으로 만들어주는 메서드
    {
        string save = JsonUtility.ToJson(Data, prettyPrint: true);
        Debug.Log(save);
        return save;
    }

    public void GetLoginData(string ID, string password)//로그인 데이터를 가져오는 메서드
    {
        string path = "/gzfx/login/login.ajax?memberId=" + ID + "&memberPs=" + password;
        StartCoroutine(LoadData(path, 0));
    }

    public void SignInSend()
    {
        string path = "/gzfx/member/member/join.ajax";
        //로그인 대이터를 넣는 내용 >> 로그인 대이터가 있는 곳으로 메서드를 옮겨야 한다
        StartCoroutine(SendData(path, MakeJson(SignIn), 0));
        
    }

    public void GetPolicyData(string kind)//이용약관을 가져오는 메서드 약관유형코드(A:이용약관 B:개인정보보호 C:위치정보약관 D:마케팅수신동의)
    {        
        string path = "/gzfx/service/policy/policyContent.ajax?policyTypeCd=" + kind;
        StartCoroutine(LoadData(path, 1));        
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))//테스트
        {
            GetLoginData("kdh4021200@naver.com", "kjh99660");
        }
    }
}
