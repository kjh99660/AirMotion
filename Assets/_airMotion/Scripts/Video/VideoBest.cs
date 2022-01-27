using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoBest : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Text title_t;
    public Text viewCount_t;
    public Text date_t;
    public Text download_t;
    public Text like_t;
    //public RawImage image;
    public Button button;
    public RenderTexture[] renderTextures;
    private string url;

    public void Init(string url, string date, string title, int number)
    {
        DateTime temp = StrToDate(date);
        date = temp.ToString("d");
        date = date.Replace("-", ".");
        date_t.text = date;
        title_t.text = title;
        videoPlayer.url = url;
        this.url = url;
        videoPlayer.targetTexture = renderTextures[number];
        videoPlayer.GetComponent<RawImage>().texture = renderTextures[number];

        StartCoroutine(MakeVideoSomenail());
    }

    public DateTime StrToDate(string input)//��¥ ���� ����
    {
        string format = "yyyyMMddHHmmss";
        DateTime dateTime = DateTime.ParseExact(input, format, null);
        return dateTime;
    }

    public void TouchVedio()//������ ��ġ �� ����Ǵ� �Լ�
    {
       
        if (SceneManager.GetActiveScene().name == "home")
        {
            UIManager.Instance.PageMove(2);
            Home home = GameObject.Find("HomeManager").GetComponent<Home>();
            if (home != null)
            {
                home.urlNowUse = url;
            }
            VideoDetail VideoDetail = GameObject.Find("Canvas").transform.GetChild(4).GetChild(3).GetComponent<VideoDetail>();
            //���� ������ �ʱ�ȭ �ϴ� ������ ������      
            VideoDetail.Init(url);
            VideoDetail.PlayButton();
            VideoDetail.MakeVideos();
        }
        else if(SceneManager.GetActiveScene().name == "best")                
        {
            UIManager.Instance.PageMove(2);
            BEST best = GameObject.Find("BESTManager").GetComponent<BEST>();
            if (best != null)
            {
                best.urlNowUse = url;
            }
            VideoDetail VideoDetail = GameObject.Find("Canvas").transform.GetChild(2).GetChild(3).GetComponent<VideoDetail>();
            //���� ������ �ʱ�ȭ �ϴ� ������ ������      
            VideoDetail.Init(url);
            VideoDetail.PlayButton();
            VideoDetail.MakeVideos();
        }
    }

    IEnumerator MakeVideoSomenail()//���� �÷��̾� ����� ����
    {
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
        videoPlayer.time = videoPlayer.length / 2;
        videoPlayer.Play();
        yield return new WaitUntil(() => videoPlayer.isPlaying);
        videoPlayer.Pause();
    }
}
