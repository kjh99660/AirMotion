using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
using UnityEngine.UI.Extensions.Examples;

public class Home : MonoBehaviour //���� �˻��� �ϴ� ���� ��ũ��Ʈ
{
    private UIManager UM;
    public GameObject Calendar;
    public GameObject Time;
    public GameObject[] TopButtons;
    public Sprite redButton_top;
    public Sprite whiteButton_top;
    [Space(16)]
    public GameObject[] DirectSearchText; //���� ���� �˻� �ؽ�Ʈ - 4
    public GameObject[] TeaAndLockerInput;//��Ŀ��ȣ

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
        //���󿡼� �ٿ�ε� ��ư ������ ��
        //�ٽ� ������ ���� ����
    }
    public void VedioOpenVedio()
    {
        //���󿡼� ���� ���� ��ư�� ������ ��
        //�ٽ� ������ ���� ���� ���
    }
    public void VedioPanorama()
    {
        //���󿡼� �ĳ�� ��ư�� ������ ��
    }
    public void VedioSnapPhoto()
    {
        //���󿡼� ���� �����ư�� ������ ��
    }
    public void VedioShare()
    {
        //���󿡼� �����ϱ� ��ư�� ������ ��
    }
    public void VedioMore()
    {
        //���󿡼� ������ ��ư�� ������ ��(������ �÷��̾ ����)
    }
    public void DeleteVedio()
    {
        //�����⿡�� ���� ���� ��ư�� ������ ��
    }

    /// <summary>
    /// ����� ���� â �޼��� ���� ��
    /// </summary>
    /// 
    public void SortFront()
    {
        //���� tag ���� ��� �����ϴ� ����
    }
    public void SortSide()
    {
        //���� �±׵� ���� ��� �����ϴ� ����
    }
    public void SortNew()
    {
        //�ֱټ����� �����ϴ� ����
    }
    public void SortPopular()
    {
        //�α������ �����ϴ� ����
    }
    public void SortLike()
    {
        //���ƿ������ �����ϴ� ����
    }
    public void ToggleGolfCourse()//������ ���� ���
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
    public void PopUpConfirmNewVedio()
    {
        //���� ã�� �������� �߰��ϴ� �ڵ�
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
        //������ �˻��ϴ� ����
        //���� ������ �̹� ������ 3�� �������� �̵�
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
        //�� �� ù��° �湮�̸� -> ���� �˻� -> 0/x

    }


}
