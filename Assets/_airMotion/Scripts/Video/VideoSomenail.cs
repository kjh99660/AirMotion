using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoSomenail : MonoBehaviour
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
        //StartCoroutine(MakeVideoSomenail());
        MakeVideoSomenail();
    }

    public DateTime StrToDate(string input)//��¥ ���� ����
    {
        string format = "yyyyMMddHHmmss";
        DateTime dateTime = DateTime.ParseExact(input, format, null);
        return dateTime;
    }

    public void TouchVedio()//������ ��ġ �� ����Ǵ� �Լ�
    {
        UIManager.Instance.PageMove(4);
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

    void MakeVideoSomenail()
    {
        videoPlayer.Prepare();
        if (!videoPlayer.isPrepared)
        {
            Invoke("MakeVideoSomenail", 0f);
        }
        else
        {
            videoPlayer.time = videoPlayer.length / 2;
            videoPlayer.Play();
            videoPlayer.Pause();
        }
    }
    //IEnumerator MakeVideoSomenail()//���� �÷��̾� ����� ����
    //{
    //    print("MakeVideoSomenail");
    //    videoPlayer.Prepare();
    //    //yield return new WaitUntil(() => videoPlayer.isPrepared);

    //    while (!videoPlayer.isPrepared)
    //    {
    //        videoPlayer.Prepare();
    //        print(videoPlayer.isPrepared);
    //        //if (!videoPlayer.isPrepared) videoPlayer.Prepare();
    //        yield return null;
    //    }

    //    print("isPrepared");
    //    videoPlayer.time = videoPlayer.length / 2;
    //    videoPlayer.Play();
    //    yield return new WaitUntil(() => videoPlayer.isPlaying);
    //    videoPlayer.Pause();
    //}
}
