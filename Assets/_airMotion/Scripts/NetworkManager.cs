using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//�α��� ���� API
[Serializable]
public class Login //�ɹ� �α��� ���� ���� + ȸ�� ���� ��ȸ
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public LoginDetail[] data;
}
[Serializable]
public class LoginDetail //�α��� ���� ���� ����
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


//ȸ�� ���� ���� API
[Serializable]
public class SignIn //ȸ������ ���� ���� + �ڵ� �α��� ���� + �̿��� ���� ���� + Ǫ�� ���� ����
{
    public bool __created__;
    public bool __deleted__;
    public bool __modified__;

    public string createdAt;
    public string createdBy;

    public string dataStatus;

    public string memberAdd1SerialNo; //ȸ��_ADD1_�ø���_��ȣ
    public string memberAgeeCd;       //ȸ��_����_�ڵ�
    public string memberAutoLoginYn;  //ȸ��_�ڵ�_�α���_����
    public string memberBirth;        //ȸ��_�������
    public string memberChangePolicyYn; //ȸ��_����_���_����

    public string memberDevicePutterConntYn; //ȸ��_���_PUTTER_����_����
    public string memberDeviceRadarConntYn; //ȸ��_���_RADAR_����_����
    public string memberDeviceWatchConntYn; //ȸ��_���_WATCH_����_����

    public string memberEmailAddr;          //ȸ��_�̸���_�ּ� >>
    public string memberEmailCertNo;        //ȸ��_�̸���_����_��ȣ
    public string memberEmailCertValidDate; //ȸ��_�̸���_����_��ȿ_����

    public string memberFirstName;          //ȸ��_FIRST_�̸� >>
    public string memberGenderCd;           //ȸ��_����_�ڵ�
    public string memberGpSerialNo;         //ȸ��_GP_�ø���_��ȣ
    public string memberGrSerialNo;         //ȸ��_GR_�ø���_��ȣ
    public string memberHandDrctCd;         //ȸ��_��_����_�ڵ�
    public string memberHandiCd;            //ȸ��_�ڵ�_�ڵ�
    public string memberHandicapCd;         //ȸ��_�ڵ�ĸ_�ڵ�

    public string memberHpNo;               //ȸ��_�ڵ���_��ȣ
    public string memberHumanDate;          //ȸ��_�޸�_����
    public string memberId;                 //ȸ��_ID
    public string memberIp;                 //ȸ��_IP
    public string memberJoinDate;           //ȸ��_����_����
    public string memberJoinPathNm;         //ȸ��_����_���_��
    public string memberLastConnectDate;    //ȸ��_������_����_����
    public string memberLastName;           //ȸ��_LAST_�̸� >>
    public string memberLocationUsePolicyYn;//ȸ��_��ġ_�̿�_���_����
    public string memberLoginTokenNo;       //ȸ��_�α���_��ū_��ȣ
    public string memberLoginTokenValidDate;//ȸ��_�α���_��ū_��ȿ_����
    public string memberMarketingReceptYn;  //ȸ��_������_����_���� >>
    public string memberMenuGrpCd;          //ȸ��_�޴�_�׷�_�ڵ�
    public string memberName;               //ȸ��_�̸�
    public string memberOutDate;            //ȸ��_Ż��_����
    public string memberPs;                 //ȸ��_�н����� >>
    public string memberPsUpdateDate;       //ȸ��_�н�����_����_����
    public string memberPsnInfoClctUseYn;   //ȸ��_����_����_����_�̿�_����
    public string memberPuchYnCd;           //ȸ��_����_����_�ڵ�
    public string memberPushMarketingYn;    //ȸ��_Ǫ��_������_����
    public string memberPushReceptYn;       //ȸ��_Ǫ��_����_����
    public string memberRegDeviceCd;        //ȸ��_���_���_�ڵ�
    public string memberRegOsCd;            //ȸ��_���_OS_�ڵ�
    public string memberRegionCd;           //ȸ��_�ǿ�_�ڵ�
    public string memberRemark;             //ȸ��_���
    public string memberShotDataMemo;       //ȸ��_��_������_�޸�
    public string memberSocialLoginCertDate;//ȸ��_�Ҽ�_�α���_����_����
    public string memberSocialLoginCertNo;  //ȸ��_�Ҽ�_�α���_����_��ȣ
    public string memberSocialLoginDivCd;   //ȸ��_�Ҽ�_�α���_����_�ڵ�
    public string memberStateCd;            //ȸ��_����_�ڵ�
    public string memberUsePolicyYn;        //ȸ��_�̿�_���_���� >>
    public string mgmtMemberId;             //����_ȸ��_ID
    public string mgmtMemberRegDate;        //����_ȸ��_���_����
    public string updatedAt;                //2021-12-13T10:56:03.707Z
    public string updatedBy;                //string
    public string useYn;                    //���_����
}

//�̿��� ��ȸ ���� API
[Serializable]
public class Policy //�̿��� ��ȸ
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public PolicyData data;
}
[Serializable]
public class PolicyData //�̿��� ����
{
    public string policyTitle;
    public string policyContent;
}


//OS �� ���� üũ�ϱ�
[Serializable]
public class VersionCheck //OS�� ���� üũ�ϱ�
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public OS[] data;
}
[Serializable]
public class OS //OS ���� ����
{
    public string verReleaseUrlAddr;
    public string verNo;
    public string verStateCd;
    public string verOsCd;
    public string verMgmtAppNm;
    public string varFile;
    public string verReleaseDt;
}

//�˾� ��� ��ȸ�ϱ�
[Serializable]
public class PopUp //�˾� ��� ��ȸ�ϱ�
{
    public int timestamp;
    public int status;
    public string error;
    public string message;
    public string path;
    public int errorCode;
}


//��� ���� ��ȸ
[Serializable]
public class Banner //��� ��� ��ȸ
{
    public PagingList paging;
    public Page page;
    public CntMap cnt_map;
    public BannerList[] list;


}
[Serializable]
public class PagingList //��� ������ ����Ʈ
{
    public PageList[] pagingList;
}
[Serializable]
public class PageList //��� ������ ����Ʈ ���� ����
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
public class Page //��� ��ü ������ ����
{
    public int pageCount;
    public int totCount;
    public int pageNo;
    public int listCount;
}
[Serializable]
public class CntMap //��� ������ ��ü ����
{
    public int pageNo;
    public int pageSize;
}
[Serializable]
public class BannerList //��� �Խù� ����
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


//���� ���� ��ȸ ��� - ��� ��ġ
[Serializable]
public class Language //���� ��� ���� - ���� �߰� ����
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public LanguageKind[] data;
}
[Serializable]
public class LanguageKind //��� ���� ����
{
    public string commCode;
    public string commCodeNm;
    public string groupNm;
    public int sortNum;
    public string groupCd;
}


//���� ���� ���� ���
[Serializable]
public class Notice //�������� �ޱ�
{
    public List<PageList> paging;
    public Page page;
    public CntMap cnt_map;
    public NoticeList[] list;
}
[Serializable]
public class NoticeList //�������� ����Ʈ
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
public class NoticeSave //�������� ����
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


//��й�ȣ ã�� �� ��й�ȣ ���� ���� ���
[Serializable]
public class PasswordChange //��й�ȣ ���� + ��й�ȣ ã��
{
    public long timestamp;
    public int status;
    public string error;
    public string message;
    public string path;
    public int errorCode;
}
[Serializable]
public class PasswordFind //��й�ȣ ã�� ���� ����
{
    public long timestamp;
    public int status;
    public string error;
    public string message;
    public string path;
    public int errorCode;
}
[Serializable]
public class Video //���� ������
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public VideoData[] data;
}
[Serializable]
public class VideoData //���� ���� ������
{
    public string VideoOthers;
    public string DeviceID;
    public string Size;
    public string FPS;
    public string Local;
    public string Upload;
    public string ShotKey;
    public string Time;
    public string ClubID;
    public string Type;
    public string UserID;
    public string TriggerTime;
    public string TotalTime;
    public string VideoKey;
}
[Serializable]
public class Voice
{
    public int timestamp;
    public int status;
    public string error;
    public string message;
    public string path;
    public int errorCode;
}



/// <summary>
/// ������ json ���� �Ľ̿� �ʿ��� �ڷ��� Ŭ������ �Ʒ��� ��Ű� �Ľ��� ���� �޼������ �ִ�
/// </summary>

public class NetworkManager : MonoBehaviour
{
    private static NetworkManager instance = null;

    public bool isLoaded;
    public string jsonResult = "";

    public Policy Policy = new Policy();
    public Login Login = new Login();
    public Login MemberInformaion = new Login();
    public SignIn SignIn = new SignIn();
    public VersionCheck VersionCheck = new VersionCheck();
    public Notice Notice = new Notice();
    public Video Video = new Video();
    public Banner Banner = new Banner();
    public Voice Voice = new Voice();

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

    private IEnumerator LoadData(string URL, int Type)//url �ּҸ� �Է��ϸ� ������ �޾ƿ��� �ڷ�ƾ
    {
        isLoaded = false;
        string GetDataUrl = "http://211.33.44.93:8091" + URL;
        using (UnityWebRequest www = UnityWebRequest.Get(GetDataUrl))
        {
            yield return www.SendWebRequest();//������
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);//�����޽���ȣ��
            }
            else
            {
                if (www.isDone)
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
                        case 2://OS version
                            VersionCheck = JsonUtility.FromJson<VersionCheck>(jsonResult);
                            break;
                        case 3://Get Member imformation
                            MemberInformaion = JsonUtility.FromJson<Login>(jsonResult);
                            break;
                        case 4://Get Notice
                            Notice = JsonUtility.FromJson<Notice>(jsonResult);
                            break;
                        case 5://Get Video
                            Video = JsonUtility.FromJson<Video>(jsonResult);
                            break;
                        case 6://Get PopUp List
                            Banner = JsonUtility.FromJson<Banner>(jsonResult);
                            break;
                        case 7://Get PopUp List
                            Voice = JsonUtility.FromJson<Voice>(jsonResult);
                            break;
                    }
                }
            }
        }
        isLoaded = true;
        yield return jsonResult;
    }

    IEnumerator SendData(string URL, string json, int mode)//json ���� ������ ������ �ڷ�ƾ
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

    private string MakeJson(object Data)//���̽� ������ �ڷ����� ���̽� ������ ��Ʈ������ ������ִ� �޼���
    {
        string save = JsonUtility.ToJson(Data, prettyPrint: true);
        Debug.Log(save);
        return save;
    }
    public void GetPopUpList(string mainParams, int pageNo, int pageSize)//�˾� ��� ��ȸ
    {
        string path = "/gzfx/operation/popup/list.ajax?mainParams=" + mainParams + "&pageNo=" + pageNo + "&pageSize=" + pageSize;
        StartCoroutine(LoadData(path, 6));
    }
    public void GetVedioData(string start, string end, string ID)//����
    {
        string path = "/gzfx/service/shotdata/getShotVideoDataList.ajax?endDate=" + end + "&memberId=" + ID + "&startDate=" + start;

        StartCoroutine(LoadData(path, 5));
    }
    public void GetNoticeData(int pageNumber, int pageSize)//��������
    {
        string path = "/gzfx/service/community/community_tech_list.ajax?pageNo=" + pageNumber + "&pageSize=" + pageSize;
        StartCoroutine(LoadData(path, 4));
    }
    public void GetUserData(string memberID)//���� ȸ������ �� memberID�� ���� �ʾ� ��ȸ�� �� ����..
    {
        string path = "/gzfx/member/member/memberInfo.ajax?memberId=" + memberID;
        StartCoroutine(LoadData(path, 3));
    }

    public void GetLoginData(string ID, string password)//�α��� �����͸� �������� �޼���
    {
        string path = "/gzfx/login/login.ajax?memberId=" + ID + "&memberPs=" + password;
        StartCoroutine(LoadData(path, 0));
    }

    public void SignInSend()//ȸ������
    {
        string path = "/gzfx/member/member/join.ajax";
        StartCoroutine(SendData(path, MakeJson(SignIn), 0));
    }

    public void GetPolicyData(string kind)//�̿����� �������� �޼��� ��������ڵ�(A:�̿��� B:����������ȣ C:��ġ������� D:�����ü��ŵ���)
    {
        string path = "/gzfx/service/policy/policyContent.ajax?policyTypeCd=" + kind;
        StartCoroutine(LoadData(path, 1));
    }

    public void GetOsVersionInformation()//����OS�ڵ�(AND, IOS, WATCH)
    {
        string version;
#if UNITY_ANDROID
        version = "AND";
#endif
#if UNITY_EDITOR
        version = "AND";
#endif
        string path = "/gzfx/operation/vermgmt/appVersion.ajax?verOsCd=" + version;
        StartCoroutine(LoadData(path, 2));
    }
    public void GetVoiceData(string filter, string mainParams, int offset, int pageNumber, int pageSize, bool paged, bool sorted, bool unsorted, bool unpaged, bool sortSorted, bool sortUnsorted)//
    {
        string path = "/gzfx/service/voice/list.ajax?" + "filter=" + filter + "&mainParams=" + mainParams + "&pageable.offset=" + offset + "&pageable.pageNumber=" + pageNumber
            + "&pageable.pageSize=" + pageSize + "&pageable.paged=" + paged + "&pageable.sort.sorted=" + sorted + "&pageable.sort.unsorted=" + unsorted + "&pageable.unpaged="
            + unpaged + "&sort.sorted=" + sortSorted + "&sort.unsorted=" + sortUnsorted;
        StartCoroutine(LoadData(path, 1));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))//�׽�Ʈ
        {
            GetOsVersionInformation();
        }
    }
}
