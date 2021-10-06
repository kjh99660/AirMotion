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
    public GameObject Calendar;
    public GameObject Time;
    public GameObject[] TopButtons;
    public Sprite redButton_top;
    public Sprite whiteButton_top;
    [Space(16)]
    public GameObject[] DirectSearchText; //영상 직접 검색 텍스트 - 4
    public GameObject[] TeaAndLockerInput;//락커번호

    private bool selectedCourse, selectedDay;
    private bool firstVisit;
    private bool newVedio;
    private bool IsPremium;
    private Color red;
    private Color white;

    private void OnEnable()
    {
        InitValue();
        Debug.Log("Home OnEnable");
    }
    public void VedioDownload()
    {
        //영상에서 다운로드 버튼 눌렀을 때
        //다시 누르면 비디오 삭제
    }
    public void VedioOpenVedio()
    {
        //영상에서 영상 공개 버튼을 눌렀을 때
        //다시 누르면 비디오 공개 취소
    }
    public void VedioPanorama()
    {
        //영상에서 파노라마 버튼을 눌렀을 때
    }
    public void VedioSnapPhoto()
    {
        //영상에서 스냅 포토버튼을 눌렀을 때
    }
    public void VedioShare()
    {
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
    private void MoveHome() => UM.PageMove(0);
    private void MoveDirectSearch() => UM.PageMove(1);
    private void MoveDirectSearchDetail() => UM.PageMove(2);

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
    IEnumerator CheckNewVedio()
    {
        
        yield return new WaitForSeconds(1f);
        //영상을 검색하는 내용
        //만약 영상이 이미 있으면 3번 페이지로 이동
        UM.PageMove(0);
        if (firstVisit)
        {
            //loading animation
            if (newVedio)
            {
                PopUp_vediolist();

            }
            else PopUp_noVedio();
        }
    }
    private void InitValue()
    {
        if(UM == null)UM = UIManager.Instance;
        UM.ResetUIManager();

        firstVisit = true;
        newVedio = false;
        IsPremium = false;
        selectedCourse = false; selectedDay = false;

        StartCoroutine(CheckNewVedio());

        white = new Color(1f, 1f, 1f, 1f); red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
        //그 날 첫번째 방문이면 -> 영상 검색 -> 0/x

    }


}
