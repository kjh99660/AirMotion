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

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

        Reference();
        InitValue();
    }
    public void CheckBox()
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
    public void PageMove(int PageNumber)
    {
        Debug.Log("PageMove: " + PageNumber);
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
    public void PopUp(int PopUpNumber)
    {
        LoginPopUps[PopUpNumber].SetActive(true);
    }
    public void CancelPopUp()//자신의 부모 오브젝트를 끈다
    {
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }
    public void ChangeButtonImage(Sprite image)//해당 스크립트에 변경되는 이미지를 저장해야한다
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = image;
    }
    public bool IsValidEmail(string email)
    {
        bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=
?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
        return valid;
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
        PageMove(0);
    }
}
