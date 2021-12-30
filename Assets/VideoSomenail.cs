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
        videoPlayer.targetTexture = renderTextures[number];
        this.url = url;
        //비디오 플레이어 썸네일 생성

        videoPlayer.time = 1f;
        videoPlayer.Play();
        videoPlayer.Pause();

        //버튼 초기화       
        button.onClick.AddListener(() => TouchVedio());

    }

    public DateTime StrToDate(string input)//날짜 포맷 추출
    {
        string format = "yyyyMMddHHmmss";
        DateTime dateTime = DateTime.ParseExact(input, format, null);
        return dateTime;
    }

    private void TouchVedio()//비디오를 터치 시 실행되는 함수
    {
        VideoDetail VideoDetail = GameObject.Find("Canvas").transform.GetChild(4).GetChild(3).GetComponent<VideoDetail>();
        VideoDetail.Init(url);
        //세부 비디오를 초기화 하는 내용이 들어가야함
        UIManager.Instance.PageMove(4);
    }
}
