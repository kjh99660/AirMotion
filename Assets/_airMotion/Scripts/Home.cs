using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
using UnityEngine.UI.Extensions.Examples;
using System.IO;
using EasyMobile;

public class Home : MonoBehaviour //���� �˻��� �ϴ� ���� ��ũ��Ʈ
{
    private UIManager UM;
    private GlobalCourutine GC;
    public GameObject Calendar; //�޷� �ܺ� �÷�����
    public GameObject Time; //��ũ�Ѹ� �ܺ� �÷�����
    [Header("Main Has Video")]
    public GameObject Content;
    public GameObject VideoPrefabs;

    [Header ("Sort Zero Page")]
    public GameObject[] TopButtons;

    [Header("Sort Third Page")]
    public GameObject[] TopButtonsMain;

    [Header("Button Active Images")]
    public Sprite redButton_top;
    public Sprite whiteButton_top;

    [Header ("First and Second Page Text")]//���� ���� �˻� �ؽ�Ʈ - 4
    public GameObject[] DirectSearchText;

    [Header ("TeaTime and Locker Toggle")]//��Ŀ��ȣ
    public GameObject[] TeaAndLockerInput;

    [Header("Detail Vedio")]
    public GameObject[] DownloaadToggle;

    [Header("DownloadProgress")]
    public GameObject DownloadProgress;

    private bool selectedCourse, selectedDay;
    private bool firstVisit;
    private bool newVedio;
    private bool IsPremium;
    private bool HasVedio;
    private bool Download720, IsVedioOpen, IsDownloaded, PanoramaExplain, HasPanorama, SnapPhotoExplain, HasSnapPhoto;
    private Color red;
    private Color white;
    private Color black;
    private int downloadNumber;
    private string urlNowUse;

    private void OnEnable()
    {
        InitValue();
    }



    // #Home_main_0 and #Home_main_3
    IEnumerator CheckNewVedio()//������ �˻��ϴ� ���� ���� ������ �̹� ������ 3�� �������� �̵�
    {
        PopUp_search();
        NetworkManager.Instance.GetVedioData("20211210", "20211220", "3");

        yield return new WaitUntil(() => NetworkManager.Instance.isLoaded == true);
        yield return new WaitForSeconds(1f);


        if (MakeVideos()) HasVedio = true;
        else HasVedio = false;

        MoveHomeOrMain();

        yield return new WaitUntil(() => !UM.CheckPopUp());

        //loading animation
        if (!HasVedio) PopUp_noVedio();
        if (newVedio) PopUp_vediolist();
        if (gameObject.transform.Find("GlobalCourutine") != null) GC.CheckCourutine();

    }

    private bool MakeVideos()//������ �ʱ�ȭ
    {
        var temp = NetworkManager.Instance.Video.data;
        if (temp.Length == 0) return false;

        for (int i = 0; i < temp.Length; i++)
        {
            var inf = temp[i];
            GameObject Video = Instantiate(VideoPrefabs);
            Video.GetComponent<VideoSomenail>().Init(inf.VideoOthers, inf.Time, inf.VideoKey, i);
            Video.transform.parent = Content.transform;
        }
        return true;
    }

    public void SortFront()
    {
        //���� tag ���� ��� �����ϴ� ����
    }

    public void SortSide()
    {
        //���� �±׵� ���� ��� �����ϴ� ����
    }

    public void SortNew()//�ֱټ����� �����ϴ� ����
    {
        
    }

    public void SortPopular()//�α������ �����ϴ� ����
    {
        
    }

    public void SortLike()//���ƿ������ �����ϴ� ����
    {
        
    }

    public void ClickAutoSearch()//�ڵ� ���� �˻�
    {
        StartCoroutine(CheckNewVedio());
    }

    public void ClickPassiveSearch()//���� ���� �˻�
    {
        MoveDirectSearch();
    }

    public void ClickSearchVedio()//���� ��Ī ��ư
    {
        UM.ChildActiveOnOff();
    }

    public void ClickTopButton()//0������ ���� ���� ��ư
    {
        GameObject Button = EventSystem.current.currentSelectedGameObject.gameObject;
        foreach (GameObject _ in TopButtons)
        {
            UM.ChangeImage(whiteButton_top, _);
            _.transform.GetChild(0).GetComponent<Text>().color = red;
        }
        UM.ChangeImage(redButton_top, Button);
        Button.transform.GetChild(0).GetComponent<Text>().color = white;
        //if(Button.name == ~~)
    }

    public void ClickTopButtonMain()//3������ ���� ���� ��ư
    {
        GameObject Button = EventSystem.current.currentSelectedGameObject.gameObject;
        foreach (GameObject _ in TopButtonsMain)
        {
            UM.ChangeImage(whiteButton_top, _);
            _.transform.GetChild(0).GetComponent<Text>().color = red;
        }
        UM.ChangeImage(redButton_top, Button);
        Button.transform.GetChild(0).GetComponent<Text>().color = white;
        //if(Button.name == ~~)
    }




    // #Home_search_1 and #Home_search_2
    public void ToggleGolfCourse()//������ ���� ���
    {
        GameObject select = UM.CurrentSelectedGameObject();
        if (select.GetComponent<Toggle>().isOn)
        {
            Text temp = select.transform.GetChild(1).GetComponent<Text>();
            for (int i = 0; i < 2; i++)
            {
                Text view = DirectSearchText[2 * i].GetComponent<Text>();
                Color color = new Color(view.color.r, view.color.g, view.color.b, 1f);
                view.text = temp.text;
                view.color = color;
            }
        }
    }

    public void ToggleCheckIsTeaTime()//ƼŸ�� ���
    {
        GameObject select = TeaAndLockerInput[0].transform.parent.gameObject;
        if (select.GetComponent<Toggle>().isOn)
        {
            select.transform.GetChild(2).gameObject.SetActive(true);
            TeaAndLockerInput[1].SetActive(false);
            TeaAndLockerInput[0].SetActive(true);
        }
    }

    public void ToggleCheckIsLocker()//��Ŀ ���
    {
        GameObject select = TeaAndLockerInput[1].transform.parent.gameObject;
        if (select.GetComponent<Toggle>().isOn)
        {
            select.transform.GetChild(2).gameObject.SetActive(true);
            TeaAndLockerInput[1].SetActive(true);
            TeaAndLockerInput[0].SetActive(false);    
        }
    }

    public void ConfirmSearchVedio()//�����˻� ���� �˻� Ȯ�� ��ư
    {
        //�˻��� �ִϸ��̼� ���
        //content ������Ʈ�� ��ȸ����� �߰�
    }

    public void ConfirmRoundDay()//���� ���� ����
    {
        Calendar.GetComponent<ScrollingCalendar>().ShowDate();
        UM.CancelPopUp();
        selectedDay = true;
    }

    public void ConfirmTeaTime()//ƼŸ�� ����
    {
        Time.GetComponent<ScrollingTime>().ShowTime();
        UM.CancelPopUp();
    }

    public void PopUpConfirmNewVedio()//���� ã�� �������� �߰�
    {
        //���� ã�� �������� �߰��ϴ� �ڵ�
    }

    public void PopUpConfirmGolfCourse()//������ ���� �Ϸ� ��ư
    {
        UM.CancelPopUp();
        selectedCourse = true;
    }




    // #Home_vedio_4 and Home_vedio_5
    public void VedioDownload()
    {
        if (!IsDownloaded)
        {
            if (IsPremium)
            {
                PopUp_download();
            }
            else
            {
                PopUp_normal_download();
            }
        }
        else
        {
            PopUp_savedelete();
            //�ٿ�ε� ����
        }


        //���󿡼� �ٿ�ε� ��ư ������ ��
        //�ٽ� ������ ���� ����
    }

    public void DeleteDownloadCancel()
    {
        UM.CancelPopUp();
    }

    public void DeleteDownloadConfirm()//������ ������ ����
    {
        
        IsDownloaded = false;
        UM.CancelPopUp();
    }

    public void ConfirmDownload()//�ٿ�ε� Ȯ�� ��ư �ּҴ� �ƹ� ����
    {
        //ȭ�� ����++
        
        PopUp_downprograss();
        StartCoroutine(Downloadmp4("https://s3.ap-northeast-2.amazonaws.com/metaverse.file/meta/no1.mp4"));
        //�ٿ�ε� �����ϴ� �Լ� �����ؾ��� -> �ٿ�ε尡 ������ �ٿ�ε� �Ϸ� �̹����� ��ȯ�ؾ���
        IsDownloaded = true;
        UM.CancelPopUp();
    }

    IEnumerator Downloadmp4(string URL)
    {
        WWW www = new WWW(URL);
        while (!www.isDone)
        {
            DownloadProgress.GetComponent<Image>().fillAmount = www.progress;
            Debug.Log(www.progress);
            yield return null;
        }
        UM.CancelPopUp(9);
        string savePath = Application.persistentDataPath + "/" + downloadNumber + ".mp4";
        downloadNumber++;
        Debug.Log(savePath);
        File.WriteAllBytes(savePath, www.bytes);
    }

    public void CancelDownload()
    {
        PopUp_downcancel();
        StartCoroutine(Download());
        IsDownloaded = false;
        UM.CancelPopUp();
    }

    public void ToggleVedioDownload_normal()//�Ϲ� ȸ���� ��� ���� �ٿ�ε�
    {
        GameObject gameObject = UM.CurrentSelectedGameObject();
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().color = red;
            gameObject.transform.GetChild(1).GetComponent<Text>().color = red;
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().color = black;
            gameObject.transform.GetChild(1).GetComponent<Text>().color = black;
        }
    }

    public void ToggleVedioDownload()//���� �ٿ�ε� ǰ�� ���
    {
        GameObject gameObject = UM.CurrentSelectedGameObject();
        if (gameObject.name == "Toggle_720")
        {
            DownloaadToggle[0].GetComponent<Text>().color = red;
            DownloaadToggle[1].GetComponent<Text>().color = red;
            DownloaadToggle[2].GetComponent<Text>().color = black;
            DownloaadToggle[3].GetComponent<Text>().color = black;
            Download720 = true;
        }
        else
        {
            DownloaadToggle[0].GetComponent<Text>().color = black;
            DownloaadToggle[1].GetComponent<Text>().color = black;
            DownloaadToggle[2].GetComponent<Text>().color = red;
            DownloaadToggle[3].GetComponent<Text>().color = red;
            Download720 = false;
        }
    }

    public void ConfirmOpenVedio()//������ ���� ����
    {

        //������ ���� ���θ� ������ ����
        UM.CancelPopUp();
    }

    public void CancelOpenVedio()
    {
        UM.CancelPopUp();
    }

    public void VedioOpenVedio()//���� ���� ��ư
    {
        if (IsVedioOpen)
        {
            //��ư �̹��� ����
            //���� ���� ����
        }
        else
        {
            //���� ������ ������ �˾�â�� ����
            PopUp_openvedio();
        }
        //���󿡼� ���� ���� ��ư�� ������ ��
        //�ٽ� ������ ���� ���� ���
    }

    public void PanoramaStopWatchingPopup()//�ĳ�� �˾� �׸�����
    {
        PanoramaExplain = false;
        MovePanorama();
    }

    public void PanoramaConfirm()//�ĳ�󸶷� �Ѿ��
    {
        MovePanorama();
    }

    public void VedioPanorama()//�ĳ�� �˾� ����
    {
        if (!HasPanorama)
        {
            if (PanoramaExplain) PopUp_explain();
            else MovePanorama();
        }
        else PopUp_deletePANORAMA();

        //���󿡼� �ĳ�� ��ư�� ������ ��
    }

    public void SnapShotStopWatchingPopUp()//���������� �Ѿ��
    {
        SnapPhotoExplain = false;
        MovePanorama();//���߿� �ٲ����
    }
    public void VedioSnapPhoto()
    {
        if (!HasSnapPhoto)
        {
            if (SnapPhotoExplain) PopUp_snapphoto();
            else MovePanorama();//��������� �����ؾ���
        }
        else PopUP_deleteSNAPSHOT();


        //���󿡼� ���� �����ư�� ������ ��
    }

    public void VedioShare()//���󿡼� �����ϱ� ��ư�� ������ ��
    {
        //PopUp_share();
        ShareToSNS("https://s3.ap-northeast-2.amazonaws.com/metaverse.file/meta/no1.mp4");
    }
    public void ShareToSNS(string text)
    {
        string Url = text;
        Sharing.ShareURL(Url, "AirMotion Vedio");
        //new NativeShare().SetText(Url).Share();     
    }

    public void VedioMore()//���󿡼� ������ ��ư�� ������ ��(������ �÷��̾ ����)
    {
        
    }
    public void DeleteVedio()//�����⿡�� ���� ���� ��ư�� ������ ��
    {
        
    }






    //# �ܼ� �̵� ����
    public void MoveHomeOrMain()
    {
        Debug.Log("HasVedio:" + HasVedio);
        if (HasVedio) MoveMain();
        else MoveHome();
    }
    private void MoveBest() => SceneManager.LoadScene("best");
    private void MoveGolfCourse() => SceneManager.LoadScene("golfCourse");
    private void MoveMore() => SceneManager.LoadScene("more");
    private void MoveHome_re() => SceneManager.LoadScene("Home");
    private void MovePanorama() => SceneManager.LoadScene("PANORAMA");
    public void PopUp_noVedio() => UM.PopUp(0);
    private void PopUp_search() => UM.PopUp(1);
    private void PopUp_vediolist() => UM.PopUp(2);
    public void PopUp_golfCourse() => UM.PopUp(3);
    private void PopUp_deleteVedio() => UM.PopUp(4);
    public void PopUp_roundDay() => UM.PopUp(5);
    private void PopUp_teaTime() => UM.PopUp(6);
    private void PopUp_download() => UM.PopUp(7);
    private void PopUp_normal_download() => UM.PopUp(8);
    private void PopUp_downprograss() => UM.PopUp(9);
    private void PopUp_downcancel() => UM.PopUp(10);
    private void PopUp_savedelete() => UM.PopUp(11);
    private void PopUp_comment() => UM.PopUp(12);
    private void PopUp_openvedio() => UM.PopUp(13);
    private void PopUp_more() => UM.PopUp(14);
    private void PopUp_information() => UM.PopUp(15);
    private void PopUp_delete() => UM.PopUp(16);
    private void PopUp_share() => UM.PopUp(17);
    private void PopUp_explain() => UM.PopUp(18);
    private void PopUp_detail() => UM.PopUp(19);
    private void PopUp_snapphoto() => UM.PopUp(20);
    private void PopUp_deletePANORAMA() => UM.PopUp(21);
    private void PopUP_deleteSNAPSHOT() => UM.PopUp(22);
    public void MoveHome() => UM.PageMove(0);
    public void MoveDirectSearch() => UM.PageMove(1);
    public void MoveDirectSearchDetail() => UM.PageMove(2);
    public void MoveMain() => UM.PageMove(3);
    public void MoveVedio() => UM.PageMove(4);
    public void MoveVdeioAfter() => UM.PageMove(5);

   
    public IEnumerator Download()
    {
        yield return new WaitForSeconds(1f);
        UM.CancelPopUp(10);
    }

    //GlobalCourutine �� �����ϴ� �ڷ�ƾ - 1
    public IEnumerator DirectSearch()
    {
        Debug.Log("DirectSearch");
        MoveDirectSearch();
        yield return null;
    }

    //GlobalCourutine �� �����ϴ� �ڷ�ƾ - 2
    public IEnumerator BackToVedio()
    {
        //������ �����ߴ� ������ ��� �ٽ� ���� �ڷ�ƾ
        yield return null;
    }

    

    private bool CheckInput()
    {
        if (selectedCourse && selectedDay) return true;
        return false;
    }

    public void Update()
    {
        if (CheckInput())
        {
            MoveDirectSearchDetail();
            selectedCourse = false;
            selectedDay = false;
        }
    }

    private void InitValue()
    {
        if (UM == null) UM = UIManager.Instance;
        if (GC == null) GC = GlobalCourutine.Instance;
        UM.ResetUIManager();

        HasVedio = true;
        firstVisit = true;
        newVedio = false;
        IsPremium = false;
        selectedCourse = false; selectedDay = false;

        //vedio detail value
        Download720 = false; IsVedioOpen = false; IsDownloaded = false;  PanoramaExplain = true; HasPanorama = false; HasSnapPhoto = false; SnapPhotoExplain = true;

        StartCoroutine(CheckNewVedio());
        white = new Color(1f, 1f, 1f, 1f); red = new Color(1f, 0.1921569f, 0.2941177f, 1f); ColorUtility.TryParseHtmlString("#1B1B1B", out black);
        downloadNumber = 0;
        //�� �� ù��° �湮�̸� -> ���� �˻� -> 0/x

    }


}
