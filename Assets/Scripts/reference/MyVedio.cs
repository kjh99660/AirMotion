using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MyVedio : MonoBehaviour//MyVedio�����ؼ� ȭ�� �̵� �� UI�� ó���ϴ� ��ũ��Ʈ
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
        //�����κ��� ����� ������ �޴´�
        InitValue();
        LoadFirstPage();
    }
    public void ButtonDownload()
    {
        //�ٿ�ε��ϴ� �ڵ� �ۼ��ϱ�
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
        //��ġ�� ������ �������� �����ͼ� myvedios[1]�� �ִ´�
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
        termOver = false;//���� ������ �����ϱ�
        hasVideo = true;//���� ������ �����ϱ�
        premium = false;//���� ������ �����ϱ�
        downloaded = true;//���� ������ �����ϱ�
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
