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
    public void ChildActiveOnOff()//�ڽ� ������Ʈ�� Ű�ų� ����
    {
        GameObject parent = EventSystem.current.currentSelectedGameObject;
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            if (child.activeSelf) child.SetActive(false);
            else child.SetActive(true);          
        }
    }
    public void CheckBox()//üũ�ڽ�
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
    public void PageMove(int PageNumber)//������ �̵�
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

    public void PopUp(int PopUpNumber)//�˾�
    {
        LoginPopUps[PopUpNumber].SetActive(true);
    }

    public void CancelPopUp(int PopUpNumber)//�˾��� ����
    {
        LoginPopUps[PopUpNumber].SetActive(false);
    }

    public bool CheckPopUp()//�˾��� ���� �ִ��� üũ�Ѵ�
    {
        foreach (KeyValuePair<int, GameObject> Page in LoginPopUps)
        {
            if (Page.Value.activeSelf) return true;
        }
        return false;
    }
    public void CancelPopUp()//�ڽ��� �θ� ������Ʈ�� ����
    {
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }

    public void ChangeButtonImage(Sprite image)//�ش� ��ũ��Ʈ�� ����Ǵ� �̹����� �����ؾ��Ѵ�
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = image;
    }

    public bool IsValidEmail(string email)//�̸��� ���� ��ġ Ȯ��
    {
        bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=
?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
        Debug.Log("ISValidEmail: " + valid);
        return valid;
    }

    public bool IsValidPhone(string phone)//����� ���� ��ġ Ȯ��
    {
        bool regPhone = Regex.IsMatch(phone,@"^01([0|1|6|7|8|9])-?([0-9]{3,4})-?([0-9]{4})$", RegexOptions.IgnorePatternWhitespace);
        Debug.Log("ISValidPhone: " + regPhone);
        return regPhone;
    }

    public bool IsValidPassword(string password)//��й�ȣ ���� ��ġ Ȯ��
    {
        bool valid = Regex.IsMatch(password, @"^(?=.*?[A-Za-z0-9])(?=.*?[#?!@$%^&*-]).{10,}$", RegexOptions.IgnorePatternWhitespace);
        Debug.Log("ISValidPassword: " + password);
        return valid;
    }

    public void ChangeImage(Sprite sprite, GameObject button)//�̹����� �ٲ۴�
    {       
        button.GetComponent<Button>().image.overrideSprite = sprite;
    }

    public bool EndEditInput(Text text) //1 = �̸��� ���� Ȯ�� 2 = ��й�ȣ ���� Ȯ��
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
