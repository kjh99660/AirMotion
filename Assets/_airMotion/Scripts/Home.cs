using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
using UnityEngine.UI.Extensions.Examples;

public class Home : MonoBehaviour //영상 검색을 하는 씬의 스크립트
{
    private UIManager UM;
    private GlobalCourutine GC;
    public GameObject Calendar;
    public GameObject Time;
    public GameObject[] TopButtons;
    [Space(8)]
    public GameObject[] TopButtonsMain;
    [Space(16)]
    public Sprite redButton_top;
    public Sprite whiteButton_top;
    [Space(16)]
    public GameObject[] DirectSearchText; //영상 직접 검색 텍스트 - 4
    public GameObject[] TeaAndLockerInput;//락커번호
    [Header("Detail Vedio")]
    public GameObject[] DownloaadToggle;

    private bool selectedCourse, selectedDay;
    private bool firstVisit;
    private bool newVedio;
    private bool IsPremium;
    private bool HasVedio;
    private bool Download720, IsVedioOpen, IsDownloaded, PanoramaExplain, HasPanorama, SnapPhotoExplain, HasSnapPhoto;
    private Color red;
    private Color white;
    private Color black;

    private void OnEnable()
    {
        InitValue();
        Debug.Log("Home OnEnable");
    }
    public void VedioDownload()
    {
        if(!IsDownloaded)
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
            //다운로드 삭제
        }
        

        //영상에서 다운로드 버튼 눌렀을 때
        //다시 누르면 비디오 삭제
    }
    public void DeleteDownloadCancel()
    {
        UM.CancelPopUp();
    }
    public void DeleteDownloadConfirm()
    {
        //저장한 영상을 삭제하는 내용
        IsDownloaded = false;
        UM.CancelPopUp();
    }
    public void ConfirmDownload()
    {
        //다운로드 확인 버튼
        PopUp_downprograss();
        //다운로드 진행하는 함수 실행해야함 -> 다운로드가 끝나면 다운로드 완료 이미지로 교환해야함
        IsDownloaded = true;
        UM.CancelPopUp();
    }
    public void CancelDownload()
    {
        PopUp_downcancel();
        StartCoroutine(Download());
        IsDownloaded = false;
        UM.CancelPopUp();
    }
    public void ToggleVedioDownload_normal()
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
    public void ToggleVedioDownload()
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
    public void ConfirmOpenVedio()
    {
        //동영상 공개 여부를 서버로 전달
        UM.CancelPopUp();
    }
    public void CancelOpenVedio()
    {
        UM.CancelPopUp();
    }
    public void VedioOpenVedio()//영상 공개 버튼
    {
        if(IsVedioOpen)
        {
            //버튼 이미지 변경
            //영상 공개 해제
        }
        else
        {
            //현재 동영상 정보를 팝업창에 전달
            PopUp_openvedio();
        }
        //영상에서 영상 공개 버튼을 눌렀을 때
        //다시 누르면 비디오 공개 취소
    }
    public void PanoramaStopWatchingPopup()
    {
        PanoramaExplain = false;
        MovePanorama();
    }
    public void PanoramaConfirm()
    {
        MovePanorama();
    }

    public void VedioPanorama()
    {
        if (!HasPanorama)
        {
            if (PanoramaExplain) PopUp_explain();
            else MovePanorama();
        }
        else PopUp_deletePANORAMA();
        
        //영상에서 파노라마 버튼을 눌렀을 때
    }
    public void SnapShotStopWatchingPopUp()
    {
        SnapPhotoExplain = false;
        MovePanorama();//나중에 바꿔야함
    }
    public void VedioSnapPhoto()
    {
        if (!HasSnapPhoto)
        {
            if (SnapPhotoExplain) PopUp_snapphoto();
            else MovePanorama();//스냅포토로 변경해야함
        }
        else PopUP_deleteSNAPSHOT();
        

        //영상에서 스냅 포토버튼을 눌렀을 때
    }
    public void VedioShare()
    {
        PopUp_share();
        //영상에서 공유하기 버튼을 눌렀을 때
    }
    public void VedioMore()
    {
        //영상에서 더보기 버튼을 눌렀을 때(동영상 플레이어에 포함)
    }
    public void DeleteVedio()
    {
        //더보기에서 영상 삭제 버튼을 눌렀을 때
    }

    /// <summary>
    /// 영상과 메인 창 메서드 구분 선
    /// </summary>
    /// 
    public void TouchVedio()
    {
        //동영상을 터치 했을 때 실행되는 메서드
        GameObject Vedio = UM.CurrentSelectedGameObject();
        //나중에 동영상 프리펩에 있는 스크립트로 대체 후 실행하는 방법으로 진행
        MoveVedio();
    }
    public void SortFront()
    {
        //정면 tag 영상만 골라서 정렬하는 내용
    }
    public void SortSide()
    {
        //측면 태그된 영상만 골라서 정렬하는 내용
    }
    public void SortNew()
    {
        //최근순으로 정렬하는 내용
    }
    public void SortPopular()
    {
        //인기순으로 정렬하는 내용
    }
    public void SortLike()
    {
        //좋아요순으로 정려하는 내용
    }
    public void ToggleGolfCourse()//골프장 선택 토글
    {
        GameObject select = UM.CurrentSelectedGameObject();
        if(select.GetComponent<Toggle>().isOn)
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
    public void ToggleCheckIsTeaTime()//티타입 토글
    {
        GameObject select = TeaAndLockerInput[0].transform.parent.gameObject;
        if (select.GetComponent<Toggle>().isOn)
        {
            select.transform.GetChild(2).gameObject.SetActive(true);
            TeaAndLockerInput[1].SetActive(false);
            TeaAndLockerInput[0].SetActive(true);
        }
    }
    public void ToggleCheckIsLocker()//락커 토글
    {
        GameObject select = TeaAndLockerInput[1].transform.parent.gameObject;
        if (select.GetComponent<Toggle>().isOn)
        {
            select.transform.GetChild(2).gameObject.SetActive(true);
            TeaAndLockerInput[1].SetActive(true);
            TeaAndLockerInput[0].SetActive(false);
        }
    }
    public void ConfirmSearchVedio()//수동검색 영상 검색 확인 버튼
    {
        //검색중 애니메이션 재생
        //content 오브젝트에 조회결과를 추가
    }
    public void ConfirmRoundDay()//라운드 일자 선택
    {
        Calendar.GetComponent<ScrollingCalendar>().ShowDate();
        UM.CancelPopUp();
        selectedDay = true;
    }
    public void ConfirmTeaTime()//티타임 선택
    {
        Time.GetComponent<ScrollingTime>().ShowTime();
        UM.CancelPopUp();
    }
    public void PopUpConfirmNewVedio()
    {
        //새로 찾은 동영상을 추가하는 코드
    }
    public void PopUpConfirmGolfCourse()
    {        
        UM.CancelPopUp();
        selectedCourse = true;
    }
    public void ClickAutoSearch()
    {
        StartCoroutine(CheckNewVedio());
    }
    public void ClickPassiveSearch()
    {
        MoveDirectSearch();
    }
    public void ClickSearchVedio()
    {
        UM.ChildActiveOnOff();
    }
    public void ClickTopButton()
    {
        GameObject Button = EventSystem.current.currentSelectedGameObject.gameObject;      
        foreach(GameObject _ in TopButtons)
        {
            UM.ChangeImage(whiteButton_top, _);
            _.transform.GetChild(0).GetComponent<Text>().color = red;
        }
        UM.ChangeImage(redButton_top, Button);
        Button.transform.GetChild(0).GetComponent<Text>().color = white;
        //if(Button.name == ~~)
    }
    public void ClickTopButtonMain()
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

    private bool CheckInput()
    {
        if (selectedCourse && selectedDay) return true;
        return false;
    }

    public void Update()
    {
        if(CheckInput())
        {
            MoveDirectSearchDetail();
            selectedCourse = false;
            selectedDay = false;
        }
    }
    public IEnumerator Download()
    {
        yield return new WaitForSeconds(1f);
        UM.CancelPopUp(10);
    }
    public IEnumerator DirectSearch()
    {
        MoveDirectSearch();
        yield return null;
    }
    IEnumerator CheckNewVedio()
    {     
        yield return new WaitForSeconds(1f);
        //영상을 검색하는 내용
        //만약 영상이 이미 있으면 3번 페이지로 이동
        if (HasVedio) MoveMain();
        else MoveHome();

        if (firstVisit)
        {
            //loading animation
            if (newVedio)
            {
                PopUp_vediolist();

            }
            else PopUp_noVedio();
        }
        if(gameObject.transform.Find("GlobalCourutine") != null)GC.CheckCourutine();
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
        //그 날 첫번째 방문이면 -> 영상 검색 -> 0/x

    }


}
