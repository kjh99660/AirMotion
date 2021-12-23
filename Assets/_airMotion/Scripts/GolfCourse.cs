using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GolfCourse : MonoBehaviour
{
    private UIManager UM;
    private GlobalCourutine GC;
    private Color red;
    private Color white;
    public GameObject[] TopButtons;
    private void OnEnable()
    {
        InitValue();
        Debug.Log("GolfCourse OnEnable");
        StartCoroutine(LoadGolfCourse());
    }
    private void Start()
    {
        InitValue();
        Debug.Log("GolfCourse OnEnable");
        StartCoroutine(LoadGolfCourse());
    }

    //# Golf Main > 0
    public void ToggleTopButtons()//위쪽 UI 클릭할 때 색상 변경 코드
    {
        GameObject Button = EventSystem.current.currentSelectedGameObject.gameObject;
        
        foreach (GameObject _ in TopButtons)
        {
            //UM.ChangeImage(whiteButton_top, _);
            //_.transform.GetChild(0).GetComponent<Text>().color = red;
        }
        //UM.ChangeImage(redButton_top, Button);
        //Button.transform.GetChild(0).GetComponent<Text>().color = white;
        
    }

    public void ClickSearchVedio()//영상매칭 버튼
    {
        UM.ChildActiveOnOff();
    }

    public void ClickDirecctSearch()//수동검색 영상 검색 확인 버튼
    {
        GC.AddCourutine("home", "DirectSearch");
        MoveHome();
    }

    public void AutoSearch()// 자동 검색
    {
        GC.AddCourutine("home", "CheckNewVedio");
        MoveHome();
    }

    IEnumerator LoadGolfCourse() //서버에서 골프장 목록 받아오는 내용
    {      
        //need to more
        yield return new WaitForSeconds(1f);
        MoveMain();
    }

    //단순 화면 전환
    public void MoveMain() => UM.PageMove(0);
    public void MovePanorma() => SceneManager.LoadScene("PANORAMA");
    public void MoveHome() => SceneManager.LoadScene("home");
    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveMore() => SceneManager.LoadScene("more");
    public void MoveGolfCourse() => SceneManager.LoadScene("golfCourse");

    private void InitValue()
    {
        if (UM == null) UM = UIManager.Instance;
        if (GC == null) GC = GlobalCourutine.Instance;
        UM.ResetUIManager();       
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
    }
}
