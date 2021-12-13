using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//�α��� ���� API
[Serializable]
public class Login //�ɹ� �α��� ���� ����
{
    public int status;
    public string error;
    public string message;
    public string redirect;
    public List<LoginDetail> data;
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
public class SignIn //ȸ������ ���� ����
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
    public List<PolicyData> data;
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
    public List<OS> data;
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

    //url �ּҸ� �Է��ϸ� ������ �޾ƿ��� �ڷ�ƾ
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
    private string MakeJson(object Data)//�̹� �����Ͱ� ����� ��ü�� �����ؾ��Ѵ�
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
        //�α��� �����͸� �ִ� ���� >> �α��� �����Ͱ� �ִ� ������ �޼��带 �Űܾ� �Ѵ�
        StartCoroutine(SendData(path, MakeJson(signIn)));
        
    }
}
