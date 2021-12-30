using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoDetail : MonoBehaviour
{
    public VideoPlayer video;
    public Button button;
    private bool isPlaying;

    [Header("Text")]
    public Text t_tag;
    public Text t_title;
    public Text t_date;
    public Text t_view;
    public Text t_like;

    public void Init(string url)
    {
        video.url = url;
        isPlaying = false;
    }
    
    public void TouchVideo()//비디오 정지 및 재생 관련 메서드
    {
        if(isPlaying)
        {
            video.Pause();
            isPlaying = false;
        }
        else
        {
            video.Play();
            isPlaying = true;
        }
        Debug.Log("video OnOff");
    }
}
