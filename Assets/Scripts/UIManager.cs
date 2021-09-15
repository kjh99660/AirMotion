using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    private GameObject Canvas;
    private GameObject popup;
    private Dictionary<int, GameObject> LoginWindows;
    private Dictionary<int, GameObject> LoginPopUps;
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
    }
    
    public void PageMove(int PageNumber)
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
    public void PopUp(int PopUpNumber)
    {
        LoginPopUps[PopUpNumber].SetActive(true);
    }
    public void CancelPopUp()
    {
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }
    public void ChangeButton(Sprite image)//해당 스크립트에 변경되는 이미지를 저장해야한다
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = image;
    }
    


    private void Reference()
    {
        LoginWindows = new Dictionary<int, GameObject>();
        LoginPopUps = new Dictionary<int, GameObject>();
        Canvas = GameObject.Find("Canvas");
        popup = GameObject.Find("POPUP");
        for(int value = 0; value < Canvas.transform.childCount; value++)
        {
            LoginWindows.Add(value, Canvas.transform.GetChild(value).gameObject);
        }
        for (int value = 0; value < popup.transform.childCount; value++)
        {
            LoginPopUps.Add(value, popup.transform.GetChild(value).gameObject);
        }

    }
}
