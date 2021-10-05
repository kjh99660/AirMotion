using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Home : MonoBehaviour //영상 검색을 하는 씬의 스크립트
{
    private UIManager UM;
    public GameObject[] TopButtons;
    public Sprite redButton_top;
    public Sprite whiteButton_top;

    private bool firstVisit;
    private bool newVedio;
    private Color red;
    private Color white;

    private void OnEnable()
    {
        InitValue();
        Debug.Log("Home OnEnable");
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
    private void MoveMyVedio() => SceneManager.LoadScene("myVedio");
    public void PopUp_noVedio() => UM.PopUp(0);
    private void PopUp_search() => UM.PopUp(1);
    private void PopUp_vediolist() => UM.PopUp(2);
    private void PopUp_golfCourse() => UM.PopUp(3);
    private void PopUp_deleteVedio() => UM.PopUp(4);
    private void PopUp_roundDay() => UM.PopUp(5);
    private void PopUp_teaTime() => UM.PopUp(6);
    private void MoveHome() => UM.PageMove(0);
    private void MoveDirectSearch() => UM.PageMove(1);
    IEnumerator CheckNewVedio()
    {
        
        yield return new WaitForSeconds(1f);
        //영상을 검색하는 내용
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
        StartCoroutine(CheckNewVedio());
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
        //그 날 첫번째 방문이면 -> 영상 검색 -> 0/x

    }


}
