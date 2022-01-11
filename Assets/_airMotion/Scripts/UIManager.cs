using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    private GameObject Canvas;
    private GameObject popup;
    private Dictionary<int, GameObject> LoginWindows;
    private Dictionary<int, GameObject> LoginPopUps;
    private Color black, white;
    public static UIManager Instance
    {
        get
        {
            if(!instance)
            {
                GameObject.Find("UIManager").GetComponent<UIManager>().Awake();
            }
            return instance;
        }
    }
    public void ResetUIManager() => GameObject.Find("UIManager").GetComponent<UIManager>().Awake();
    public GameObject CurrentSelectedGameObject()
    {
        return EventSystem.current.currentSelectedGameObject.gameObject;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        /*
        else
        {
            Destroy(this.gameObject);
            Debug.Log("delete UIManager");
        }
        */
        Reference();
        InitValue();
    }
    public void ChildActiveOnOff()//자식 오브젝트를 키거나 끈다
    {
        GameObject parent = EventSystem.current.currentSelectedGameObject;
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            if (child.activeSelf) child.SetActive(false);
            else child.SetActive(true);          
        }
    }
    public void CheckBox()//체크박스
    {
        GameObject temp = EventSystem.current.currentSelectedGameObject;
        Toggle toggle = temp.GetComponent<Toggle>();
        Image image = temp.GetComponent<Image>();
        if (toggle.isOn)
        {
            image.color = black;
        }
        else
        {
            image.color = white;
        }
    }
    public void PageMove(int PageNumber)//페이지 이동
    {       
        foreach(KeyValuePair<int, GameObject> Page in LoginWindows)
        {
            Page.Value.SetActive(false);
        }
        foreach (KeyValuePair<int, GameObject> Page in LoginPopUps)
        {
            Page.Value.SetActive(false);
        }
        LoginWindows[PageNumber].SetActive(true);
    }

    public void PopUp(int PopUpNumber)//팝업
    {
        LoginPopUps[PopUpNumber].SetActive(true);
    }

    public void CancelPopUp(int PopUpNumber)//팝업을 끈다
    {
        LoginPopUps[PopUpNumber].SetActive(false);
    }

    public bool CheckPopUp()//팝업이 열려 있는지 체크한다
    {
        foreach (KeyValuePair<int, GameObject> Page in LoginPopUps)
        {
            if (Page.Value.activeSelf) return true;
        }
        return false;
    }
    public void CancelPopUp()//자신의 부모 오브젝트를 끈다
    {
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }

    public void ChangeButtonImage(Sprite image)//해당 스크립트에 변경되는 이미지를 저장해야한다
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = image;
    }

    public bool IsValidEmail(string email)//이메일 형식 일치 확인
    {
        bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=
?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
        Debug.Log("ISValidEmail: " + valid);
        return valid;
    }

    public bool IsValidPhone(string phone)//헨드폰 형식 일치 확인
    {
        bool regPhone = Regex.IsMatch(phone,@"^01([0|1|6|7|8|9])-?([0-9]{3,4})-?([0-9]{4})$", RegexOptions.IgnorePatternWhitespace);
        Debug.Log("ISValidPhone: " + regPhone);
        return regPhone;
    }

    public bool IsValidPassword(string password)//비밀번호 형식 일치 확인
    {
        bool valid = Regex.IsMatch(password, @"^(?=.*?[A-Za-z0-9])(?=.*?[#?!@$%^&*-]).{10,}$", RegexOptions.IgnorePatternWhitespace);
        Debug.Log("ISValidPassword: " + password);
        return valid;
    }

    public void ChangeImage(Sprite sprite, GameObject button)//이미지를 바꾼다
    {       
        button.GetComponent<Button>().image.overrideSprite = sprite;
    }

    public bool EndEditInput(Text text) //1 = 이메일 형식 확인 2 = 비밀번호 형식 확인
    {
        string input = text.text;
        if (!IsValidEmail(input))
        {
            return false;
        }
        else return true;
        Debug.Log("propose incorrect");
        return true;
    }

    private void Reference()
    {
        black = new Color(0f, 0f, 0f, 0f);
        white = new Color(1f, 1f, 1f, 1f);
        LoginWindows = new Dictionary<int, GameObject>();
        LoginPopUps = new Dictionary<int, GameObject>();
        Canvas = GameObject.Find("Canvas");
        popup = Canvas.transform.Find("POPUP").gameObject;     
        int temp = Canvas.transform.childCount;
        int temp2 = popup.transform.childCount;
        for (int value = 0; value < temp; value++)
        {
            LoginWindows.Add(value, Canvas.transform.GetChild(value).gameObject);
        }
        for (int value = 0; value < temp2; value++)
        {
            LoginPopUps.Add(value, popup.transform.GetChild(value).gameObject);
        }
        LoginWindows.Remove(temp - 2);
        LoginWindows.Remove(temp - 1);
    }
    private void InitValue()
    {
        foreach (KeyValuePair<int, GameObject> Page in LoginWindows)
        {
            Page.Value.SetActive(false);
        }
        foreach (KeyValuePair<int, GameObject> Page in LoginPopUps)
        {
            Page.Value.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!CheckPopUp() && GameObject.Find("btn_back") != null)
            {
                Button button = GameObject.Find("btn_back").GetComponent<Button>();
                button.onClick.Invoke();
            }

        }
        if (Application.platform == RuntimePlatform.Android)
        {
            //need to add
        }
    }

}
