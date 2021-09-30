using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Home : MonoBehaviour
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
    }

    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveGolfCourse() => SceneManager.LoadScene("glofCourse");
    public void MoveMore() => SceneManager.LoadScene("more");
    public void PopUp_noVedio() => UM.PopUp(0);
    public void PopUp_search() => UM.PopUp(1);
    public void PopUp_vediolist() => UM.PopUp(2);
    public void PopUp_golfCourse() => UM.PopUp(3);
    public void PopUp_deleteVedio() => UM.PopUp(4);
    public void PopUp_roundDay() => UM.PopUp(5);
    public void PopUp_teaTime() => UM.PopUp(6);
    public void MoveHome() => UM.PageMove(0);
    public void MoveDirectSearch() => UM.PageMove(1);
    public void MoveAutoSearch() => PopUp_search();
    IEnumerator CheckNewVedio()
    {
        
        yield return new WaitForSeconds(1f);
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
