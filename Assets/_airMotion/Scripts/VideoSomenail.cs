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
        VideoDetail VideoDetail = GameObject.Find("Canvas").transform.GetChild(4).GetChild(3).GetComponent<VideoDetail>();
        VideoDetail.Init(url);
        //���� ������ �ʱ�ȭ �ϴ� ������ ������
        UIManager.Instance.PageMove(4);
        VideoDetail.TouchVideo();
        VideoDetail.MakeVideos();
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