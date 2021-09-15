using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MyVedio : MonoBehaviour//MyVedio관련해서 화면 이동 및 UI를 처리하는 스크립트
{
    [SerializeField] private GameObject[] myvedios;
    [SerializeField] private GameObject[] vedios;
    private GameObject[] popups;
    private bool hasVideo;
    private bool termOver;
    private bool premium;
    private bool downloaded;
    // Start is called before the first frame update
    void Start()
    {
        //서버로부터 사용자 정보를 받는다
        InitValue();
        LoadFirstPage();
    }
    public void ButtonDownload()
    {
        //다운로드하는 코드 작성하기
    }
    public void ButtonCancel() => EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    public void TouchDownLoad()
    {
        if(premium)
        {
            popups[1].SetActive(true);
        }
        else
        {
            popups[0].SetActive(true);
        }
    }
    public void TouchViedio()
    {
        //터치한 비디오를 서버에서 가져와서 myvedios[1]에 넣는다
        Debug.Log(myvedios[1]);
        myvedios[1].SetActive(true);
        if (downloaded)
        {
            myvedios[2].SetActive(true);
        }
        else
        {
            if (termOver)
            {
                vedios[1].SetActive(true);
            }
            else
            {
                vedios[0].SetActive(true);
            }
        }
        
    }
    public void TouchBest()
    {
        //move to best
    }
    public void TouchGolfCourse() => SceneManager.LoadScene("sceneGlofCourse");
    public void TouchProfile()
    {
        //move to Profile
    }
    private void LoadFirstPage()
    {
        myvedios[0].SetActive(true);
        if (hasVideo) vedios[2].SetActive(true);
        else vedios[3].SetActive(true);
    }
    private void InitValue()
    {
        termOver = false;//서버 받으면 수정하기
        hasVideo = true;//서버 받으면 수정하기
        premium = false;//서버 받으면 수정하기
        downloaded = true;//서버 받으면 수정하기
        myvedios = new GameObject[3];
        vedios = new GameObject[3];
        popups = new GameObject[2];
        myvedios[0] = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        myvedios[1] = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        myvedios[2] = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        vedios[0] = myvedios[1].transform.GetChild(6).gameObject;
        vedios[1] = myvedios[1].transform.GetChild(7).gameObject;
        vedios[2] = myvedios[0].transform.GetChild(8).gameObject;
        popups[0] = myvedios[1].transform.GetChild(8).gameObject;
        popups[1] = myvedios[1].transform.GetChild(9).gameObject;
        foreach (GameObject Page in myvedios) Page.SetActive(false);
        foreach (GameObject Page in vedios) Page.SetActive(false);
        foreach (GameObject Page in popups) Page.SetActive(false);
    }
}
